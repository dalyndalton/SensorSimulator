using SharedClasses;

namespace RacerServer
{
    public struct Cheater
    {
        public Racer r1;
        public Racer r2;
        public int sensor;

        public Cheater(Racer r1, Racer r2, int sensor)
        {
            this.r1 = r1;
            this.r2 = r2;
            this.sensor = sensor;
        }
    }

    public class CheaterComputer : IObserver<Racer>, IObservable<CheaterComputer>
    {

        private Dictionary<int, Dictionary<Racer, int>> timelist;
        public List<Cheater> Cheaters { get; private set; }

        // Observer list for cheaters
        private List<IObserver<CheaterComputer>> Observers { get; set; }

        public CheaterComputer()
        {
            timelist = new();
            Cheaters = new();
            Observers = new();
        }

        public void DetectCheater(Racer value)
        {
            // Check for cheater
            var prev_time = this.timelist[value.CurrentSensor - 1][value];

            var friends = from racer_time in this.timelist[value.CurrentSensor - 1]
                          where Math.Abs(racer_time.Value - prev_time) <= 3000 && racer_time.Key != value && racer_time.Key.RaceGroup != value.RaceGroup
                          select racer_time;

            var newFriends = from racer_time in this.timelist[value.CurrentSensor]
                             where Math.Abs(racer_time.Value - value.LastTime) <= 3000 && racer_time.Key != value && racer_time.Key.RaceGroup != value.RaceGroup
                             select racer_time;


            IEnumerable<Racer> sharedFriends = from one in friends
                                               join two in newFriends on one.Value equals two.Value
                                               select one.Key;
            if (sharedFriends.Any())
            {
                // add all cheating friends
                foreach (Racer? friend in sharedFriends)
                {
                    // Lookup times
                    var cheater = new Cheater(value, friend, value.CurrentSensor);
                    Cheaters.Add(cheater);
                    Console.WriteLine($" Cheater @ {cheater.sensor}: {cheater.r1} <-> {cheater.r2}");
                }

                // Notify observers that cheating list has ben updated
                foreach (IObserver<CheaterComputer> sub in Observers)
                {
                    sub.OnNext(this);
                }
            }
        }

        #region Observer Functions
        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        // Processes the logic for determining if the incoming racer was cheating
        public void OnNext(Racer value)
        {
            // Create a log for the sensor if not already existing
            if (!timelist.ContainsKey(value.CurrentSensor)) timelist.Add(value.CurrentSensor, new Dictionary<Racer, int>());
            else
            {
                // Prevent the double lookup
                if (!timelist[value.CurrentSensor].ContainsKey(value) && 
                    value.CurrentSensor != 0) DetectCheater(value);
            }

            // Log racer as seen
            timelist[value.CurrentSensor][value] = value.LastTime;
        }

        #endregion


        #region Observable Functions
        // Provide methods for CheaterDisplays to subscribe and unsub
        public IDisposable Subscribe(IObserver<CheaterComputer> observer)
        {
            if (!Observers.Contains(observer))
            {
                Observers.Add(observer);
            }

            return new Unsubscriber(Observers, observer);
        }
        private class Unsubscriber : IDisposable
        {
            private List<IObserver<CheaterComputer>> _observers;
            private IObserver<CheaterComputer> _observer;

            public Unsubscriber(List<IObserver<CheaterComputer>> observers, IObserver<CheaterComputer> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (!(_observer == null)) _observers.Remove(_observer);
            }
        }
        #endregion
    }
}

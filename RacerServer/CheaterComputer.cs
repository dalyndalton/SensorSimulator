using SharedClasses;

namespace RacerServer
{
    public class CheaterComputer : IObserver<Racer>, IObservable<CheaterComputer>
    {
        public struct Cheater
        {
            Racer r1;
            Racer r2;
            int sensor;

            public Cheater(Racer r1, Racer r2, int sensor)
            {
                this.r1 = r1;
                this.r2 = r2;
                this.sensor = sensor;
            }
        }

        private Dictionary<int, Dictionary<Racer, int>> timelist;
        public List<Cheater> cheaters { get; private set; }
        private List<IObserver<CheaterComputer>> Observers { get; set; }

        public CheaterComputer()
        {
            timelist = new();
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(Racer value)
        {
            if (value.CurrentSensor >= 1 && timelist.ContainsKey(value.CurrentSensor))
            {
                // Check for cheater
                IEnumerable<Racer> friends = from time in this.timelist[value.CurrentSensor - 1]
                                             where Math.Abs(time.Value - value.LastTime) <= 3000 && time.Key != value && time.Key.RaceGroup != value.RaceGroup
                                             select time.Key;
                IEnumerable<Racer> newFriends = from time in this.timelist[value.CurrentSensor]
                                                where Math.Abs(time.Value - value.LastTime) <= 3000 && time.Key != value && time.Key.RaceGroup != value.RaceGroup
                                                select time.Key;

                IEnumerable<Racer> sharedFriends = friends.Intersect(newFriends);
                if (sharedFriends.Any())
                {
                    // add all cheating friends
                    foreach (Racer? friend in sharedFriends)
                    {
                        cheaters.Add(new Cheater(value, friend, value.CurrentSensor));
                    }

                    // Notify observers that cheating list has ben updated
                    foreach (IObserver<CheaterComputer> sub in Observers)
                    {
                        sub.OnNext(this);
                    }
                }
            }

            // Create a log for the sensor if not already existing
            if (!timelist.ContainsKey(value.CurrentSensor))
            {
                timelist.Add(value.CurrentSensor, new Dictionary<Racer, int>());
            }
            // Log as seen
            timelist[value.CurrentSensor][value] = value.LastTime;
        }

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
    }
}

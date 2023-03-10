using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedClasses
{
    // HEY THIS IS A PATTERN HERE, LOOK AT RACERDISPLAY TO SEE THE OBSERVER
    public class Racer : IObservable<Racer>, IComparable<Racer>
    {
        public string Name { get; set; }
        public int BibId { get; set; }
        public RaceGroup RaceGroup { get; private set; }
        public int CurrentSensor { get; private set; }
        public int Position { get; private set; }
        public int LastTime { get; private set; }

        // Observers are stored here
        private List<IObserver<Racer>> Observers { get; set; }

        public Racer(string name, int bibId, RaceGroup group)
        {
            this.Name = name;
            this.BibId = bibId;
            this.Observers = new List<IObserver<Racer>>();
            this.RaceGroup = group;

            // Simple Defaults
            this.Position = 0;
            CurrentSensor = 0;
            LastTime = 0;
        }
        // Used to parse the CSV, returns an instance
        public static Racer parseRacer(string[] fields, Dictionary<int, RaceGroup> groupList)
        {
            return new Racer(
                fields[0] + ' ' + fields[1],
                Int32.Parse(fields[2]),
                groupList[Int32.Parse(fields[3])]
                );
        }
        public void UpdateRacerSensor(int sensor, int time)
        {
            lock (this)
            {
                this.CurrentSensor = sensor;
                this.LastTime = time;
                Parallel.ForEach(Observers, obs => obs.OnNext(this));
            }
        }

        public void UpdateRacerPosition(int position)
        {
            this.Position = position;
            Parallel.ForEach(Observers, obs => obs.OnNext(this));
        }

        // Observers are Subscribed to here, and return their unsubscribers
        public IDisposable Subscribe(IObserver<Racer> observer)
        {
            lock (Observers)
            {
                if (!Observers.Contains(observer))
                {
                    Observers.Add(observer);
                }
            }

            observer.OnNext(this);
            return new Unsubscriber(Observers, observer);
        }
        private class Unsubscriber : IDisposable
        {
            private List<IObserver<Racer>> _observers;
            private IObserver<Racer> _observer;

            public Unsubscriber(List<IObserver<Racer>> observers, IObserver<Racer> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (_observer == null) return;
                _observers.Remove(_observer);

            }
        }

        // C# Native Overrides and support functions
        public override string? ToString()
        {
            return $"# {this.BibId.ToString().PadLeft(4)} : {Name}";
        }
        public int CompareTo(Racer? other)
        {
            if (this.CurrentSensor > other.CurrentSensor) return 1;
            if (this.CurrentSensor < other.CurrentSensor) return -1;

            if (this.LastTime < other.LastTime) return 1;
            if (this.LastTime > other.LastTime) return -1;

            return 0;
        }

        public override bool Equals(object? obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var r = (Racer)obj;
            return r.BibId == this.BibId;
        }
    }
}

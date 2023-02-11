using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedClasses
{
    public class Racer : IObservable<Racer>
    {
        public string Name { get; set; }
        public int BibId { get; set; }
        public int? Endtime
        {
            get => Endtime; set
            {
                Endtime = value;
                foreach (var obs in Observers)
                {
                    obs.OnCompleted();
                }
            }
        }

        public RaceGroup group { get; private set; }
        public int CurrentSensor { get; private set; }
        public int LastTime
        { get; private set; }

        public int Position { get; private set; }
        private List<IObserver<Racer>> Observers { get; set; }

        public Racer(string name, int bibId, RaceGroup group, int starttime, int totalSensors)
        {
            this.Name = name;
            this.BibId = bibId;
            this.Observers = new List<IObserver<Racer>>();
            this.group = group;
            CurrentSensor = 0;
            LastTime = 0;
        }

        public void UpdateRacer(int sensor, int time, int position)
        {
            this.CurrentSensor = sensor;
            this.LastTime = time;
            this.Position = position;

            Observers.ForEach((obs) => obs.OnNext(this));
        }

        public IDisposable Subscribe(IObserver<Racer> observer)
        {
            if (!Observers.Contains(observer))
            {
                Observers.Add(observer);
            }

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
                if (!(_observer == null)) _observers.Remove(_observer);
            }
        }
    }
}

using SharedClasses;

namespace RacerServer
{
    public partial class BigScreen : Form, IObserver<Racer>
    {
        public string ObsName { get; set; }
        public Dictionary<Racer, IDisposable> Racers { get; set; }

        public BigScreen(string name)
        {
            Racers = new Dictionary<Racer, IDisposable>();

            InitializeComponent();
            this.ObsName = name;
        }

        public override string ToString()
        {
            return ObsName;
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
            this.Invoke(this.UpdateItems);
        }

        public void UpdateItems()
        {
            // Update each object in the list, as most all positions have changed
            foreach (ListViewItem item in Display.Items)
            {
                var subject = item.Tag as Racer;
                if (subject == null) return;

                item.SubItems.Clear();
                item.SubItems.Add(subject.RaceGroup.GroupName);
                item.SubItems.Add(subject.Position.ToString());
                item.SubItems.Add((subject.LastTime - subject.RaceGroup.StartTime).ToString());
            }
        }

        public void SubscribeToRacer(Racer value)
        {
            IDisposable unsub = value.Subscribe(this);
            Racers.Add(value, unsub);

            // Create the listView Items
            ListViewItem item = new()
            {
                Text = value.Name,
                Tag = value,
            };
            item.SubItems.Add(value.RaceGroup.ToString());
            item.SubItems.Add(value.Position.ToString());
            item.SubItems.Add((value.LastTime - value.RaceGroup.StartTime).ToString());
            Display.Items.Add(item);
        }

        public void UnsubscribeToRacer(Racer value)
        {
            Racers[value].Dispose();
            Racers.Remove(value);
        }

        private void BigScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
    }
}

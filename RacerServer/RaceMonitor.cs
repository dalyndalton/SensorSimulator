using SharedClasses;

namespace RacerServer
{
    public partial class RaceMonitor : Form
    {

        public List<BigScreen> screens;
        private Dictionary<int, Racer> racers;
        private Dictionary<int, RaceGroup> groups;
        private Dictionary<int, int> sensors;

        public RaceMonitor(Dictionary<int, Racer> racers, Dictionary<int, RaceGroup> groups, Dictionary<int, int> sensors)
        {
            this.racers = racers;
            this.groups = groups;
            this.sensors = sensors;
            this.screens = new();
            InitializeComponent();
        }

        private void BigScreenAdd(object sender, EventArgs e)
        {
            BigScreen screen = new(Prompt.ShowDialog("Name", "Big Screen Display Setup"));
            screen.Show();
            this.BigScreenList.Items.Add(screen);
        }

        private void BigScreenList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Clear current values
            this.CheaterScreenList.ClearSelected();
            this.AvailableRacers.Items.Clear();
            this.CurrentObserverBox.Items.Clear();

            // Load in valid items
            BigScreen? screen = this.BigScreenList.SelectedItem as BigScreen;
            if (screen != null)
            {
                foreach (Racer c in screen.Racers.Keys)
                {
                    this.CurrentObserverBox.Items.Add(c);
                }
                IEnumerable<Racer> available = from r in this.racers.Values
                                               where !screen.Racers.ContainsKey(r)
                                               select r;

                foreach (Racer? racer in available)
                {
                    this.AvailableRacers.Items.Add(racer);
                }
            }
        }

        private void BigScreenReopen(object sender, EventArgs e)
        {
            foreach (BigScreen screen in this.BigScreenList.SelectedItems)
            {
                screen.Show();
            }
        }
        private void BigScreenSubscribe(object sender, EventArgs e)
        {
            BigScreen? obs = BigScreenList.SelectedItem as BigScreen;
            if (obs == null) return;

            List<Racer> selectedRacers = new();

            // Get each availabe racer
            foreach (object? rac in AvailableRacers.SelectedItems)
            {
                selectedRacers.Add(rac as Racer);
            }

            // Remove racers from available list
            while (AvailableRacers.SelectedItems.Count > 0)
            {
                AvailableRacers.Items.RemoveAt(AvailableRacers.SelectedIndex);
            }

            // Subscribe to the new racers
            foreach (Racer rac in selectedRacers)
            {
                obs.SubscribeToRacer(rac);
            }

            // Update the Current Observer Box
            selectedRacers.ForEach(rac => CurrentObserverBox.Items.Add(rac));
        }
        private void BigScreenUnsub(object sender, EventArgs e)
        {
            BigScreen? obs = BigScreenList.SelectedItem as BigScreen;
            if (obs == null) return;

            List<Racer> selectedRacers = new();

            // Get each current racer
            foreach (object? rac in CurrentObserverBox.SelectedItems)
            {
                selectedRacers.Add(rac as Racer);
            }

            // Remove racers from current list
            while (CurrentObserverBox.SelectedItems.Count > 0)
            {
                CurrentObserverBox.Items.RemoveAt(CurrentObserverBox.SelectedIndex);
            }

            // Unsubscribe to the selected racers
            foreach (Racer rac in selectedRacers)
            {
                obs.UnsubscribeToRacer(rac);
            }

            // Update the Current Observer Box
            selectedRacers.ForEach(rac => AvailableRacers.Items.Add(rac));
        }
    }

    internal static class Prompt
    {
        // Look I took the popup box from some rando stackoverflow, fight me
        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new() { Left = 50, Top = 20, Text = text };
            TextBox textBox = new() { Left = 50, Top = 50, Width = 400 };
            Button confirmation = new() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }
}

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

        private void ActivateObserver(object sender, EventArgs e)
        {
        }


        private void BigScreenAdd(object sender, EventArgs e)
        {
            BigScreen screen = new BigScreen(Prompt.ShowDialog("Name", "Big Screen Display Setup"));
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
                foreach (SharedClasses.Racer c in screen.Racers.Keys)
                {
                    this.CurrentObserverBox.Items.Add(c);
                }
                var available = from r in this.racers.Values
                                where !screen.Racers.ContainsKey(r)
                                select r;

                foreach (var racer in available)
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
    }

    internal static class Prompt
    {
        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }
}

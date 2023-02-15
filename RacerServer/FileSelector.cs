using System.Security;

namespace RacerServer
{
    public partial class FileSelector : Form
    {
        public FileSelector()
        {
            InitializeComponent();

            this.KeyPreview = true;
            this.KeyDown += (sender, keys) =>
            {
                if (keys.KeyData == Keys.Enter) button4.PerformClick();
            };
        }

        public string RacerCSVPath { get; set; } = "";
        public string GroupCSVPath { get; set; } = "";
        public string SensorCSVPath { get; set; } = "";


        private string Add_Dialog(object sender, EventArgs e, TextBox box)
        {
            OpenFileDialog fileDialog = new()
            {
                FileName = "Select a csv",
                Filter = "CSV Files (*csv)|*csv",
                Title = "Select CSV"
            };
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    box.Text = fileDialog.FileName;
                    return fileDialog.FileName;
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
            return "";
        }

        private void button1_click(object sender, EventArgs e)
        {
            this.RacerCSVPath = Add_Dialog(sender, e, textBox1);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.GroupCSVPath = Add_Dialog(sender, e, textBox2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.SensorCSVPath = Add_Dialog(sender, e, textBox3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.RacerCSVPath = textBox1.Text;
            this.GroupCSVPath = textBox2.Text;
            this.SensorCSVPath = textBox3.Text;
            this.Close();
        }
    }
}
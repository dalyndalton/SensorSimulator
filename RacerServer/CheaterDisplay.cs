using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RacerServer
{
    public partial class CheaterDisplay : Form, IObserver<CheaterComputer>
    {
        public string ObsName { get; set; }
        public CheaterDisplay(string name)
        {
            InitializeComponent();

            this.Text = name;
            this.ObsName= name;
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

        public void OnNext(CheaterComputer value)
        {
            this.Invoke(UpdateList, value);
        }

        public void UpdateList(CheaterComputer value)
        {
            // Filter and find the current cheater list
            var display_list = this.CheaterList.Items.Cast<ListViewItem>().ToList();
            var current_cheaters = from item in display_list
                                   select item.Tag;

            var new_cheaters = from cheater in value.Cheaters
                               where !current_cheaters.Contains(cheater)
                               select cheater;

            // Process list of new values
            foreach (var cheater in new_cheaters)
            {
                var item = new ListViewItem() {
                    Text = cheater.sensor.ToString(),
                    Tag = cheater,
                };

                item.SubItems.Add(new ListViewItem.ListViewSubItem()
                {
                    Text = cheater.r1.Name
                });
                item.SubItems.Add(new ListViewItem.ListViewSubItem()
                {
                    Text = cheater.r2.Name
                });

                this.CheaterList.Items.Add(item);
            }
        }
        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
    }
}

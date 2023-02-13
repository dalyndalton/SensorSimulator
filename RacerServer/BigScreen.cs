using SharedClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            this.Name = name;
            this.Text = name;
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
            if (!Racers.Keys.Contains(value))
            {
                this.listView1.Items.Add(new ListViewItem()
                {
                    Text = value.Name,
                    Tag = value,
                });
            }
        }

        private void BigScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
    }
}

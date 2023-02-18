using RacerServer;
using SharedClasses;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacerTests
{
    public class FormTesting
    {
        [Fact]
        [STAThread]
        public void CreateandUpdateDisplay()
        {
            // Setup
            var display = new RacerDisplay("Testing");
            display.Show();
            var racer = new Racer("Bob", 24, new RaceGroup("G1", 1, 0, 0, 100));

            display.SubscribeToRacer(racer);  // we flip flop roles here to store the callback

            racer.UpdateRacerPosition(5);
            racer.UpdateRacerSensor(1, 1000000);

            // Test successful subscribe
            Assert.True(display.Racers.Count== 1);

            // Test unsubscribe
            display.UnsubscribeToRacer(racer);
            Assert.True(display.Racers.Count == 0);
        }
    }
}
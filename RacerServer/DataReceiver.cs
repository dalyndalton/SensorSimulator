using Messages;
using SharedClasses;
using System.Net;
using System.Net.Sockets;

namespace RacerServer
{
    public class DataReceiver
    {
        private UdpClient udpClient;
        private bool keepGoing;
        private Thread myRunThread;

        public DataReceiver(Dictionary<int, Racer> racers, Dictionary<int, RaceGroup> groups, Dictionary<int, int> sensors)
        {
            this.racers = racers;
            this.groups = groups;
            this.sensors = sensors;
            this.positionTracker = new();
        }

        private Dictionary<int, Racer> racers { get; set; }
        private Dictionary<int, RaceGroup> groups { get; set; }
        private Dictionary<int, int> sensors { get; set; }
        private Dictionary<RaceGroup, List<Racer>> positionTracker { get; set; }

        public void Start()
        {
            udpClient = new UdpClient(14000);
            keepGoing = true;

            foreach (KeyValuePair<int, RaceGroup> g in groups)
            {
                positionTracker.Add(g.Value, new List<Racer>());
            }

            foreach (var racer in racers.Values)
            {
                positionTracker[racer.RaceGroup].Add(racer);
            }


            myRunThread = new Thread(new ThreadStart(Run));
            myRunThread.Start();
        }

        public void Stop()
        {
            keepGoing = false;
        }

        private void Run()
        {
            while (keepGoing)
            {
                IPEndPoint ep = new(IPAddress.Any, 0);
                udpClient.Client.ReceiveTimeout = 1000;
                byte[] messageByes;
                try
                {
                    messageByes = udpClient.Receive(ref ep);
                    if (messageByes != null)
                    {
                        RacerStatus statusMessage = RacerStatus.Decode(messageByes);
                        if (statusMessage != null)
                        {

                            // Update Racer & Internal Position
                            if (!racers.TryGetValue(statusMessage.RacerBibNumber, out Racer? racer)) Console.WriteLine($"Invalid Bib: #={statusMessage.RacerBibNumber}");
                            else
                            {
                                // Debug console
                                //Console.Write("Race Bib #={0}, Sensor={1}, Time={2}, Position={3}\r",
                                //        statusMessage.RacerBibNumber,
                                //        statusMessage.SensorId,
                                //        statusMessage.Timestamp,
                                //        p);

                                racer.UpdateRacerSensor(statusMessage.SensorId, statusMessage.Timestamp);

                                // Positional updates
                                var standings = positionTracker[racer.RaceGroup];
                                standings.Sort((r1, r2) => r1.CompareTo(r2));

                                var postion = 1;
                                for (int i = 0; i < standings.Count; i++)
                                {
                                        standings[i].UpdateRacerPosition(postion);
                                        postion++;
                                }
                        }
                        }
                    }
                }
                catch (SocketException err)
                {
                    if (err.SocketErrorCode != SocketError.Interrupted && err.SocketErrorCode != SocketError.TimedOut)
                        throw err;
                }
            }
        }
    }
}

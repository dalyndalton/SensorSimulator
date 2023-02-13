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
        private Dictionary<int, Dictionary<RaceGroup, int>> positionTracker { get; set; }
        public void Start()
        {
            udpClient = new UdpClient(14000);
            keepGoing = true;

            Dictionary<RaceGroup, int> tracker = new Dictionary<RaceGroup, int>();
            foreach (var g in groups)
            {
                tracker.Add(g.Value, 1);
            }

            // Build the postion board
            foreach (var s in sensors)
            {
                positionTracker.Add(s.Key, new Dictionary<RaceGroup, int>(tracker));
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
                IPEndPoint ep = new IPEndPoint(IPAddress.Any, 0);
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
                            if (!racers.TryGetValue(statusMessage.RacerBibNumber, out var racer)) Console.WriteLine($"Invalid Bib: #={statusMessage.RacerBibNumber}");
                            else
                            {
                                int p = positionTracker[statusMessage.SensorId][racer.RaceGroup]++;
                                // Debug console
                                //Console.Write("Race Bib #={0}, Sensor={1}, Time={2}, Position={3}\r",
                                //        statusMessage.RacerBibNumber,
                                //        statusMessage.SensorId,
                                //        statusMessage.Timestamp,
                                //        p);
                                racer.UpdateRacer(statusMessage.SensorId, statusMessage.Timestamp, p);
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

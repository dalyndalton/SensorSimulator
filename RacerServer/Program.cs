namespace RacerServer
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DataReceiver reciever = new DataReceiver();
            reciever.Start();

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}
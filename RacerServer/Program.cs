using Microsoft.VisualBasic.FileIO;
using SharedClasses;

namespace RacerServer
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {

            Dictionary<int, Racer> racers = new();
            Dictionary<int, RaceGroup> groups = new();
            Dictionary<int, int> sensors = new();

            ApplicationConfiguration.Initialize();
            DataReceiver reciever = new();

            FileSelector fileSelector = new FileSelector();
            Application.Run(fileSelector);


            // Load in CSV's here
            using (TextFieldParser parser = new TextFieldParser(fileSelector.GroupCSVPath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    try
                    {
                        string[] fields = parser.ReadFields();
                        RaceGroup group = RaceGroup.parseRaceGroup(fields);
                        groups.Add(Int32.Parse(fields[0]), group);
                    }
                    catch (MalformedLineException e)
                    {
                        Console.WriteLine(e);
                    }
                }
            }

            using (TextFieldParser parser = new TextFieldParser(fileSelector.RacerCSVPath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    try
                    {
                        string[] fields = parser.ReadFields();
                        Racer racer = Racer.parseRacer(fields, groups);
                        racers.Add(racer.BibId, racer);
                    }
                    catch (MalformedLineException e)
                    {
                        Console.WriteLine(e);
                    }
                }
            }

            using (TextFieldParser parser = new TextFieldParser(fileSelector.SensorCSVPath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    try
                    {
                        string[] fields = parser.ReadFields();
                        sensors.Add(Int32.Parse(fields[0]), Int32.Parse(fields[1]));
                    }
                    catch (MalformedLineException e)
                    {
                        Console.WriteLine(e);
                    }
                }
            }


            // Start main file listener here
            reciever.Start(racers, groups, sensors);
        }
    }
}
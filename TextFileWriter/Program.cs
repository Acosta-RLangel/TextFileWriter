using System;
using System.IO;
using System.Timers;

namespace TextFileWriter
{

    class Program
    {
        static int counter = 1;
        static Timer aTimer;

        static void Main(string[] args)
        {
            SetTimer();
            WriteLogFile("TextLogger starting up!!");

            Console.WriteLine("\nPress enter key to terminate application...\n");
            Console.ReadLine();

            aTimer.Stop();
            aTimer.Dispose();

            WriteLogFile("Shutting down now!");
        }

        private static void SetTimer()
        {
            // Create a timer with a two second interval.
            aTimer = new Timer(3000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        static void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            string message = string.Format("Event number {0}", counter);
            WriteLogFile(message);
            counter++;
        }

        static void WriteLogFile(string message)
        {
            //string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string mydocpath = "/app";
            var formattedMessage = string.Format("{0}  ::  {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), message);

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(mydocpath, "logfile.txt"), true))
            {
                outputFile.WriteLine(formattedMessage);
            }

            Console.WriteLine(formattedMessage);
        }
    }
}

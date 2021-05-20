using System;
using System.IO;
using System.Net;

namespace EasyMinerUpdater
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Error! No args provided.");
                return;
            }
            string path = args[0];
            Console.WriteLine("Updating, please wait...");
            System.Threading.Thread.Sleep(5000);

            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                using (var client = new WebClient())
                {
                    client.DownloadFile("https://uplexapool.com/EasyMiner.exe", path);
                }
            }
            catch (Exception err)
            {
                Console.WriteLine("Error updating: " + err.Message);
                Console.ReadLine();
            }
            System.Diagnostics.Process.Start(path);
        }
    }
}

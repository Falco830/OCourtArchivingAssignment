using System;
using System.IO;

namespace OcourtArchiving
{
    class Program
    {
        static void Main(string[] args)
        {
            //String key = "City";
            String city = "SeaTac";
            writeTextToTemp(city);

        }
        public static void writeTextToTemp(String city)
        {
            //name file
            string path = @"c:\temp\" + city + "_" + DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss") + ".txt";
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    //add/write random number to first line of file
                    Random random = new Random();
                    sw.WriteLine(random.Next(1, 1000));
                }
            }
            CityNames.cityName(city, path);
            // Open the file to read from.
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
        }
    }

    public class CityNames
    {
        public static void cityName(String city, String path)
        {
            switch (city)
            {
                case "Pasco":
                    CityTasks.pascoTask(path);
                    break;
                case "SeaTac":
                    CityTasks.seatacTask();
                    break;
            }
        }
    }
    public class CityTasks
    {
        public static void pascoTask(String path)
        {
            if (File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.AppendText(path))
                {
                    // add/write random number to first line of file
                    Random random = new Random();
                    sw.WriteLine(random.Next(1, 1000) + " Pasco");
                }
            }
        }
        public static void seatacTask()
        {
            String path = @"c:\temp\Random.txt";
            Random random = new Random();
            if (!File.Exists(path))
            {
                // Create a file to write to
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(random.Next(1, 1000));
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(random.Next(1, 1000));
                }
            }
        }
    }
    public interface cityLabelTasks
    {
        static void seatacTask();

        static void pascoTask();

    }
}

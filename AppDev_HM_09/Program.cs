using System;
using System.IO;
using System.Text.Json;
using System.Xml.Linq;

namespace AppDev_HM_09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            args = new string[] { $@"{Environment.CurrentDirectory}\Example.json" };
            if (args.Length < 1)
            {
                Console.WriteLine("Не указан путь к файлу JSON.");
                return;
            }

            string jsonFilePath = args[0];

            JsonXmlConverter converter = new JsonXmlConverter();
            converter.ConvertJsonToXml(jsonFilePath);
            Console.ReadLine();
        }
    }
}
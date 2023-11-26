using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDev_HM_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //args = new string[] { "txt", "куку"};
            if (args.Length < 2)
            {
                Console.WriteLine("Неверное количество аргументов. Укажите расширение файла и текст для поиска.");
                return;
            }

            string extension = args[0];
            string searchText = args[1];

            Console.WriteLine($"Поиск файлов с расширением '{extension}' и содержащих текст: '{searchText}'");

            FileSearcher fileSearcher = new FileSearcher();
            fileSearcher.SearchFiles(Environment.CurrentDirectory, extension, searchText);
            Console.ReadLine();
        }
    }
}

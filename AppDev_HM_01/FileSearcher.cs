using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDev_HM_01
{
    public class FileSearcher
    {
        public void SearchFiles(string directory, string extension, string searchText)
        {
            try
            {
                var files = Directory.GetFiles(directory, $"*.{extension}", SearchOption.AllDirectories);
                Console.WriteLine($"Поиск ...");
                bool found = false;
                foreach (var file in files)
                {
                    try
                    {
                        string content = File.ReadAllText(file);
                        if (content.Contains(searchText))
                        {
                            Console.WriteLine($"Найден файл: {file}");
                            found = true;
                        }
                    }
                    catch (UnauthorizedAccessException)
                    {
                        Console.WriteLine($"Отказано в доступе: {file}");
                    }
                    catch (FileNotFoundException)
                    {
                        Console.WriteLine($"Файл не найден: {file}");
                    }
                    catch (IOException ex)
                    {
                        Console.WriteLine($"Ошибка ввода-вывода: {ex.Message}");
                    }
                }
                if (!found)
                {
                    Console.WriteLine($"Не найдено файлов с расширением '{extension}' и содержащих текст: '{searchText}'");
                }
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine($"Указанный каталог не найден. {directory}");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine($"Отказано в доступе к указанному каталогу. {directory}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Ошибка ввода-вывода: {ex.Message}");
            }
        }
    }
}

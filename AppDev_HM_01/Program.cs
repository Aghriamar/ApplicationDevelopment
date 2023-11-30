using System;
using System.IO;
using System.Xml.Linq;
using System.Text.JSon;

namespace AppDev_HM_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Не указан путь к файлу JSON.");
                return;
            }

            string jsonFilePath = args[0];

            if (!File.Exists(jsonFilePath))
            {
                Console.WriteLine("Указанный файл JSON не найден.");
                return;
            }

            try
            {
                string jsonContent = File.ReadAllText(jsonFilePath);

                using (JsonDocument doc = JsonDocument.Parse(jsonContent))
                {
                    // Создаем корневой элемент XML
                    XElement xmlRoot = new XElement("Root");

                    foreach (JsonProperty prop in doc.RootElement.EnumerateObject())
                    {
                        // Добавляем элементы XML, соответствующие полям JSON
                        XElement xmlElement = new XElement(prop.Name, prop.Value.ToString());
                        xmlRoot.Add(xmlElement);
                    }

                    // Сохраняем XML в файл
                    string xmlFilePath = Path.ChangeExtension(jsonFilePath, ".xml");
                    xmlRoot.Save(xmlFilePath);
                    Console.WriteLine($"Конвертация успешно завершена. Файл сохранен по пути: {xmlFilePath}");
                }
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Ошибка при парсинге JSON: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }
    }
}

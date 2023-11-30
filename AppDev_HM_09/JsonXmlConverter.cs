using System;
using System.IO;
using System.Text.Json;
using System.Xml.Linq;

namespace AppDev_HM_09
{
    /// <summary>
    /// Класс, предназначенный для конвертации файла JSON в формат XML.
    /// </summary>
    public class JsonXmlConverter
    {
        /// <summary>
        /// Конвертирует файл JSON в XML.
        /// </summary>
        /// <param name="jsonFilePath">Путь к файлу JSON.</param>
        public void ConvertJsonToXml(string jsonFilePath)
        {
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
                    XElement xmlRoot = new XElement("Root");

                    ProcessJsonValue(doc.RootElement, xmlRoot);

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

        /// <summary>
        /// Метод обработки значения JSON.
        /// </summary>
        /// <param name="value">Элемент значения JSON.</param>
        /// <param name="parent">Родительский элемент XML.</param>
        private void ProcessJsonValue(JsonElement value, XElement parent)
        {
            if (value.ValueKind == JsonValueKind.Object)
            {
                foreach (var property in value.EnumerateObject())
                {
                    if (property.Value.ValueKind == JsonValueKind.Object)
                    {
                        XElement element = new XElement(property.Name);
                        parent.Add(element);
                        ProcessJsonValue(property.Value, element);
                    }
                    else if (property.Value.ValueKind == JsonValueKind.Array)
                    {
                        ProcessJsonArray(property.Value, parent, property.Name);
                    }
                    else
                    {
                        parent.Add(new XElement(property.Name, property.Value.ToString()));
                    }
                }
            }
        }

        /// <summary>
        /// Метод обработки массива JSON.
        /// </summary>
        /// <param name="value">Элемент массива JSON.</param>
        /// <param name="parent">Родительский элемент XML.</param>
        /// <param name="arrayName">Имя массива.</param>
        private void ProcessJsonArray(JsonElement value, XElement parent, string arrayName)
        {
            foreach (var arrayElement in value.EnumerateArray())
            {
                if (arrayElement.ValueKind == JsonValueKind.Object)
                {
                    XElement element = new XElement(arrayName);
                    parent.Add(element);
                    ProcessJsonValue(arrayElement, element);
                }
                else if (arrayElement.ValueKind == JsonValueKind.Array)
                {
                    ProcessJsonArray(arrayElement, parent, arrayName);
                }
                else
                {
                    parent.Add(new XElement(arrayName, arrayElement.ToString()));
                }
            }
        }
    }

    /// <summary>
    /// Расширения для работы с JSON.
    /// </summary>
    public static class JsonExtensions
    {
        /// <summary>
        /// Получает имя свойства из JSON.
        /// </summary>
        /// <param name="element">Элемент JSON.</param>
        /// <returns>Имя свойства.</returns>
        public static string GetPropertyName(this JsonElement element)
        {
            if (element.TryGetProperty("name", out JsonElement name))
            {
                return name.GetString()?.Replace(' ', '_') ?? "JSON_Content";
            }
            return "JSON_Content";
        }
    }
}

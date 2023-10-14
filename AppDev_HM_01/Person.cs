using System;
using System.Collections.Generic;
using System.Globalization;
using static System.Net.Mime.MediaTypeNames;

namespace AppDev_HM_01
{
    /// <summary>
    /// Класс Person
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Представляет гендерную принадлежность (мужчина или женщина).
        /// </summary>
        public enum Gender
        {
            Male,
            Female
        }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname { get; private set; }
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime Birthday { get; private set; }
        /// <summary>
        /// Возраст
        /// </summary>
        public int Age { get; private set; }
        /// <summary>
        /// Пол
        /// </summary>
        public Gender Sex { get; private set; }
        /// <summary>
        /// Мать
        /// </summary>
        public Person Mother { get; private set; }
        /// <summary>
        /// Отец
        /// </summary>
        public Person Father { get; private set; }
        /// <summary>
        /// Супруг(а)
        /// </summary>
        public Person Spouse { get; private set; }
        /// <summary>
        /// Дети
        /// </summary>
        public List<Person> Children { get; private set; }
        /// <summary>
        /// Братья или сестры
        /// </summary>
        public List<Person> Siblings { get; private set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса Person с заданными данными.
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="birthday">Дата рождения</param>
        /// <param name="sex">Пол</param>
        public Person(string name, string surname, DateTime birthday, Gender sex) 
        {
            this.Name = name;
            this.Surname = surname;
            this.Birthday = birthday;
            Age = CalculateAge(birthday);
            this.Sex = sex;
            Siblings = new List<Person>();
            Children = new List<Person>();
        }

        /// <summary>
        /// Возвращает дату рождения в формате "дд.мм.гггг".
        /// </summary>
        /// <returns>Дата рождения в формате "дд.мм.гггг".</returns>
        public string GetBirthday()
        {
            return Birthday.ToString("dd.MM.yyyy");
        }

        /// <summary>
        /// Устанавливает дату рождения на основе строки с заданным форматом.
        /// </summary>
        /// <param name="formattedBirthday">Дата рождения в формате "дд.мм.гггг".</param>
        /// <exception cref="ArgumentException">Выбрасывается, если формат даты неверен.</exception>
        public void SetBirthday(string formattedBirthday)
        {
            if (DateTime.TryParseExact(formattedBirthday, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsedBirthday))
            {
                Birthday = parsedBirthday;
            }
            else
            {
                throw new ArgumentException("Неверный формат даты рождения. Используйте формат 'дд.мм.гггг'.");
            }
        }

        /// <summary>
        /// Рассчитывает возраст на основе даты рождения.
        /// </summary>
        /// <param name="birthday">Дата рождения.</param>
        /// <returns>Возраст.</returns>
        private int CalculateAge(DateTime birthday)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthday.Year;
            if (birthday > today.AddYears(-age))
            {
                age--;
            }
            return age;
        }

        /// <summary>
        /// Заключает брак между текущей персоной и указанным супругом/супругой.
        /// </summary>
        /// <param name="spouse">Супруг/супруга.</param>
        public void Marry(Person spouse)
        {
            Spouse = spouse;
            spouse.Spouse = this;
        }

        /// <summary>
        /// Добавляет ребенка в список детей текущей персоны и устанавливает текущую персону как мать (и, возможно, отца) ребенка.
        /// </summary>
        /// <param name="child">Ребенок для добавления.</param>
        public void AddChild(Person child)
        {
            Children.Add(child);
            child.Mother = this;
            if (Sex == Gender.Male)
                child.Father = this;
        }

        /// <summary>
        /// Добавляет брата или сестру в список братьев и сестер текущей персоны и обратно.
        /// </summary>
        /// <param name="sibling">Брат или сестра для добавления.</param>
        public void AddSibling(Person sibling)
        {
            Siblings.Add(sibling);
            sibling.Siblings.Add(this);
        }

        /// <summary>
        /// Выводит генеалогическое дерево текущей персоны и ее родственников.
        /// </summary>
        /// <param name="level">Уровень вложенности при выводе дерева.</param>
        /// <param name="printedPersons">Множество уже выведенных персон.</param>
        /// <param name="relationship">Отношение текущей персоны к предыдущей (например, "Сын" или "Дочь").</param>
        public void PrintFamilyTree(int level, HashSet<Person> printedPersons = null, string relationship = null)
        {
            if (printedPersons == null)
            {
                printedPersons = new HashSet<Person>();
            }

            string prefix = new string('|', level) + new string('-', 3);
            string personInfo = $"{Name}, {Age} лет";
            if (relationship != null)
            {
                personInfo += $" {relationship}";
            }
            Console.WriteLine($"{prefix} {personInfo}");

            printedPersons.Add(this);

            foreach (var child in Children)
            {
                if (!printedPersons.Contains(child))
                {
                    string childRelationship = child.Sex == Gender.Female ? "Дочь" : "Сын";
                    child.PrintFamilyTree(level + 1, printedPersons, childRelationship);
                }
            }

            foreach (var sibling in Siblings)
            {
                if (!printedPersons.Contains(sibling))
                {
                    string siblingRelationship = sibling.Sex == Gender.Female ? "Сестра" : "Брат";
                    sibling.PrintFamilyTree(level, printedPersons, siblingRelationship);
                }
            }
        }
    }
}

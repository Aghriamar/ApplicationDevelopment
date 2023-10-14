using System;
using System.Collections.Generic;
using static AppDev_HM_01.Person;

namespace AppDev_HM_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var familyMembers = new List<Person>();

            // Прадедушка и прабабушка по папиной линии
            var paternalGrandfather = new Person("George", "Johnson", new DateTime(1930, 5, 10), Person.Gender.Male);
            var paternalGrandmother = new Person("Eleanor", "Johnson", new DateTime(1935, 8, 20), Person.Gender.Female);

            // Прадедушка и прабабушка по маминой линии
            var maternalGrandfather = new Person("Robert", "Smith", new DateTime(1932, 12, 15), Person.Gender.Male);
            var maternalGrandmother = new Person("Mary", "Smith", new DateTime(1938, 7, 5), Person.Gender.Female);

            // Папа и мама
            var father = new Person("John", "Doe", new DateTime(1960, 4, 25), Person.Gender.Male);
            var mother = new Person("Alice", "Doe", new DateTime(1965, 11, 3), Person.Gender.Female);

            // Семья папы
            paternalGrandfather.AddChild(father);
            paternalGrandmother.AddChild(father);

            // Семья мамы
            maternalGrandfather.AddChild(mother);
            maternalGrandmother.AddChild(mother);

            // Сын и дочь (дети папы и мамы)
            var son = new Person("David", "Doe", new DateTime(1985, 9, 12), Person.Gender.Male);
            var daughter = new Person("Sophia", "Doe", new DateTime(1990, 2, 18), Person.Gender.Female);

            father.AddChild(son);
            father.AddChild(daughter);
            mother.AddChild(son);
            mother.AddChild(daughter);

            // Брат и сестра (дети папы и мамы)
            var brother = new Person("Michael", "Doe", new DateTime(1988, 6, 7), Person.Gender.Male);
            var sister = new Person("Olivia", "Doe", new DateTime(1992, 12, 30), Person.Gender.Female);

            father.AddChild(brother);
            father.AddChild(sister);
            mother.AddChild(brother);
            mother.AddChild(sister);

            // Дядя по папиной линии
            var uncle = new Person("Richard", "Doe", new DateTime(1970, 3, 14), Person.Gender.Male);
            father.AddSibling(uncle);

            // Тётя по маминой линии
            var aunt = new Person("Laura", "Smith", new DateTime(1972, 8, 25), Person.Gender.Female);
            mother.AddSibling(aunt);

            // Племянник и племянница
            var nephew = new Person("Henry", "Doe", new DateTime(2010, 7, 28), Person.Gender.Male);
            var niece = new Person("Lily", "Doe", new DateTime(2013, 11, 9), Person.Gender.Female);

            brother.AddChild(nephew);
            sister.AddChild(niece);

            // Добавляем всех членов семьи в список
            familyMembers.AddRange(new List<Person>
            {
                paternalGrandfather, paternalGrandmother, maternalGrandfather, maternalGrandmother,
                father, mother, son, daughter, brother, sister, uncle, aunt, nephew, niece
            });
            father.PrintFamilyTree(0);

            Console.ReadLine();
        }
    }
}

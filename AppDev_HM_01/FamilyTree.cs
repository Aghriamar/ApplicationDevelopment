using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDev_HM_01
{
    /// <summary>
    /// Представляет собой генеалогическое дерево с набором персон.
    /// </summary>
    public class FamilyTree
    {
        /// <summary>
        /// Список персон в генеалогическом дереве.
        /// </summary>
        public List<Person> Persons { get; private set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса FamilyTree с заданным списком персон.
        /// </summary>
        /// <param name="persons">Список персон, представляющих генеалогическое дерево.</param>
        public FamilyTree(List<Person> persons)
        {
            Persons = persons;
        }

        /// <summary>
        /// Находит и возвращает список детей для заданной персоны-родителя.
        /// </summary>
        /// <param name="parent">Персона-родитель, для которой нужно найти детей.</param>
        /// <returns>Список детей данной персоны.</returns>
        public List<Person> FindChildren(Person parent)
        {
            List<Person> children = new List<Person>();
            foreach (var person in Persons)
            {
                if (person != parent && person.Spouse == parent)
                {
                    children.Add(person);
                }
            }
            return children;
        }

        /// <summary>
        /// Находит и возвращает супруга/супругу для заданной персоны.
        /// </summary>
        /// <param name="person">Персона, для которой нужно найти супруга/супругу.</param>
        /// <returns>Супруг/супруга данной персоны, или null, если супруг/супруга нет.</returns>
        public Person FindSpouse(Person person)
        {
            foreach (var p in Persons)
            {
                if (p != person && p.Spouse == person)
                {
                    return p;
                }
            }
            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace AppDev_HM_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите искомую сумму:");
            if (int.TryParse(Console.ReadLine(), out int targetSum))
            {
                HashSet<int> hashSet = GenerateRandomHashSet(20);
                PrintHashSet(hashSet);
                List<int> hashSetList = hashSet.ToList();
                var result = FindThreeNumbersWithSum(hashSetList, targetSum);
                if (result != null)
                {
                    Console.WriteLine($"Найдены три числа: {result[0]}, {result[1]}, {result[2]}");
                }
                else
                {
                    Console.WriteLine("Тройки чисел с указанной суммой не найдены.");
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод суммы.");
            }
            Console.ReadLine();
        }

        /// <summary>
        /// Генерирует случайный HashSet из указанного количества чисел.
        /// </summary>
        /// <param name="count">Количество чисел в HashSet.</param>
        /// <returns>Сгенерированный HashSet.</returns>
        static HashSet<int> GenerateRandomHashSet(int count)
        {
            Random random = new Random();
            HashSet<int> hashSet = new HashSet<int>();
            while (hashSet.Count < count)
            {
                hashSet.Add(random.Next(1, 100));
            }
            return hashSet;
        }

        /// <summary>
        /// Выводит элементы HashSet в консоль.
        /// </summary>
        /// <param name="hashSet">Входной HashSet.</param>
        static void PrintHashSet(HashSet<int> hashSet)
        {
            Console.WriteLine("Случайный HashSet:");
            Console.WriteLine(string.Join(" ", hashSet));
        }

        /// <summary>
        /// Ищет тройки чисел в списке, сумма которых равна заданной целевой сумме.
        /// </summary>
        /// <param name="list">Список целых чисел.</param>
        /// <param name="targetSum">Целевая сумма.</param>
        /// <returns>Массив с тремя числами, сумма которых равна целевой 
        /// сумме, или null, если такие числа не найдены.</returns>
        static int[] FindThreeNumbersWithSum(List<int> list, int targetSum)
        {
            for (int i = 0; i < list.Count - 2; i++)
            {
                for (int j = i + 1; j < list.Count - 1; j++)
                {
                    for (int k = j + 1; k < list.Count; k++)
                    {
                        if (list[i] + list[j] + list[k] == targetSum)
                        {
                            return new int[] { list[i], list[j], list[k] };
                        }
                    }
                }
            }
            return null;
        }
    }
}

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
            Console.WriteLine("Простой калькулятор");
            Console.WriteLine("Для завершения программы введите 'отмена' или пустую строку.");

            while (true)
            {
                Console.Write("Введите первое число: ");
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Программа завершена.");
                    break;
                }

                if (input.ToLower() == "отмена")
                {
                    Console.WriteLine("Программа отменена.");
                    break;
                }

                if (!DoubleTryParse(input, out double num1))
                {
                    continue;
                }

                Console.Write("Введите оператор (+, -, *, /): ");
                string operation = Console.ReadLine();

                if (string.IsNullOrEmpty(operation))
                {
                    Console.WriteLine("Программа завершена.");
                    break;
                }

                if (operation.ToLower() == "отмена")
                {
                    Console.WriteLine("Программа отменена.");
                    break;
                }

                Console.Write("Введите второе число: ");
                input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Программа завершена.");
                    break;
                }

                if (input.ToLower() == "отмена")
                {
                    Console.WriteLine("Программа отменена.");
                    break;
                }

                if (!DoubleTryParse(input, out double num2))
                {
                    continue;
                }

                double result = 0;

                try
                {
                    result = Calculator.Calculate(num1, num2, operation);
                    Console.WriteLine($"Результат: {num1} {operation} {num2} = {result}");
                }
                catch (CalculationException ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            }
        }

        private static bool DoubleTryParse(string input, out double result)
        {
            bool success = double.TryParse(input, out result);

            if (!success)
            {
                Console.WriteLine("Неверный формат числа.");
            }

            return success;
        }
    }
}
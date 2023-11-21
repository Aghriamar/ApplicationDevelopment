using System;

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

                if (!double.TryParse(input, out double num1))
                {
                    Console.WriteLine("Неверный формат числа.");
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

                if (!double.TryParse(input, out double num2))
                {
                    Console.WriteLine("Неверный формат числа.");
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
    }
}
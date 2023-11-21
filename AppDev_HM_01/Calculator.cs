using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDev_HM_01
{
    public class Calculator
    {
        public static double Calculate(double num1, double num2, string operation)
        {
            switch (operation)
            {
                case "+":
                    return num1 + num2;
                case "-":
                    if (num1 < num2)
                    {
                        throw new CalculationException("Результат не может быть отрицательным.");
                    }
                    return num1 - num2;
                case "*":
                    return num1 * num2;
                case "/":
                    if (num2 == 0)
                    {
                        throw new CalculationException("Деление на ноль невозможно.");
                    }
                    if (num1 < num2)
                    {
                        throw new CalculationException("Результат не может быть отрицательным.");
                    }
                    return num1 / num2;
                default:
                    throw new CalculationException("Неверный оператор.");
            }
        }
    }

    public class CalculationException : Exception
    {
        public CalculationException(string message) : base(message)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDev_HM_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] labirynth1 = new int[,]
            {
                {1, 1, 1, 1, 1, 1, 1 },
                {1, 0, 0, 0, 0, 0, 1 },
                {1, 0, 1, 1, 1, 0, 1 },
                {0, 0, 0, 0, 1, 0, 0 },
                {1, 1, 0, 0, 1, 1, 1 },
                {1, 1, 1, 0, 1, 1, 1 },
                {1, 1, 1, 0, 1, 1, 1 }
            };
            Console.WriteLine($"Количество выходов в лабиринте: {CountExits(3, 6, labirynth1)}");
            Console.ReadLine();
        }

        static int CountExits(int startI, int startJ, int[,] labirynth)
        {
            int rows = labirynth.GetLength(0);
            int cols = labirynth.GetLength(1);
            int exitCount = 0;
            Stack<Tuple<int, int>> stack = new Stack<Tuple<int, int>>();
            stack.Push(new Tuple<int, int>(startI, startJ));
            while (stack.Count > 0)
            {
                var current = stack.Pop();
                int i = current.Item1;
                int j = current.Item2;
                if ((i == 0 || i == rows - 1 || j == 0 || j == cols - 1) && (i != startI || j != startJ))
                {
                    exitCount++;
                }
                labirynth[i, j] = 1;
                int[] rowDirections = { -1, 1, 0, 0 };
                int[] colDirections = { 0, 0, -1, 1 };
                for (int d = 0; d < 4; d++)
                {
                    int newRow = i + rowDirections[d];
                    int newCol = j + colDirections[d];
                    if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols && labirynth[newRow, newCol] == 0)
                    {
                        stack.Push(new Tuple<int, int>(newRow, newCol));
                    }
                }
            }
            return exitCount;
        }
    }
}

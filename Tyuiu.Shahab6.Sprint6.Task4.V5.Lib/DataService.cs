using System;
using System.IO;
using tyuiu.cources.programming.interfaces.Sprint6;

namespace Tyuiu.Shahab6.Sprint6.Task4.V5.Lib
{
    public class DataService : ISprint6Task4V5
    {
        public DataService()
        {
        }

        public double[] GetMassFunction(int startValue, int stopValue)
        {
            int length = stopValue - startValue + 1;
            double[] valueArray = new double[length];

            int count = 0;
            for (int x = startValue; x <= stopValue; x++)
            {
                try
                {
                    // F(x) = (2*sin(x))/(3x+1.2) + cos(x) - 7x*2
                    double denominator = 3 * x + 1.2;

                    // Проверка деления на ноль
                    if (Math.Abs(denominator) < 0.0001)
                    {
                        valueArray[count] = 0;
                    }
                    else
                    {
                        double term1 = (2 * Math.Sin(x)) / denominator;
                        double term2 = Math.Cos(x);
                        double term3 = 7 * x * 2; // или 14x

                        double result = term1 + term2 - term3;
                        valueArray[count] = Math.Round(result, 2);
                    }
                }
                catch
                {
                    valueArray[count] = 0;
                }
                count++;
            }

            return valueArray;
        }

        public string SaveToFile(string path, int startValue, int stopValue)
        {
            double[] values = GetMassFunction(startValue, stopValue);

            string filePath = path;

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("Таблица значений функции:");
                writer.WriteLine("F(x) = (2*sin(x))/(3x+1.2) + cos(x) - 14x");
                writer.WriteLine("Диапазон: [{0}; {1}]", startValue, stopValue);
                writer.WriteLine("--------------------------");
                writer.WriteLine("   X   |   F(x)");
                writer.WriteLine("--------------------------");

                int count = 0;
                for (int x = startValue; x <= stopValue; x++)
                {
                    writer.WriteLine("  {0,3}  |  {1,7}", x, values[count]);
                    count++;
                }
            }

            return filePath;
        }
    }
}
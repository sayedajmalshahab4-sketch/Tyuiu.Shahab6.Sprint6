using System;
using tyuiu.cources.programming.interfaces.Sprint6;

namespace Tyuiu.Shahab6.Sprint6.Task1.V23.Lib
{
    public class DataService : ISprint6Task2V20
    {
        public DataService()
        {
        }

        public double[] GetMassFunction(int startValue, int stopValue)
        {
            int len = stopValue - startValue + 1;
            double[] valueArray = new double[len];

            int count = 0;
            for (int x = startValue; x <= stopValue; x++)
            {
                // Вычисляем значение функции: F(x) = sin(x) + (2x/3) - cos(x) * 4x
                // Проверка деления на ноль - в данном случае нет деления, но оставляем шаблон
                double denominator = 3; // знаменатель для 2x/3

                if (Math.Abs(denominator) < 0.0001)
                {
                    valueArray[count] = 0;
                }
                else
                {
                    double sinX = Math.Sin(x);
                    double term1 = sinX;
                    double term2 = (2 * x) / denominator; // 2x/3
                    double term3 = Math.Cos(x) * 4 * x; // cos(x) * 4x

                    double y = term1 + term2 - term3;

                    // Округление до двух знаков после запятой
                    valueArray[count] = Math.Round(y, 2);
                }

                count++;
            }

            return valueArray;
        }
    }
}
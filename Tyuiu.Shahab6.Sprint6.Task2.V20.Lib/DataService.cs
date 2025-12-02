using System;

namespace Tyuiu.Shahab6.Sprint6.Task2.V20.Lib
{
    public class DataService
    {
        public double[] GetMassFunction(int startValue, int stopValue)
        {
            int length = stopValue - startValue + 1;
            double[] valueArray = new double[length];

            int count = 0;
            for (int x = startValue; x <= stopValue; x++)
            {
                double denominator = x + 1.2;

                // Проверка деления на ноль
                if (Math.Abs(denominator) < 0.0001)
                {
                    valueArray[count] = 0;
                }
                else
                {
                    // F(x) = sin(x)/(x+1.2) - sin(x)*2 - 2x
                    double term1 = Math.Sin(x) / denominator;
                    double term2 = Math.Sin(x) * 2;
                    double term3 = 2 * x;

                    double result = term1 - term2 - term3;
                    valueArray[count] = Math.Round(result, 2);
                }
                count++;
            }

            return valueArray;
        }
    }
}
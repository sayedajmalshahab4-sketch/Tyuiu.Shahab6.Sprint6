using System;
using tyuiu.cources.programming.interfaces.Sprint6;

namespace Tyuiu.Shahab6.Sprint6.Task1.V23.Lib
{
    public class DataService : ISprint6Task0V23
    {
        public double Calculate(int x)
        {
            throw new NotImplementedException();
        }

        public double[] GetMassFunction(int startValue, int stopValue)
        {
            int length = stopValue - startValue + 1;
            double[] valueArray = new double[length];

            int count = 0;
            for (int x = startValue; x <= stopValue; x++)
            {
                double term1 = Math.Sin(x);
                double term2 = (2.0 * x) / 3.0;
                double term3 = Math.Cos(x) * 4 * x;

                double result = term1 + term2 - term3;
                valueArray[count] = Math.Round(result, 2);
                count++;
            }

            return valueArray;
        }
    }
}
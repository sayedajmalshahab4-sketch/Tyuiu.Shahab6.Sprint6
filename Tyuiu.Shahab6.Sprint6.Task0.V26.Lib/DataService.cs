using System;
using tyuiu.cources.programming.interfaces.Sprint6;

namespace Tyuiu.Shahab6.Sprint6.Task0.V26.Lib
{
    public class DataService : ISprint6Task0V26
    {
        public DataService()
        {
        }

        public double Calculate(int x)
        {
            double result = (Math.Pow(x, 2) + 1) / (3 * x + 4);
            return Math.Round(result, 3);
        }
    }
}
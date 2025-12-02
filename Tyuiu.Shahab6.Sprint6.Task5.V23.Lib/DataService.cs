using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using tyuiu.cources.programming.interfaces.Sprint6;

namespace Tyuiu.Shahab6.Sprint6.Task5.V23.Lib
{
    public class DataService : ISprint6Task4V23
    {
        public List<double> LoadFromDataFile(string path)
        {
            List<double> numbers = new List<double>();

            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (double.TryParse(line, out double number))
                        {
                            numbers.Add(Math.Round(number, 3));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка чтения файла: {ex.Message}");
            }

            return numbers;
        }

        public List<double> GetNegativeNumbers(List<double> numbers)
        {
            return numbers.Where(n => n < 0).ToList();
        }

        public int CountNegativeNumbers(List<double> numbers)
        {
            return numbers.Count(n => n < 0);
        }

        public int CountPositiveNumbers(List<double> numbers)
        {
            return numbers.Count(n => n >= 0);
        }

        public double[] GetMassFunction(int startValue, int stopValue)
        {
            throw new NotImplementedException();
        }
    }
}
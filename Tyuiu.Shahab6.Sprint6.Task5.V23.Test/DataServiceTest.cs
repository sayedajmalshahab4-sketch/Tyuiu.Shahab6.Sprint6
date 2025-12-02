using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using Tyuiu.Shahab6.Sprint6.Task5.V23.Lib;

namespace Tyuiu.Shahab6.Sprint6.Task5.V23.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void ValidLoadFromDataFile()
        {
            DataService ds = new DataService();

            // Создаем тестовый файл
            string testPath = @"C:\Temp\test_data.txt";
            string[] testData = { "12.345", "-5.678", "0", "-3.141", "7.890" };
            File.WriteAllLines(testPath, testData);

            List<double> result = ds.LoadFromDataFile(testPath);

            // Проверяем
            Assert.AreEqual(5, result.Count);
            Assert.AreEqual(12.345, result[0]);
            Assert.AreEqual(-5.678, result[1]);
            Assert.AreEqual(0, result[2]);

            // Удаляем тестовый файл
            File.Delete(testPath);
        }

        [TestMethod]
        public void ValidGetNegativeNumbers()
        {
            DataService ds = new DataService();

            List<double> numbers = new List<double> { 1.5, -2.3, 0, -4.7, 3.2, -1.1 };
            List<double> negativeNumbers = ds.GetNegativeNumbers(numbers);

            Assert.AreEqual(3, negativeNumbers.Count);
            Assert.AreEqual(-2.3, negativeNumbers[0]);
            Assert.AreEqual(-4.7, negativeNumbers[1]);
            Assert.AreEqual(-1.1, negativeNumbers[2]);
        }

        [TestMethod]
        public void ValidCountNegativeNumbers()
        {
            DataService ds = new DataService();

            List<double> numbers = new List<double> { 1, -2, 3, -4, -5, 6 };
            int count = ds.CountNegativeNumbers(numbers);

            Assert.AreEqual(3, count);
        }
    }
}
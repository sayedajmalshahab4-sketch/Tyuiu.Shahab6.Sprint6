using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Tyuiu.Shahab6.Sprint6.Task4.V5.Lib;

namespace Tyuiu.Shahab6.Sprint6.Task4.V5.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void ValidGetMassFunction()
        {
            DataService ds = new DataService();

            int startValue = -5;
            int stopValue = 5;
            double[] res = ds.GetMassFunction(startValue, stopValue);

            // Проверяем количество элементов
            Assert.AreEqual(11, res.Length);

            // Проверяем несколько значений
            // Для x = -5
            // (2*sin(-5))/(3*(-5)+1.2) + cos(-5) - 14*(-5)
            // ≈ (2*0.9589)/(-15+1.2) + 0.2837 + 70
            // ≈ 1.9178/(-13.8) + 70.2837 ≈ -0.139 + 70.2837 ≈ 70.14
            Assert.AreEqual(70.14, res[0]);
        }

        [TestMethod]
        public void ValidSaveToFile()
        {
            DataService ds = new DataService();

            string path = @"C:\Temp\TestOutput.txt";
            int startValue = -5;
            int stopValue = 5;

            string filePath = ds.SaveToFile(path, startValue, stopValue);

            Assert.IsTrue(File.Exists(filePath));

            // Проверяем содержимое файла
            string content = File.ReadAllText(filePath);
            Assert.IsTrue(content.Contains("Таблица значений функции"));
            Assert.IsTrue(content.Contains("X"));
            Assert.IsTrue(content.Contains("F(x)"));

            // Удаляем тестовый файл
            File.Delete(filePath);
        }
    }
}
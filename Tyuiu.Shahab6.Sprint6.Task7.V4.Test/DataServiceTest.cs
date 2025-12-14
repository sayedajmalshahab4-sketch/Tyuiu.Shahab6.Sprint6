using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Tyuiu.Shahab6.Sprint6.Task7.V4.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void ValidLoadMatrixFromFile()
        {
            // Создаем тестовый файл
            string testFilePath = "test_input.csv";
            File.WriteAllText(testFilePath, "1,2,3,4,5\n8,7,6,12,9\n15,16,20,24,25");

            try
            {
                var service = new Lib.DataService();
                var matrix = service.LoadMatrixFromFile(testFilePath);

                Assert.AreEqual(3, matrix.GetLength(0)); // 3 строки
                Assert.AreEqual(5, matrix.GetLength(1)); // 5 столбцов
                Assert.AreEqual(8, matrix[1, 0]); // Проверка значения
                Assert.AreEqual(12, matrix[1, 3]);
            }
            finally
            {
                // Удаляем тестовый файл
                if (File.Exists(testFilePath))
                {
                    File.Delete(testFilePath);
                }
            }
        }

        [TestMethod]
        public void ValidProcessMatrix()
        {
            var service = new Lib.DataService();
            int[,] inputMatrix = new int[,]
            {
                { 1, 2, 3, 4, 5 },
                { 8, 7, 6, 12, 9 },
                { 15, 16, 20, 24, 25 }
            };

            var result = service.ProcessMatrix(inputMatrix);

            // Проверяем, что во второй строке числа кратные 4 заменены на 4
            Assert.AreEqual(4, result[1, 0]); // 8 -> 4
            Assert.AreEqual(4, result[1, 3]); // 12 -> 4
            Assert.AreEqual(9, result[1, 4]); // 9 осталось 9
            Assert.AreEqual(1, result[0, 0]); // Первая строка не изменилась
            Assert.AreEqual(15, result[2, 0]); // Третья строка не изменилась
        }

        [TestMethod]
        public void ValidSaveMatrixToFile()
        {
            var service = new Lib.DataService();
            int[,] matrix = new int[,]
            {
                { 1, 2, 3 },
                { 4, 5, 6 }
            };

            string testFilePath = "test_output.csv";
            try
            {
                string savedPath = service.SaveMatrixToFile(matrix, testFilePath);

                Assert.AreEqual(testFilePath, savedPath);
                Assert.IsTrue(File.Exists(testFilePath));

                // Проверяем содержимое файла
                string[] lines = File.ReadAllLines(testFilePath);
                Assert.AreEqual(2, lines.Length);
                Assert.AreEqual("1,2,3", lines[0]);
                Assert.AreEqual("4,5,6", lines[1]);
            }
            finally
            {
                if (File.Exists(testFilePath))
                {
                    File.Delete(testFilePath);
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InvalidFileLoad()
        {
            var service = new Lib.DataService();
            service.LoadMatrixFromFile("nonexistent_file.csv");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InvalidNullMatrixProcess()
        {
            var service = new Lib.DataService();
            service.ProcessMatrix(null);
        }
    }
}
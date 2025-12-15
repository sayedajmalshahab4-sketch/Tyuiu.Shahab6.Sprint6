using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Tyuiu.Shahab6.Sprint6.Task7.V4.Lib;

namespace Tyuiu.Shahab6.Sprint6.Task7.V4.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void GetMatrixTest()
        {
            string path = "test.csv";
            File.WriteAllText(path, "1,2,3\n4,5,6\n7,8,9");

            var ds = new DataService();
            int[,] matrix = ds.GetMatrix(path);

            Assert.AreEqual(3, matrix.GetLength(0));
            Assert.AreEqual(3, matrix.GetLength(1));
            Assert.AreEqual(1, matrix[0, 0]);
            Assert.AreEqual(6, matrix[1, 2]);

            File.Delete(path);
        }

        [TestMethod]
        public void ProcessMatrixTest()
        {
            var ds = new DataService();
            int[,] matrix = new int[,]
            {
                { 1, 2, 3, 4 },
                { 8, 5, 12, 9 },
                { 16, 7, 20, 11 }
            };

            int[,] result = ds.ProcessMatrix(matrix);

            Assert.AreEqual(4, result[1, 0]);
            Assert.AreEqual(4, result[1, 2]);
            Assert.AreEqual(9, result[1, 3]);
            Assert.AreEqual(1, result[0, 0]);
            Assert.AreEqual(16, result[2, 0]);
        }

        [TestMethod]
        public void SaveMatrixTest()
        {
            var ds = new DataService();
            int[,] matrix = new int[,] { { 1, 2 }, { 3, 4 } };
            string path = "test_save.csv";

            ds.SaveMatrixToFile(matrix, path);

            Assert.IsTrue(File.Exists(path));
            string content = File.ReadAllText(path);
            Assert.IsTrue(content.Contains("1,2"));

            File.Delete(path);
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void GetMatrixFileNotFoundTest()
        {
            var ds = new DataService();
            ds.GetMatrix("nonexistent.csv");
        }
    }
}
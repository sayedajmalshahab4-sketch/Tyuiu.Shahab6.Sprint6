using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.Shahab6.Sprint6.Task6.V27.Lib;
using System.IO;

namespace Tyuiu.Shahab6.Sprint6.Task6.V27.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void ValidCollectTextFromFile()
        {
            string path = @"C:\Test\testFile.txt";

            Directory.CreateDirectory(Path.GetDirectoryName(path));
            File.WriteAllText(path, "Hello world! This is a test. Hi there!");

            DataService ds = new DataService();
            string result = ds.CollectTextFromFile(path);

            // Слова с 'H': Hello, This, Hi
            string expected = "Hello This Hi";

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ValidNoWordsWithH()
        {
            string path = @"C:\Test\testFile2.txt";
            File.WriteAllText(path, "apple banana cherry");

            DataService ds = new DataService();
            string result = ds.CollectTextFromFile(path);

            Assert.AreEqual("", result);
        }

        [TestMethod]
        public void ValidCaseInsensitive()
        {
            string path = @"C:\Test\testFile3.txt";
            File.WriteAllText(path, "hello hIgh House hELP");

            DataService ds = new DataService();
            string result = ds.CollectTextFromFile(path);

            // Все слова содержат 'h' или 'H'
            Assert.AreEqual("hello hIgh House hELP", result);
        }
    }
}
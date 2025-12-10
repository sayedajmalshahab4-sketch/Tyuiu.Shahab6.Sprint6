
 using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using Tyuiu.Shahab6.Sprint6.Task6.V27.Lib;

namespace Tyuiu.Shahab6.Sprint6.Task6.V27.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void ValidCollectTextFromFile()
        {
            // Arrange
            DataService ds = new DataService();
            
            // Create a test file
            string testFilePath = @"C:\Test\testFile.txt";
            
            // Create directory if it doesn't exist
            Directory.CreateDirectory(Path.GetDirectoryName(testFilePath));
            
            // Write test content to file
            string testContent = "Hello World This is a Test with H characters\n" +
                                "House, Home, Hotel\n" +
                                "No h here only small h\n" +
                                "HAPPY Birthday!";
            
            File.WriteAllText(testFilePath, testContent);
            
            // Expected result
            string expected = "Hello World This House Hotel HAPPY";
            
            // Act
            string result = ds.CollectTextFromFile(testFilePath);
            
            // Assert
            Assert.AreEqual(expected, result);
            
            // Clean up
            File.Delete(testFilePath);
        }

        [TestMethod]
        public void EmptyFileTest()
        {
            // Arrange
            DataService ds = new DataService();
            string testFilePath = @"C:\Test\emptyFile.txt";
            Directory.CreateDirectory(Path.GetDirectoryName(testFilePath));
            
            File.WriteAllText(testFilePath, "");
            
            // Expected result for empty file
            string expected = "No words containing 'H' found.";
            
            // Act
            string result = ds.CollectTextFromFile(testFilePath);
            
            // Assert
            Assert.AreEqual(expected, result);
            
            // Clean up
            File.Delete(testFilePath);
        }

        [TestMethod]
        public void NoHCharactersTest()
        {
            // Arrange
            DataService ds = new DataService();
            string testFilePath = @"C:\Test\noHFile.txt";
            Directory.CreateDirectory(Path.GetDirectoryName(testFilePath));
            
            string testContent = "apple banana cherry dog elephant";
            File.WriteAllText(testFilePath, testContent);
            
            // Expected result
            string expected = "No words containing 'H' found.";
            
            // Act
            string result = ds.CollectTextFromFile(testFilePath);
            
            // Assert
            Assert.AreEqual(expected, result);
            
            // Clean up
            File.Delete(testFilePath);
        }

        [TestMethod]
        public void OnlyHCharactersTest()
        {
            // Arrange
            DataService ds = new DataService();
            string testFilePath = @"C:\Test\onlyHFile.txt";
            Directory.CreateDirectory(Path.GetDirectoryName(testFilePath));
            
            string testContent = "HHHH HhHh H123 H_Test";
            File.WriteAllText(testFilePath, testContent);
            
            // Expected result
            string expected = "HHHH HhHh H123 H_Test";
            
            // Act
            string result = ds.CollectTextFromFile(testFilePath);
            
            // Assert
            Assert.AreEqual(expected, result);
            
            // Clean up
            File.Delete(testFilePath);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void FileNotFoundTest()
        {
            // Arrange
            DataService ds = new DataService();
            string nonExistentPath = @"C:\Test\NotExist\file.txt";
            
            // Act - Should throw exception
            ds.CollectTextFromFile(nonExistentPath);
        }

        [TestMethod]
        public void SpecialCharactersTest()
        {
            // Arrange
            DataService ds = new DataService();
            string testFilePath = @"C:\Test\specialChars.txt";
            Directory.CreateDirectory(Path.GetDirectoryName(testFilePath));
            
            string testContent = "Hello! How are you? I'm fine. House#123, Hotel@world";
            File.WriteAllText(testFilePath, testContent);
            
            // Expected result
            string expected = "Hello How House Hotel";
            
            // Act
            string result = ds.CollectTextFromFile(testFilePath);
            
            // Assert
            Assert.AreEqual(expected, result);
            
            // Clean up
            File.Delete(testFilePath);
        }

        [TestMethod]
        public void CaseSensitiveTest()
        {
            // Arrange
            DataService ds = new DataService();
            string testFilePath = @"C:\Test\caseTest.txt";
            Directory.CreateDirectory(Path.GetDirectoryName(testFilePath));
            
            string testContent = "Hello hello HOUSE house H h";
            File.WriteAllText(testFilePath, testContent);
            
            // Expected result (only uppercase H)
            string expected = "Hello HOUSE H";
            
            // Act
            string result = ds.CollectTextFromFile(testFilePath);
            
            // Assert
            Assert.AreEqual(expected, result);
            
            // Clean up
            File.Delete(testFilePath);
        }

        [TestMethod]
        public void MultipleSpacesTest()
        {
            // Arrange
            DataService ds = new DataService();
            string testFilePath = @"C:\Test\multiSpaces.txt";
            Directory.CreateDirectory(Path.GetDirectoryName(testFilePath));
            
            string testContent = "Hello     World    \n\n\nHouse\t\tHome";
            File.WriteAllText(testFilePath, testContent);
            
            // Expected result
            string expected = "Hello World House Home";
            
            // Act
            string result = ds.CollectTextFromFile(testFilePath);
            
            // Assert
            Assert.AreEqual(expected, result);
            
            // Clean up
            File.Delete(testFilePath);
        }
    }
}
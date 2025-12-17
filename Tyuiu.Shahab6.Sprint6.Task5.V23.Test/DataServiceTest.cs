using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.Shahab.Sprint6.Task5.V23.Lib;
using System.IO;

namespace Tyuiu.Shahab.Sprint6.Task5.V23.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void LoadFromDataFileTest()
        {
            DataService ds = new DataService();

            
            string path = @"C:\InPutDataFileTask5V23.txt";

        
            if (!File.Exists(path))
            {
                File.WriteAllLines(path, new string[]
                {
                    "-17.0", "0.0", "12.0", "-14.32", "5.0", "-7.84", "12.89",
                    "-1.57", "-3.64", "-13.26", "-8.91", "-17.77", "35.0",
                    "-9.0", "13.83", "12.76", "8.86", "0.0", "-1.49", "-7.0"
                });
            }

            double[] result = ds.LoadFromDataFile(path);
            double[] wait = { -17.0, -14.32, -7.84, -1.57, -3.64, -13.26, -8.91, -17.77, -9.0, -1.49, -7.0 };

            CollectionAssert.AreEqual(wait, result);
        }
    }
}
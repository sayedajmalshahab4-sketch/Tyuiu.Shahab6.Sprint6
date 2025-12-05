using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.Shahab6.Sprint6.Task1.V23.Lib;

namespace Tyuiu.Shahab6.Sprint6.Task1.V23.Test
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
            Assert.AreEqual(20.15, res[0]);  // x = -5
            Assert.AreEqual(7.76, res[5]);   // x = 0
            Assert.AreEqual(-19.59, res[10]); // x = 5
        }
    }
}
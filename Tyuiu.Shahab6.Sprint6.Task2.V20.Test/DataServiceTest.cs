using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.Shahab6.Sprint6.Task2.V20.Lib;

namespace Tyuiu.Shahab6.Sprint6.Task2.V20.Test
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

            double[] wait = {
                10.76,  // x = -5
                7.13,   // x = -4
                4.33,   // x = -3
                1.94,   // x = -2
                -0.26,  // x = -1
                -1.67,  // x = 0
                -2.84,  // x = 1
                -4.91,  // x = 2
                -7.06,  // x = 3
                -9.19,  // x = 4
                -11.27  // x = 5
            };

            CollectionAssert.AreEqual(wait, res);
        }
    }
}
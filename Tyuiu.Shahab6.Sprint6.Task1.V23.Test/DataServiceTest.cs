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

            double[] wait = {
                -15.19, -10.63, -7.51, -3.40, 0.57,
                0.42, 3.57, 6.07, 10.83, 15.92, 20.92
            };

            CollectionAssert.AreEqual(wait, res);
        }
    }
}
}
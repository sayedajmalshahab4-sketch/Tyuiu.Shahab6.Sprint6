using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.Shahab6.Sprint6.Task0.V26.Lib;

namespace Tyuiu.Shahab6.Sprint6.Task0.V26.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void ValidCalculateX3()
        {
            DataService ds = new DataService();

            int x = 3;
            double wait = 0.769; // (3² + 1) / (3*3 + 4) = (9 + 1) / (9 + 4) = 10 / 13 ≈ 0.769
            double res = ds.Calculate(x);

            Assert.AreEqual(wait, res);
        }

        [TestMethod]
        public void ValidCalculateX0()
        {
            DataService ds = new DataService();

            int x = 0;
            double wait = 0.25; // (0 + 1) / (0 + 4) = 1/4 = 0.25
            double res = ds.Calculate(x);

            Assert.AreEqual(wait, res);
        }

        [TestMethod]
        public void ValidCalculateX5()
        {
            DataService ds = new DataService();

            int x = 5;
            double wait = 1.368; // (25 + 1) / (15 + 4) = 26 / 19 ≈ 1.368
            double res = ds.Calculate(x);

            Assert.AreEqual(wait, res);
        }
    }
} 
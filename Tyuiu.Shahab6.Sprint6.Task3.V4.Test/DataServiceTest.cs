using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.Shahab6.Sprint6.Task3.V4.Lib;

namespace Tyuiu.Shahab6.Sprint6.Task3.V4.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void ValidCalculate()
        {
            DataService ds = new DataService();

            int[,] matrix = ds.GetMatrix();
            int[,] res = ds.Calculate(matrix);

            // Ожидаемый результат:
            // Вторая строка: -2(четное) → 0, остальные нечетные не меняются
            int[,] wait = new int[5, 5]
            {
                { -14,  -7,  18,  12, -20 },
                {   0, -15, -19, -19,  -3 }, // -2 заменен на 0
                { -18,  -5, -10,  14, -17 },
                {  -1,   2, -10,   0,  11 },
                {   6, -18,   0,  19,  16 }
            };

            // Проверяем размеры
            Assert.AreEqual(wait.GetLength(0), res.GetLength(0));
            Assert.AreEqual(wait.GetLength(1), res.GetLength(1));

            // Проверяем значения
            for (int i = 0; i < wait.GetLength(0); i++)
            {
                for (int j = 0; j < wait.GetLength(1); j++)
                {
                    Assert.AreEqual(wait[i, j], res[i, j]);
                }
            }
        }
    }
}
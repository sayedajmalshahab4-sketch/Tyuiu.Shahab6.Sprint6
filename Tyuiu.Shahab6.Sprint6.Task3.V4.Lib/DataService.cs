using System;
using tyuiu.cources.programming.interfaces.Sprint6;

namespace Tyuiu.Shahab6.Sprint6.Task3.V4.Lib
{
    public class DataService : ISprint6Task3V4
    {
        public DataService()
        {
        }

        public int[,] Calculate(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            // Создаем копию матрицы
            int[,] resultMatrix = (int[,])matrix.Clone();

            // Вторая строка имеет индекс 1 (индексация с 0)
            int rowIndex = 1;

            // Заменяем четные значения во второй строке на 0
            for (int j = 0; j < columns; j++)
            {
                if (resultMatrix[rowIndex, j] % 2 == 0)
                {
                    resultMatrix[rowIndex, j] = 0;
                }
            }

            return resultMatrix;
        }

        // Метод для получения исходной матрицы
        public int[,] GetMatrix()
        {
            int[,] matrix = new int[5, 5]
            {
                { -14,  -7,  18,  12, -20 },
                {  -2, -15, -19, -19,  -3 },
                { -18,  -5, -10,  14, -17 },
                {  -1,   2, -10,   0,  11 },
                {   6, -18,   0,  19,  16 }
            };

            return matrix;
        }
    }
}
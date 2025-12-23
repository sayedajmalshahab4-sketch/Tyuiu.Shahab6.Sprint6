using System;
using System.IO;
using tyuiu.cources.programming.interfaces.Sprint6;

namespace Tyuiu.Shahab6.Sprint6.Task7.V4.Lib
{
    public class DataService : ISprint6Task7V4
    {
        public DataService()
        {
        }

        public int[,] GetMatrix(string path)
        {
            string[] lines = File.ReadAllLines(path);

            int rowCount = lines.Length;
            int colCount = lines[0].Split(';').Length;

            int[,] matrix = new int[rowCount, colCount];

            for (int i = 0; i < rowCount; i++)
            {
                string[] values = lines[i].Split(';');
                for (int j = 0; j < colCount; j++)
                {
                    matrix[i, j] = int.Parse(values[j].Trim());
                }
            }

            for (int j = 0; j < colCount; j++)
            {
                if (matrix[1, j] % 4 == 0)
                {
                    matrix[1, j] = 4;
                }
            }

            return matrix;
        }
    }
}
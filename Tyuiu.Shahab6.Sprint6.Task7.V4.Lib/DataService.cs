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

            if (lines.Length == 0)
                return new int[0, 0];

            string[] firstLine = lines[0].Split(',');
            int rows = lines.Length;
            int cols = firstLine.Length;

            int[,] matrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                string[] values = lines[i].Split(',');
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = Convert.ToInt32(values[j]);
                }
            }

            return matrix;
        }

        public int[,] ProcessMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int[,] result = (int[,])matrix.Clone();

            if (rows >= 2)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (result[1, j] % 4 == 0 && result[1, j] != 0)
                    {
                        result[1, j] = 4;
                    }
                }
            }

            return result;
        }

        public void SaveMatrixToFile(int[,] matrix, string path)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            using (StreamWriter writer = new StreamWriter(path))
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        writer.Write(matrix[i, j]);
                        if (j < cols - 1)
                            writer.Write(",");
                    }
                    writer.WriteLine();
                }
            }
        }
    }
}
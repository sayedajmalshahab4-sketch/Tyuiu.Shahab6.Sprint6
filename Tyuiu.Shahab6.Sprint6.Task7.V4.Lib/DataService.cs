using System;
using System.IO;

namespace Tyuiu.Shahab6.Sprint6.Task7.V4.Lib
{
    public class DataService
    {
        public int[,] LoadMatrixFromFile(string filePath)
        {
            try
            {
                // Читаем все строки файла
                string[] lines = File.ReadAllLines(filePath);

                if (lines.Length == 0)
                {
                    throw new ArgumentException("Файл пуст");
                }

                // Определяем размеры матрицы
                int rows = lines.Length;
                string[] firstLine = lines[0].Split(',');
                int cols = firstLine.Length;

                int[,] matrix = new int[rows, cols];

                // Заполняем матрицу
                for (int i = 0; i < rows; i++)
                {
                    string[] values = lines[i].Split(',');

                    if (values.Length != cols)
                    {
                        throw new ArgumentException($"Несовпадающее количество столбцов в строке {i + 1}");
                    }

                    for (int j = 0; j < cols; j++)
                    {
                        if (int.TryParse(values[j], out int value))
                        {
                            matrix[i, j] = value;
                        }
                        else
                        {
                            throw new ArgumentException($"Неверный формат данных в строке {i + 1}, столбце {j + 1}");
                        }
                    }
                }

                return matrix;
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при загрузке матрицы из файла: " + ex.Message);
            }
        }

        public int[,] ProcessMatrix(int[,] matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix), "Матрица не может быть null");
            }

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            // Создаем копию матрицы
            int[,] result = (int[,])matrix.Clone();

            // Обрабатываем вторую строку (индекс 1)
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

        public string SaveMatrixToFile(int[,] matrix, string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    int rows = matrix.GetLength(0);
                    int cols = matrix.GetLength(1);

                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < cols; j++)
                        {
                            writer.Write(matrix[i, j]);
                            if (j < cols - 1)
                            {
                                writer.Write(",");
                            }
                        }
                        if (i < rows - 1)
                        {
                            writer.WriteLine();
                        }
                    }
                }

                return filePath;
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при сохранении матрицы в файл: " + ex.Message);
            }
        }
    }
}
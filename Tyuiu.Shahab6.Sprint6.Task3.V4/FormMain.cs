using System;
using System.Windows.Forms;
using Tyuiu.Shahab6.Sprint6.Task3.V4.Lib;

namespace Tyuiu.Shahab6.Sprint6.Task3.V4
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            LoadInitialMatrix();
        }

        private void LoadInitialMatrix()
        {
            DataService ds = new DataService();
            int[,] matrix = ds.GetMatrix();
            DisplayMatrix(dataGridViewOriginal, matrix, "Исходная матрица");
        }

        private void DisplayMatrix(DataGridView dgv, int[,] matrix, string title)
        {
            dgv.Rows.Clear();
            dgv.Columns.Clear();

            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            // Создаем колонки
            for (int j = 0; j < columns; j++)
            {
                dgv.Columns.Add($"col{j}", $"Столбец {j + 1}");
                dgv.Columns[j].Width = 50;
            }

            // Заполняем строки
            for (int i = 0; i < rows; i++)
            {
                dgv.Rows.Add();
                for (int j = 0; j < columns; j++)
                {
                    dgv.Rows[i].Cells[j].Value = matrix[i, j];

                    // Подсветка второй строки
                    if (i == 1)
                    {
                        dgv.Rows[i].Cells[j].Style.BackColor = System.Drawing.Color.LightYellow;
                    }
                }
            }

            dgv.ClearSelection();
        }

        private void buttonDone_Click(object sender, EventArgs e)
        {
            try
            {
                DataService ds = new DataService();

                // Получаем исходную матрицу
                int[,] originalMatrix = ds.GetMatrix();

                // Выполняем преобразование
                int[,] resultMatrix = ds.Calculate(originalMatrix);

                // Отображаем результат
                DisplayMatrix(dataGridViewResult, resultMatrix, "Результат");

                // Подсветка измененных ячеек
                for (int j = 0; j < 5; j++)
                {
                    if (resultMatrix[1, j] == 0 && originalMatrix[1, j] % 2 == 0)
                    {
                        dataGridViewResult.Rows[1].Cells[j].Style.BackColor = System.Drawing.Color.LightGreen;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Таск 3 выполнил студент группы СМАРТб-23-1 Шахаб А. Дж.",
                "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
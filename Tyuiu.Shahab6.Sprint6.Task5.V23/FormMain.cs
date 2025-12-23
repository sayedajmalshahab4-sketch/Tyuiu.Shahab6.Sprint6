using System;
using System.IO;
using System.Windows.Forms;

namespace YourNamespace
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string[,] matrix = LoadCSV(openFileDialog.FileName);
                    DisplayMatrixInDataGridView(matrix, dataGridViewIn);

                    string[,] processedMatrix = ProcessMatrix(matrix);
                    DisplayMatrixInDataGridView(processedMatrix, dataGridViewOut);

                    MessageBox.Show("File loaded successfully", "Success",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading file: {ex.Message}", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.FileName = "OutPutFileTask7.csv";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    SaveMatrixToCSV(dataGridViewOut, saveFileDialog.FileName);
                    MessageBox.Show("File saved successfully", "Success",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving file: {ex.Message}", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string[,] LoadCSV(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);

            int rowCount = lines.Length;
            string[] firstLineParts = lines[0].Split(';');
            int colCount = firstLineParts.Length;

            string[,] matrix = new string[rowCount, colCount];

            for (int i = 0; i < rowCount; i++)
            {
                string[] parts = lines[i].Split(';');
                for (int j = 0; j < colCount; j++)
                {
                    matrix[i, j] = parts[j].Trim();
                }
            }

            return matrix;
        }

        private string[,] ProcessMatrix(string[,] matrix)
        {
            int rowCount = matrix.GetLength(0);
            int colCount = matrix.GetLength(1);

            string[,] result = new string[rowCount, colCount];

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    result[i, j] = matrix[i, j];
                }
            }

            for (int j = 0; j < colCount; j++)
            {
                if (int.TryParse(result[1, j], out int number))
                {
                    if (number % 4 == 0)
                    {
                        result[1, j] = "4";
                    }
                }
            }

            return result;
        }

        private void DisplayMatrixInDataGridView(string[,] matrix, DataGridView dgv)
        {
            int rowCount = matrix.GetLength(0);
            int colCount = matrix.GetLength(1);

            dgv.RowCount = rowCount;
            dgv.ColumnCount = colCount;

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    dgv[j, i].Value = matrix[i, j];
                }
            }
        }

        private void SaveMatrixToCSV(DataGridView dgv, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                for (int i = 0; i < dgv.RowCount; i++)
                {
                    string[] rowValues = new string[dgv.ColumnCount];
                    for (int j = 0; j < dgv.ColumnCount; j++)
                    {
                        rowValues[j] = dgv[j, i].Value?.ToString() ?? "";
                    }
                    writer.WriteLine(string.Join(";", rowValues));
                }
            }
        }

        private void buttonDone_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
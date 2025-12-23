using System;
using System.IO;
using System.Windows.Forms;
using Tyuiu.Shahab6.Sprint6.Task7.V4.Lib;

namespace Tyuiu.Shahab6.Sprint6.Task7.V4
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
                    DataService ds = new DataService();
                    int[,] matrix = ds.GetMatrix(openFileDialog.FileName);

                    DisplayMatrix(LoadMatrixFromFile(openFileDialog.FileName), dataGridViewIn);

                    DisplayMatrix(matrix, dataGridViewOut);

                    MessageBox.Show("File loaded successfully", "Success",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error",
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
                    MessageBox.Show($"Error: {ex.Message}", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private int[,] LoadMatrixFromFile(string path)
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

            return matrix;
        }

        private void DisplayMatrix(int[,] matrix, DataGridView dgv)
        {
            int rowCount = matrix.GetLength(0);
            int colCount = matrix.GetLength(1);

            dgv.RowCount = rowCount;
            dgv.ColumnCount = colCount;

            for (int i = 0; i < colCount; i++)
            {
                dgv.Columns[i].Width = 50;
            }

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
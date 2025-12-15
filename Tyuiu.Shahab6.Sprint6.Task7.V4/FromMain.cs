using System;
using System.Windows.Forms;
using Tyuiu.Shahab6.Sprint6.Task7.V4.Lib;

namespace Tyuiu.Shahab6.Sprint6.Task7.V4
{
    public partial class FormMain : Form
    {
        private DataService ds;
        private int[,] inputMatrix;
        private int[,] outputMatrix;
        private string inputFilePath;

        public FormMain()
        {
            InitializeComponent();
            ds = new DataService();
            buttonSaveResult.Enabled = false;
        }

        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                openFileDialog.FileName = "InPutFileTask7V4.csv";
                openFileDialog.Title = "Open File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    inputFilePath = openFileDialog.FileName;
                    textBoxInputFile.Text = inputFilePath;

                    inputMatrix = ds.GetMatrix(inputFilePath);
                    DisplayMatrix(dataGridViewIn, inputMatrix);
                    outputMatrix = ds.ProcessMatrix(inputMatrix);
                    DisplayMatrix(dataGridViewOut, outputMatrix);
                    buttonSaveResult.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayMatrix(DataGridView dgv, int[,] matrix)
        {
            dgv.Rows.Clear();
            dgv.Columns.Clear();

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int j = 0; j < cols; j++)
            {
                dgv.Columns.Add("col" + j, "Col " + (j + 1));
            }

            for (int i = 0; i < rows; i++)
            {
                dgv.Rows.Add();
                for (int j = 0; j < cols; j++)
                {
                    dgv.Rows[i].Cells[j].Value = matrix[i, j];
                }
            }
        }

        private void buttonSaveResult_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                saveFileDialog.FileName = "OutPutFileTask7.csv";
                saveFileDialog.Title = "Save Result";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string outputPath = saveFileDialog.FileName;
                    ds.SaveMatrixToFile(outputMatrix, outputPath);
                    MessageBox.Show("File saved: " + outputPath, "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Task 7 Variant 4", "Help",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
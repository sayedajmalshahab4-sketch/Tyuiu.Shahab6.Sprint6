using System;
using System.Windows.Forms;

namespace Tyuiu.Shahab6.Sprint6.Task7.V4
{
    public partial class FormMain : Form
    {
        private DataService dataService;
        private int[,] inputMatrix;
        private int[,] outputMatrix;
        private string inputFilePath;

        public FormMain()
        {
            InitializeComponent();
            dataService = new DataService();
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

                    // Load matrix from file
                    inputMatrix = dataService.LoadMatrixFromFile(inputFilePath);

                    // Display input matrix
                    DisplayMatrix(dataGridViewIn, inputMatrix);

                    // Process matrix
                    outputMatrix = dataService.ProcessMatrix(inputMatrix);

                    // Display output matrix
                    DisplayMatrix(dataGridViewOut, outputMatrix);

                    // Enable save button
                    buttonSaveResult.Enabled = true;

                    // Update status
                    toolStripStatusLabel.Text = "File loaded successfully";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading file: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                toolStripStatusLabel.Text = "Error loading file";
            }
        }

        private void DisplayMatrix(DataGridView dataGridView, int[,] matrix)
        {
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            // Create columns
            for (int j = 0; j < cols; j++)
            {
                dataGridView.Columns.Add($"Column{j}", $"Column {j + 1}");
                dataGridView.Columns[j].Width = 70;
            }

            // Add rows
            for (int i = 0; i < rows; i++)
            {
                int rowIndex = dataGridView.Rows.Add();
                for (int j = 0; j < cols; j++)
                {
                    dataGridView.Rows[rowIndex].Cells[j].Value = matrix[i, j];
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
                    string outputFilePath = saveFileDialog.FileName;
                    dataService.SaveMatrixToFile(outputMatrix, outputFilePath);

                    MessageBox.Show($"File saved successfully: {outputFilePath}", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    toolStripStatusLabel.Text = "File saved successfully";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving file: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                toolStripStatusLabel.Text = "Error saving file";
            }
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Task completed by student Shahab6\n" +
                          "Version 4\n" +
                          "Program loads matrix from CSV file, changes numbers " +
                          "in the second row that are multiples of 4 to 4, " +
                          "and saves the result to a new file.",
                          "Help",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Information);
        }
    }
}
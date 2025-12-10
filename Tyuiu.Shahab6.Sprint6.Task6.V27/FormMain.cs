using System;
using System.Windows.Forms;
using Tyuiu.Shahab6.Sprint6.Task6.V27.Lib;

namespace Tyuiu.Shahab6.Sprint6.Task6.V27
{
    public partial class FormMain : Form
    {
        private DataService ds = new DataService();

        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonOpenFile_SHA_Click(object sender, EventArgs e)
        {
            openFileDialogTask_SHA.FileName = "InPutFileTask6V27.txt";
            openFileDialogTask_SHA.InitialDirectory = @"C:\";

            if (openFileDialogTask_SHA.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialogTask_SHA.FileName;
                textBoxLoadFromFile_SHA.Text = filePath;

                try
                {
                    // Загружаем содержимое файла в textBoxIn
                    string fileContent = System.IO.File.ReadAllText(filePath);
                    textBoxIn_SHA.Text = fileContent;

                    // Обрабатываем файл
                    string result = ds.CollectTextFromFile(filePath);
                    textBoxOut_SHA.Text = result;

                    buttonDone_SHA.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке файла:\n{ex.Message}",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonDone_SHA_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxLoadFromFile_SHA.Text))
            {
                string result = ds.CollectTextFromFile(textBoxLoadFromFile_SHA.Text);
                textBoxOut_SHA.Text = result;
            }
            else
            {
                MessageBox.Show("Сначала выберите файл!",
                    "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonHelp_SHA_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Задание выполнил: Шахаб М.С. | АСОиУБ-25-1\n\n" +
                "Task6. Вариант 27.\n" +
                "Вывести слова, содержащие букву 'H' (регистр не важен) из выбранного файла.",
                "Справка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
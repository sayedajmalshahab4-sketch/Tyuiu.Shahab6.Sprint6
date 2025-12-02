using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Tyuiu.Shahab6.Sprint6.Task5.V23.Lib;

namespace Tyuiu.Shahab6.Sprint6.Task5.V23
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FileName = "InPutFileTask5V23.txt";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataService ds = new DataService();

                    // Загрузка данных из файла
                    List<double> allNumbers = ds.LoadFromDataFile(openFileDialog.FileName);

                    // Отображение всех чисел в dataGridView
                    DisplayAllNumbers(dataGridViewAll, allNumbers, "Все числа из файла");

                    // Получение отрицательных чисел
                    List<double> negativeNumbers = ds.GetNegativeNumbers(allNumbers);

                    // Отображение отрицательных чисел
                    DisplayNegativeNumbers(dataGridViewNegative, negativeNumbers, "Отрицательные числа (< 0)");

                    // Построение диаграммы
                    DrawChart(chartNumbers, allNumbers, negativeNumbers);

                    // Статистика
                    DisplayStatistics(allNumbers, ds);

                    // Сохранение пути к файлу
                    textBoxFilePath.Text = openFileDialog.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка загрузки файла: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DisplayAllNumbers(DataGridView dgv, List<double> numbers, string title)
        {
            dgv.Rows.Clear();
            dgv.Columns.Clear();

            // Создаем колонки
            dgv.Columns.Add("colIndex", "№");
            dgv.Columns.Add("colValue", "Значение");

            dgv.Columns[0].Width = 50;
            dgv.Columns[1].Width = 100;

            // Заполняем данными
            for (int i = 0; i < numbers.Count; i++)
            {
                dgv.Rows.Add(i + 1, numbers[i].ToString("F3"));

                // Подсветка отрицательных чисел
                if (numbers[i] < 0)
                {
                    dgv.Rows[i].Cells[1].Style.BackColor = Color.LightCoral;
                }
            }

            dgv.ClearSelection();
        }

        private void DisplayNegativeNumbers(DataGridView dgv, List<double> numbers, string title)
        {
            dgv.Rows.Clear();
            dgv.Columns.Clear();

            // Создаем колонки
            dgv.Columns.Add("colIndex", "№");
            dgv.Columns.Add("colValue", "Отрицательное значение");

            dgv.Columns[0].Width = 50;
            dgv.Columns[1].Width = 150;

            // Заполняем данными
            for (int i = 0; i < numbers.Count; i++)
            {
                dgv.Rows.Add(i + 1, numbers[i].ToString("F3"));
                dgv.Rows[i].Cells[1].Style.BackColor = Color.LightCoral;
            }

            dgv.ClearSelection();
        }

        private void DrawChart(Chart chart, List<double> allNumbers, List<double> negativeNumbers)
        {
            chart.Series.Clear();
            chart.ChartAreas.Clear();

            // Настройка области графика
            ChartArea chartArea = new ChartArea();
            chartArea.AxisX.Title = "Номер элемента";
            chartArea.AxisY.Title = "Значение";
            chartArea.AxisX.MajorGrid.Enabled = true;
            chartArea.AxisY.MajorGrid.Enabled = true;
            chart.ChartAreas.Add(chartArea);

            // Серия для всех чисел
            Series seriesAll = new Series();
            seriesAll.ChartType = SeriesChartType.Column;
            seriesAll.Name = "Все числа";
            seriesAll.Color = Color.LightBlue;
            seriesAll.BorderWidth = 1;

            // Серия для отрицательных чисел
            Series seriesNegative = new Series();
            seriesNegative.ChartType = SeriesChartType.Column;
            seriesNegative.Name = "Отрицательные";
            seriesNegative.Color = Color.Red;
            seriesNegative.BorderWidth = 1;

            // Добавление точек
            for (int i = 0; i < allNumbers.Count; i++)
            {
                seriesAll.Points.AddXY(i + 1, allNumbers[i]);

                if (allNumbers[i] < 0)
                {
                    seriesNegative.Points.AddXY(i + 1, allNumbers[i]);
                }
            }

            chart.Series.Add(seriesAll);
            chart.Series.Add(seriesNegative);

            // Настройки отображения
            chart.Titles.Clear();
            chart.Titles.Add("Диаграмма значений из файла");
            chart.Legends[0].Enabled = true;
        }

        private void DisplayStatistics(List<double> numbers, DataService ds)
        {
            int totalCount = numbers.Count;
            int negativeCount = ds.CountNegativeNumbers(numbers);
            int positiveCount = ds.CountPositiveNumbers(numbers);

            string stats = $"Общая статистика:\r\n";
            stats += $"Всего чисел: {totalCount}\r\n";
            stats += $"Отрицательных чисел: {negativeCount}\r\n";
            stats += $"Неотрицательных чисел: {positiveCount}\r\n";
            stats += $"Процент отрицательных: {(double)negativeCount / totalCount * 100:F1}%";

            textBoxStatistics.Text = stats;
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Таск 5 выполнил студент группы СМАРТб-23-1 Шахаб А. Дж.",
                "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
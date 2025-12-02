using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Tyuiu.Shahab6.Sprint6.Task4.V5.Lib;

namespace Tyuiu.Shahab6.Sprint6.Task4.V5
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonDone_Click(object sender, EventArgs e)
        {
            try
            {
                DataService ds = new DataService();

                int startValue = -5;
                int stopValue = 5;

                double[] values = ds.GetMassFunction(startValue, stopValue);

                // Вывод в textBox
                string result = "Таблица значений функции:\r\n";
                result += "F(x) = (2*sin(x))/(3x+1.2) + cos(x) - 14x\r\n";
                result += "Диапазон: [" + startValue + "; " + stopValue + "]\r\n";
                result += "--------------------------\r\n";
                result += "   X   |   F(x)\r\n";
                result += "--------------------------\r\n";

                int count = 0;
                for (int x = startValue; x <= stopValue; x++)
                {
                    result += $"  {x,3}  |  {values[count],7}\r\n";
                    count++;
                }

                textBoxOutput.Text = result;

                // Построение графика
                DrawGraph(values, startValue, stopValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DrawGraph(double[] values, int startValue, int stopValue)
        {
            chartFunction.Series.Clear();
            chartFunction.ChartAreas.Clear();

            // Настройка области графика
            ChartArea chartArea = new ChartArea();
            chartArea.AxisX.Title = "X";
            chartArea.AxisY.Title = "F(x)";
            chartArea.AxisX.MajorGrid.Enabled = true;
            chartArea.AxisY.MajorGrid.Enabled = true;
            chartFunction.ChartAreas.Add(chartArea);

            // Создание серии
            Series series = new Series();
            series.ChartType = SeriesChartType.Line;
            series.Name = "Функция";
            series.Color = Color.Blue;
            series.BorderWidth = 2;
            series.MarkerStyle = MarkerStyle.Circle;
            series.MarkerSize = 6;
            series.MarkerColor = Color.Red;

            // Добавление точек
            int count = 0;
            for (int x = startValue; x <= stopValue; x++)
            {
                series.Points.AddXY(x, values[count]);
                count++;
            }

            chartFunction.Series.Add(series);

            // Настройки отображения
            chartFunction.Titles.Clear();
            chartFunction.Titles.Add("График функции F(x)");
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.FileName = "OutPutFileTask4V5.txt";
                saveFileDialog.DefaultExt = "txt";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    DataService ds = new DataService();

                    int startValue = -5;
                    int stopValue = 5;

                    string filePath = ds.SaveToFile(saveFileDialog.FileName, startValue, stopValue);

                    MessageBox.Show($"Файл сохранен: {filePath}", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Таск 4 выполнил студент группы СМАРТб-23-1 Шахаб А. Дж.",
                "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
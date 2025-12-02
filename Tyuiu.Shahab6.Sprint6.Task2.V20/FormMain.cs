using System;
using System.Windows.Forms;
using Tyuiu.Shahab6.Sprint6.Task2.V20.Lib;

namespace Tyuiu.Shahab6.Sprint6.Task2.V20
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonDone_Click(object sender, EventArgs e)
        {
            DataService ds = new DataService();

            int startValue = -5;
            int stopValue = 5;

            double[] values = ds.GetMassFunction(startValue, stopValue);

            // Очистка DataGridView
            dataGridViewResult.Rows.Clear();

            // Заполнение DataGridView
            for (int i = 0; i < values.Length; i++)
            {
                int x = startValue + i;
                dataGridViewResult.Rows.Add(x.ToString(), values[i].ToString());
            }
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Таск 2 выполнил студент группы СМАРТб-23-1 Шахаб А. Дж.",
                "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
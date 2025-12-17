using System;
using System.Windows.Forms;
using Tyuiu.Shahab6.Sprint6.Task1.V23.Lib;
namespace Tyuiu.Shahab6.Sprint6.Task1.V23 
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonDone_SHA_Click(object sender, EventArgs e)
        {
            DataService ds = new DataService();
            try
            {
                int startValue = Convert.ToInt32(textBoxStart_SHA.Text);
                int stopValue = Convert.ToInt32(textBoxStop_SHA.Text);

                double[] valueArray = ds.GetMassFunction(startValue, stopValue);

                string strResult = "Результаты вычислений:\n";
                strResult += "+----------+----------+\n";
                strResult += "|    X     |    f(x)  |\n";
                strResult += "+----------+----------+\n";

                int count = 0;
                for (int x = startValue; x <= stopValue; x++)
                {
                    strResult += $"| {x,5}    | {valueArray[count],8:F2} |\n";
                    count++;
                }

                strResult += "+----------+----------+\n";

                textBoxResult_SHA.Text = strResult;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonHelp_SHA_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Табулирование функции F(x) = sin(x) + (2x/3) - cos(x) * 4x\n" +
                "на диапазоне [-5; 5] с шагом 1\n" +
                "Выполнил: Шабаев М.С. | АСОиУБ-25-1",
                "Справка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
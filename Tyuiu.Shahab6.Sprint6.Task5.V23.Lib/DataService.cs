using tyuiu.cources.programming.interfaces.Sprint6;
namespace Tyuiu.Shahab.Sprint6.Task5.V23.Lib
{
    public class DataService :ISprint6Task5V23
    {
        public DataService()
        {
        }

        public double[] LoadFromDataFile(string path)
        {
            List<double> result = new List<double>();

            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (double.TryParse(line.Replace('.', ','), out double num))
                    {
                        if (num < 0)
                        {
                            result.Add(Math.Round(num, 3));
                        }
                    }
                }
            }

            return result.ToArray();
        }
    }
}
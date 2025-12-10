 using System.Text.RegularExpressions;
using tyuiu.cources.programming.interfaces.Sprint6;

namespace Tyuiu.Shahab6.Sprint6.Task6.V27.Lib
{
    public class DataService : ISprint6Task6V27
    {
        public DataService()
        {
        }

        public string CollectTextFromFile(string path)
        {
            string result = "";

            try
            {
                string fileContent = File.ReadAllText(path);

                // Разделяем на слова (учитываем пробелы, знаки препинания)
                string[] words = Regex.Split(fileContent, @"\W+");

                foreach (string word in words)
                {
                    if (!string.IsNullOrEmpty(word))
                    {
                        // Проверяем, содержит ли слово букву 'H' (регистр не важен)
                        if (word.IndexOf("H", StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            result += word + " ";
                        }
                    }
                }

                // Убираем последний пробел
                if (result.Length > 0)
                {
                    result = result.Trim();
                }
            }
            catch (Exception ex)
            {
                result = "Ошибка: " + ex.Message;
            }

            return result;
        }
    }
}
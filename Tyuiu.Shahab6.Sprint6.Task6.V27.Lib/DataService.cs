using System;
using System.IO;
using System.Text;
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
            StringBuilder result = new StringBuilder();

            try
            {
                string fileContent = File.ReadAllText(path);

                char[] separators = new char[] {
                    ' ', '.', ',', '!', '?', ';', ':',
                    '\t', '\n', '\r', '"', '(', ')',
                    '[', ']', '{', '}', '<', '>',
                    '/', '\\', '-', '+', '=', '*',
                    '&', '^', '%', '$', '#', '@',
                    '|', '~', '`'
                };

                string[] words = fileContent.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                foreach (string word in words)
                {
                    
                    if (word.Contains('H'))
                    {
                        result.Append(word);
                        result.Append(" ");
                    }
                }

                
                if (result.Length > 0)
                {
                    result.Length--;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при обработке файла: {ex.Message}");
            }

            return result.ToString();
        }
    }
}
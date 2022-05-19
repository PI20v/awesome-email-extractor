using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AwesomeEmailExtractor
{
    internal class ExtactEmailsAlgorithm
    {
        public static int Extract(string inputText, out List<string> uniqueEmails)
        {
            // Регулярное выражение для поиска почтовых адресов
            string pattern = @"\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b";

            // Находим каждый почтовый адрес в тексте
            var matches = Regex.Matches(inputText, pattern, RegexOptions.IgnoreCase);

            // Получаем количество найденных адресов
            int countMatches = matches.Count;

            // Получаем уникальные почтовые адреса
            uniqueEmails = matches.Cast<Match>().Select(m => m.Value).Distinct().ToList();

            return countMatches;
        }
    }
}

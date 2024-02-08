using System;
using System.Text;
using System.Text.RegularExpressions;

namespace SerialToKeyboard.Control
{
    class DefaultFormatter
    {
        public static string Reformat(string original)
        {
            var sb = new StringBuilder();

            string pattern = @"gk(\d+,\d+)";

            // Use the Regex class to find matches in the string
            Match match = Regex.Match(original, pattern);

            // Check if there is a match
            if (match.Success)
            {
                // Extract the value from the match
                string extractedValue = match.Groups[1].Value;

                // Reversing string
                char[] charArray = extractedValue.ToCharArray();
                Array.Reverse(charArray);
                extractedValue = new string(charArray);

                // Format the result as "d,ddd"
                string formattedResult = $"{extractedValue}";

                sb.Append(formattedResult);
            }

            return sb.ToString();
        }
    }
}

using System.Text.RegularExpressions;

namespace RomanCalculator
{
    public partial class RomanNumber
    {
        private static readonly Dictionary<char, int> _romanInArabicMap = new()
        {
            ['I'] = 1,
            ['V'] = 5,
            ['X'] = 10,
            ['L'] = 50,
            ['C'] = 100,
            ['D'] = 500,
            ['M'] = 1000
        };

        public int ConvertToArabic(string roman)
        {
            if(string.IsNullOrWhiteSpace(roman)) throw new ArgumentNullException(nameof(roman));

            if(CheckRomanNumberRegex().IsMatch(roman) is false) throw new ArgumentException("Недопустимое значение римского числа.", nameof(roman));

            int result = 0;

            for (int i = 0; i < roman.Length; i++)
            {
                int current = _romanInArabicMap[roman[i]];

                result += i + 1 < roman.Length && _romanInArabicMap[roman[i + 1]] > current
                    ? -current : current;
            }

            return result;
        }

        public string ConvertToRoman(int arabic)
        {
            throw new NotImplementedException();
        }

        [GeneratedRegex("^M{0,3}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$")]
        private static partial Regex CheckRomanNumberRegex();
    }
}
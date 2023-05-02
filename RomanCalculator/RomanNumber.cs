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

        private static readonly string[] _thousands = { "", "M", "MM", "MMM" };

        private static readonly string[] _hundreds = { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };

        private static readonly string[] _tens = { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };

        private static readonly string[] _units = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };


        public static int ConvertToArabic(string roman)
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

        public static string ConvertToRoman(int arabic)
        {
            if (arabic < 1 || arabic > 3999) throw new ArgumentOutOfRangeException(nameof(arabic), "Число должно быть в диапазоне от 1 до 3999.");

            string roman = _thousands[arabic / 1000] +
                           _hundreds[(arabic % 1000) / 100] +
                           _tens[(arabic % 100) / 10] +
                           _units[arabic % 10];

            return roman;
        }

        [GeneratedRegex("^M{0,3}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$")]
        private static partial Regex CheckRomanNumberRegex();
    }
}
using System.Text;

namespace RomanCalculator
{
    public static class Helper
    {
        public static (string Number, int Index)? GetNumberFromString(string str, int startIndex)
        {
            if (str is null) throw new ArgumentNullException(nameof(str));

            if (startIndex < 0 || startIndex < str.Length)
            {
                char c = str[startIndex];
                if (char.IsDigit(c))
                {
                    StringBuilder number = new();
                    while (char.IsDigit(c))
                    {
                        number.Append(c);
                        startIndex++;

                        if (startIndex < str.Length) c = str[startIndex];
                        else break;
                    }

                    startIndex--;
                    return (number.ToString(), startIndex);
                }
            }

            return null;
        }
    }
}
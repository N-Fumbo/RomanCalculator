using RomanCalculator.Algorithms;
using RomanCalculator.Tree;
using System.Text;

namespace RomanCalculator.Parser
{
    public class ExpressionParse
    {
        public static string ConvertExpressionRomanToArabic(string expressionFormatRoman)
        {
            if (expressionFormatRoman is null) throw new ArgumentNullException(nameof(expressionFormatRoman));

            StringBuilder result = new();

            StringBuilder number = new();

            for (int i = 0; i < expressionFormatRoman.Length; i++)
            {
                char c = expressionFormatRoman[i];

                if (RomanNumber.RomanInArabicMap.ContainsKey(c) is false)
                {
                    result.Append(c);
                    continue;
                }
                
                number.Clear();
                while (RomanNumber.RomanInArabicMap.ContainsKey(c))
                {
                    number.Append(c);
                    i++;

                    if (i < expressionFormatRoman.Length) c = expressionFormatRoman[i];
                    else break;
                }

                i--;

                result.Append(RomanNumber.ConvertToArabic(number.ToString()));
            }

            return result.ToString();
        }

        public static Node BuildTree(string expression)
        {
            List<string> postfix = ReversePolishNotation.ConvertToPostfix(expression);

            Stack<Node> stack = new();
            foreach (string token in postfix)
            {
                if (IsOperator(token))
                {
                    Node right = stack.Pop();
                    Node left = stack.Pop();
                    Node node = new(token, left, right);
                    stack.Push(node);
                }
                else
                {
                    Node node = new(token);
                    stack.Push(node);
                }
            }

            return stack.Pop();
        }

        private static bool IsOperator(string value) => value != null && (MathConstants.Operators.Contains(value));
    }
}

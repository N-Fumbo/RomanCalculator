using RomanCalculator.Parser.ExpressionValidator;
using RomanCalculator.Parser.ExpressionValidator.Base;

namespace RomanCalculator.Algorithms
{
    public partial class ReversePolishNotation
    {
        public static List<string> ConvertToPostfix(string expression)
        {
            if (new MathExpressionValidator<IMathExpressionValidatorStrategy>().Validate(expression) is false) 
                throw new ArgumentException("Неверное математическое выражение.", nameof(expression));

            List<string> postfix = new();
            Stack<char> operators = new();

            for (int i = 0; i < expression.Length; i++)
            {
                char c = expression[i];

                var numberData = Helper.GetNumberFromString(expression, i);
                if (numberData != null)
                {
                    i = numberData.Value.Index;
                    postfix.Add(numberData.Value.Number.ToString());
                }
                else if (MathConstants.Operators.Contains(c.ToString()))
                {
                    while (operators.Count > 0 && GetPriorityOperation(c) <= GetPriorityOperation(operators.Peek()))
                        postfix.Add(operators.Pop().ToString());

                    operators.Push(c);
                }
                else if (c == '(')
                {
                    operators.Push(c);
                }
                else if (c == ')')
                {
                    while (operators.Peek() != '(')
                        postfix.Add(operators.Pop().ToString());

                    operators.Pop();
                }
            }

            while (operators.Count > 0)
                postfix.Add(operators.Pop().ToString());

            return postfix;
        }

        private static int GetPriorityOperation(char opertaion)
        {
            if (opertaion == '(' || opertaion == ')')
                return 0;
            else if (opertaion == '+' || opertaion == '-')
                return 1;
            else if (opertaion == '*')
                return 2;

            throw new ArgumentException($"Неизвестный оператор для оценки приоритета. {opertaion}", nameof(opertaion));
        }
    }
}
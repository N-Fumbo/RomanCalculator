using RomanCalculator.Parser.ExpressionValidator.Base;
using RomanCalculator.Parser.ExpressionValidator.Strategies;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RomanCalculator.Parser.ExpressionValidator
{
    public class MathExpressionValidator<T> where T : IMathExpressionValidatorStrategy
    {
        private static Regex _minimumComponentExpressionRegex = new("^(?=.*\\d.*\\d)(?=.*[+\\-*]).+$");

        private readonly Dictionary<Type, T> _validators;

        public MathExpressionValidator()
        {
            _validators = new()
            {
                [typeof(OpeningBracketValidatorStrategy)] = (T)Activator.CreateInstance(typeof(OpeningBracketValidatorStrategy)),
                [typeof(ClosingBracketValidatorStrategy)] = (T)Activator.CreateInstance(typeof(ClosingBracketValidatorStrategy)),
                [typeof(NumberValidatorStrategy)] = (T)Activator.CreateInstance(typeof(NumberValidatorStrategy)),
                [typeof(OperatorValidatorStrategy)] = (T)Activator.CreateInstance(typeof(OperatorValidatorStrategy)),
                [typeof(LastValueValidatorStategy)] = (T)Activator.CreateInstance(typeof(LastValueValidatorStategy))
            };
        }

        public bool Validate(string expression)
        {
            if (string.IsNullOrWhiteSpace(expression)) return false;
            
            if(_minimumComponentExpressionRegex.IsMatch(expression) is false) return false;

            var stack = new Stack<char>();

            string previousValue = null;

            var number = new StringBuilder();

            for (int i = 0; i < expression.Length; i++)
            {
                char c = expression[i];

                if (char.IsDigit(c))
                {
                    if (!Validate<NumberValidatorStrategy>(previousValue)) return false;
                    number.Clear();

                    while (char.IsDigit(c))
                    {
                        number.Append(c);
                        i++;
                        if (i < expression.Length) c = expression[i];
                        else break;
                    }

                    i--;
                    previousValue = number.ToString();
                }
                else if (MathConstants.Operators.Contains(c.ToString()))
                {
                    if (!Validate<OperatorValidatorStrategy>(previousValue)) return false;

                    previousValue = c.ToString();
                }
                else if (c == '(')
                {
                    if (!Validate<OpeningBracketValidatorStrategy>(previousValue)) return false;
                    stack.Push(c);

                    previousValue = c.ToString();
                }
                else if (c == ')')
                {
                    if (!Validate<ClosingBracketValidatorStrategy>(previousValue)) return false;

                    if (stack.Count == 0 || stack.Pop() != '(') return false;

                    previousValue = c.ToString();
                }
                else if (c != ' ')
                {
                    return false;
                }
            }

            if (!Validate<LastValueValidatorStategy>(previousValue)) return false;

            return stack.Count == 0;
        }

        private bool Validate<TStrategy>(string previousValue) where TStrategy : IMathExpressionValidatorStrategy
        {
            return _validators[typeof(TStrategy)].Validate(previousValue);
        }
    }
}

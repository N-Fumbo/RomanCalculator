using RomanCalculator.Parser.ExpressionValidator.Base;
using RomanCalculator.Parser.ExpressionValidator.Strategies;
using System.Text.RegularExpressions;

namespace RomanCalculator.Parser.ExpressionValidator
{
    public class MathExpressionValidator<T> where T : IMathExpressionValidatorStrategy
    {
        private static readonly Regex _minimumComponentExpressionRegex = new("^(?=.*\\d.*\\d)(?=.*[+\\-*]).+$");

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

            if (_minimumComponentExpressionRegex.IsMatch(expression) is false) return false;

            var stack = new Stack<char>();
            string previousValue = null;

            for (int i = 0; i < expression.Length; i++)
            {
                char c = expression[i];

                var numberData = Helper.GetNumberFromString(expression, i);
                if (numberData != null)
                {
                    if (!Validate<NumberValidatorStrategy>(previousValue)) return false;

                    i = numberData.Value.Index;
                    previousValue = numberData.Value.Number.ToString();
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

        private bool Validate<TStrategy>(string previousValue) where TStrategy : IMathExpressionValidatorStrategy =>
            _validators[typeof(TStrategy)].Validate(previousValue);
    }
}

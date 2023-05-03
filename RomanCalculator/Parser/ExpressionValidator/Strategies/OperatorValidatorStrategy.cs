using RomanCalculator.Parser.ExpressionValidator.Base;

namespace RomanCalculator.Parser.ExpressionValidator.Strategies
{
    public class OperatorValidatorStrategy : IMathExpressionValidatorStrategy
    {
        public bool Validate(string previousValue)
        {
            return string.IsNullOrEmpty(previousValue) is false && (char.IsDigit(previousValue[0]) || previousValue == ")");
        }
    }
}
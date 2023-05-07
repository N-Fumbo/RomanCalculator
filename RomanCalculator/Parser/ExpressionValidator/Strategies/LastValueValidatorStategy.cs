using RomanCalculator.Parser.ExpressionValidator.Base;

namespace RomanCalculator.Parser.ExpressionValidator.Strategies
{
    public class LastValueValidatorStategy : IMathExpressionValidatorStrategy
    {
        public bool Validate(string previousValue) =>
            previousValue != null && (char.IsDigit(previousValue[0]) || previousValue == ")");
    }
}
using RomanCalculator.Parser.ExpressionValidator.Base;

namespace RomanCalculator.Parser.ExpressionValidator.Strategies
{
    public class OpeningBracketValidatorStrategy : IMathExpressionValidatorStrategy
    {
        public bool Validate(string previousValue) =>
            previousValue is null || MathConstants.Operators.Contains(previousValue) || previousValue == "(";
    }
}
namespace RomanCalculator.Parser.ExpressionValidator.Base
{
    public interface IMathExpressionValidatorStrategy
    {
        bool Validate(string previousValue);
    }
}
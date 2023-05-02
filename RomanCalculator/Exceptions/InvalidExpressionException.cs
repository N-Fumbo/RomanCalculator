namespace RomanCalculator.Exceptions
{
    public class InvalidExpressionException : Exception
    {
        public InvalidExpressionException() : base() { }

        public InvalidExpressionException(string message) : base(message) { }

        public InvalidExpressionException(string message, Exception? innerExceprion) : base(message, innerExceprion) { }
    }
}
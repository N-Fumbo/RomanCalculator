namespace RomanCalculator.Exceptions
{
    public class InvalidRomanNumberException : Exception
    {
        public InvalidRomanNumberException() : base() { }

        public InvalidRomanNumberException(string message) : base(message) { }

        public InvalidRomanNumberException(string message, Exception? innerExceprion) : base(message, innerExceprion) { }
    }
}
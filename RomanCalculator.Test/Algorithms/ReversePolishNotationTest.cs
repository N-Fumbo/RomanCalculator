using RomanCalculator.Algorithms;

namespace RomanCalculator.Test.Algorithms
{
    public class ReversePolishNotationTest
    {
        [Theory]
        [InlineData("3 + 4", "3 4 +")]
        [InlineData("( 1 + 2 ) * ( 3 + 4 )", "1 2 + 3 4 + *")]
        [InlineData("2 * ( 3 + 4 )", "2 3 4 + *")]
        [InlineData("4 + 5 * 3", "4 5 3 * +")]
        [InlineData("( 7 - 2 ) * ( 3 + 2 )", "7 2 - 3 2 + *")]
        [InlineData("2 + 3 * 4 - 5", "2 3 4 * + 5 -")]
        [InlineData("( 1 + 2 ) * ( 3 + 4 ) * ( 5 + 6 )", "1 2 + 3 4 + * 5 6 + *")]
        public void ToRoman_ConvertsCorrectly(string expresion, string expected)
        {
            List<string> actual = new ReversePolishNotation().ConvertToPostfix(expresion);
            string result = string.Join(" ", actual);
            Assert.Equal(expected, result);
        }
    }
}

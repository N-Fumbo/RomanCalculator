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
        [InlineData("( 1 + 2 ) * ( 3 + 4 ) * ( 5 + 6s )", null)]
        [InlineData("( )", null)]
        [InlineData("1 +", null)]
        [InlineData("1 2 3 40", null)]
        [InlineData("(3 + 4) 1", null)]
        [InlineData("3 + 4 + ( * 2)", null)]
        [InlineData("((5 + 3) * 10", null)]
        [InlineData("2", null)]
        [InlineData("() + 1 + 20", null)]
        [InlineData("2) + 10", null)]
        [InlineData("10.2 + 10", null)]
        public void ConvertToPostfix_Correctly(string expresion, string expected)
        {
            if (expected != null)
            {
                List<string> actual = ReversePolishNotation.ConvertToPostfix(expresion);
                string result = string.Join(" ", actual);
                Assert.Equal(expected, result);
            }
            else
            {
                Assert.ThrowsAny<ArgumentException>(() => ReversePolishNotation.ConvertToPostfix(expresion));
            }
        }
    }
}

namespace RomanCalculator.Test
{
    public class RomanNumberTest
    {
        [Theory]
        [InlineData("I", 1)]
        [InlineData("IV", 4)]
        [InlineData("IX", 9)]
        [InlineData("XL", 40)]
        [InlineData("XC", 90)]
        [InlineData("CD", 400)]
        [InlineData("CM", 900)]
        [InlineData("MV", 1005)]
        public void ToArabic_ConvertsCorrectly(string roman, int expected)
        {
            var actual = new RomanNumber().ConvertToArabic(roman);
            Assert.Equal(expected, actual);
        }
    }
}
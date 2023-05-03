
namespace RomanCalculator.Test
{
    public class CalculatorTest
    {
        [Theory]
        [InlineData("(MMMDCCXXIV - MMCCXXIX) * II", "MMCMXC")]
        [InlineData("XVIII + (CIX - LXXV) * V", "CLXXXVIII")]
        [InlineData("XV * III + CXI - (XLVII + IX)", "C")]
        [InlineData("(MDCCC - DCCC) * VI - MMMDCCCLXXV", "MMCXXV")]
        [InlineData("(DLV - CCCXV) + (CXX - XX)", "CCCXL")]
        public void ConvertExpressionRomanToArabic_Correctly(string expressionFormatRoman, string resultFormatRoman)
        {
            Calculator calculator = new();
            var actual = calculator.Evaluate(expressionFormatRoman);
            Assert.Equal(resultFormatRoman, actual);
        }
    }
}
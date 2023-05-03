
using RomanCalculator.Exceptions;
using RomanCalculator.Parser;

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
        [InlineData("((MCMXCVIII + DCCCXLV) - (DLIX * II)) * II", "MMMCDL")]
        [InlineData("((CXCIV + DCLXVI) * V) - (MMMCMLXXXVIII - MMMCCCXLVII)", "MMMDCLIX")]
        [InlineData("((((MMCDXLVII - MDCCLXIV)*III) +   (MMMCCCXXV * V)) - (MMCMXV + CCLXV)     ) - CXX * C", "MMMCDXCIV")]
        [InlineData("(   (MMMCCCXXIX   + DCLXVI) - (    MMMDCCXLV * II   ))   * VII  + (MMMCMXCIX * II) * II + MMCMXVII * III ", "CCLXXXII")]
        [InlineData("((((MMXVII-DCCLX)*IX)+(MMDCCLXXV-MCMXCIV))*III)-(MDCCCLVIII*XIX)-CMLXXIX", "I")]
        public void ConvertExpressionRomanToArabic_Correctly(string expressionFormatRoman, string resultFormatRoman)
        {
            Calculator calculator = new();
            var actual = calculator.Evaluate(expressionFormatRoman);
            Assert.Equal(resultFormatRoman, actual);
        }

        [Theory]
        [InlineData("(MMMDCCXXIV - MMCCXXIX) / II")]
        [InlineData("((MMMDCCXXIV - MMCCXXIX) + II")]
        [InlineData("I I")]
        [InlineData("IV + - I")]
        [InlineData("() + I * III")]
        [InlineData(")(I * III)")]
        [InlineData("I * II.I")]
        [InlineData("(MMMD CCXXIV - MMCCXXIX) + II")]
        public void ConvertExpressionRomanToArabic_ArgumentExceptionCorrectly(string expressionFormatRoman)
        {
            Calculator calculator = new();
            Assert.ThrowsAny<ArgumentException>(() => calculator.Evaluate(expressionFormatRoman));
        }

        [Theory]
        [InlineData("(MMMDCCXXIV - IVVVV) * II")]
        [InlineData("(MMMIM - MMCCXXIX) * II")]
        [InlineData("(CCCC - MMCCXXIX) * VIV")]
        [InlineData("(MMMDCCXXIV - XCD) * II")]
        [InlineData("(VX - MMCCXXIX) * II")]
        [InlineData("(IL - MMCCXXIX) * II")]
        [InlineData("(MMMDCCXXIV - MMCCXXIX) * CDM")]
        [InlineData("(MMMDCCXXIV - MCMC) * II")]
        [InlineData("(MMMDCCXXIV - LXL) * II")]
        public void ConvertExpressionRomanToArabic_InvalidRomanNumberExceptionCorrectly(string expressionFormatRoman)
        {
            Calculator calculator = new();
            Assert.ThrowsAny<InvalidRomanNumberException>(() => calculator.Evaluate(expressionFormatRoman));
        }

        [Theory]
        [InlineData("((MCMXCVIII + DCCCXLV) - (DLIX * X)) * IV")]
        [InlineData("((CMXCIV + DCLXVI) * V) - (MCMLXXXVIII - MMMCCCXLVII)")]
        [InlineData("(((MMCDXLVII - MDCCLXIV) * III) + (MMMCCCXXV * V)) - (MMCMXV + CCLXV)")]
        [InlineData("((MMMCCCXXIX + DCLXVI) - (MMMDCCXLV * II)) * VII")]
        [InlineData("(((MMXVII - DCCLX) * IX) + (MMDCCLXXV - MCMXCIV)) * III")]
        public void ConvertExpressionRomanToArabic_ArgumentOutOfRangeExceptionInvalidResult(string expressionFormatRoman)
        {
            Calculator calculator = new();
            Assert.ThrowsAny<ArgumentOutOfRangeException>(() => calculator.Evaluate(expressionFormatRoman));
        }
    }
}
using RomanCalculator.Exceptions;
using RomanCalculator.Parser;

namespace RomanCalculator.Test.Parse
{
    public class ExpressionParseTest
    {
        [Theory]
        [InlineData("I", "1")]
        [InlineData("IV", "4")]
        [InlineData("IX", "9")]
        [InlineData("XL", "40")]
        [InlineData("XC", "90")]
        [InlineData("CD", "400")]
        [InlineData("CM", "900")]
        [InlineData("MV", "1005")]
        [InlineData("MCMLIV", "1954")]
        [InlineData("MMXIV", "2014")]
        [InlineData("MCMXCIX", "1999")]
        [InlineData("MMMCMXCIX", "3999")]
        [InlineData("(MMMDCCXXIV - MMCCXXIX) * II", "(3724 - 2229) * 2")]
        [InlineData("(XCVI / IV) + (XXV * III)", "(96 / 4) + (25 * 3)")]
        [InlineData("XVIII + (CIX - LXXV) / V", "18 + (109 - 75) / 5")]
        [InlineData("XV * III + CXI - (XLVII + IX)", "15 * 3 + 111 - (47 + 9)")]
        [InlineData("(MDCCC - DCCC) * VII / X", "(1800 - 800) * 7 / 10")]
        [InlineData("(IV * VIII) - (XVII + IX) * III", "(4 * 8) - (17 + 9) * 3")]
        [InlineData("(XXVII / III) + (CCXV - CDX) * IV", "(27 / 3) + (215 - 410) * 4")]
        [InlineData("(DLV - CCCXV) / (CXX - XX)", "(555 - 315) / (120 - 20)")]
        [InlineData("IVVVV", null)]
        [InlineData("MMMIM", null)]
        [InlineData("VIV", null)]
        [InlineData("CCCC", null)]
        [InlineData("XCD", null)]
        [InlineData("IIIX", null)]
        [InlineData("VX", null)]
        [InlineData("IL", null)]
        [InlineData("CDM", null)]
        [InlineData("MCMC", null)]
        [InlineData("LXL", null)]
        public void ConvertExpressionRomanToArabic_Correctly(string expectedRoman, string expectedArabic)
        {
            if (expectedArabic != null)
            {
                var actual = ExpressionParse.ConvertExpressionRomanToArabic(expectedRoman);
                Assert.Equal(expectedArabic, actual);
            }
            else
            {
                Assert.ThrowsAny<InvalidRomanNumberException>(() => ExpressionParse.ConvertExpressionRomanToArabic(expectedRoman));
            }
        }
    }
}

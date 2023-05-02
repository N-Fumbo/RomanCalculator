using RomanCalculator.Exceptions;

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
        [InlineData("MCMLIV", 1954)]
        [InlineData("MMXIV", 2014)]
        [InlineData("MCMXCIX", 1999)]
        [InlineData("MMMCMXCIX", 3999)]
        [InlineData(" ", null)]
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
        public void ToArabic_ConvertsCorrectly(string roman, int? expected)
        {
            if (roman is null)
            {
                Assert.ThrowsAny<ArgumentNullException>(() => RomanNumber.ConvertToArabic(roman));
            }
            if (expected.HasValue)
            {
                var actual = RomanNumber.ConvertToArabic(roman);
                Assert.Equal(expected, actual);
            }
            else
            {
                Assert.ThrowsAny<InvalidRomanNumberException>(() => RomanNumber.ConvertToArabic(roman));
            }
        }

        [Theory]
        [InlineData(1, "I")]
        [InlineData(4, "IV")]
        [InlineData(9, "IX")]
        [InlineData(40, "XL")]
        [InlineData(90, "XC")]
        [InlineData(400, "CD")]
        [InlineData(900, "CM")]
        [InlineData(1005, "MV")]
        [InlineData(1954, "MCMLIV")]
        [InlineData(1999, "MCMXCIX")]
        [InlineData(2014, "MMXIV")]
        [InlineData(3999, "MMMCMXCIX")]
        [InlineData(-1, null)]
        [InlineData(0, null)]
        [InlineData(4000, null)]
        public void ToRoman_ConvertsCorrectly(int arabic, string expected)
        {
            if (expected != null)
            {
                var actual = RomanNumber.ConvertToRoman(arabic);
                Assert.Equal(expected, actual);
            }
            else
            {
                Assert.ThrowsAny<ArgumentOutOfRangeException>(() => RomanNumber.ConvertToRoman(arabic));
            }
        }
    }
}
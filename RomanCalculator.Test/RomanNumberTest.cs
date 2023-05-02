﻿namespace RomanCalculator.Test
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
            if (string.IsNullOrWhiteSpace(roman))
            {
                Assert.ThrowsAny<ArgumentNullException>(() => new RomanNumber().ConvertToArabic(roman));
            }
            if (expected.HasValue)
            {
                var actual = new RomanNumber().ConvertToArabic(roman);
                Assert.Equal(expected, actual);
            }
            else
            {
                Assert.ThrowsAny<ArgumentException>(() => new RomanNumber().ConvertToArabic(roman));
            }
        }
    }
}
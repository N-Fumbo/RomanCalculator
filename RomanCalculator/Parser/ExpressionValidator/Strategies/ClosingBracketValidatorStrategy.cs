using RomanCalculator.Parser.ExpressionValidator.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanCalculator.Parser.ExpressionValidator.Strategies
{
    public class ClosingBracketValidatorStrategy : IMathExpressionValidatorStrategy
    {
        public bool Validate(string previousValue)
        {
            return string.IsNullOrEmpty(previousValue) is false && (char.IsDigit(previousValue[0]) || previousValue == ")");
        }
    }
}

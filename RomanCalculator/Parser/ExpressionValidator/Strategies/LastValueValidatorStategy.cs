using RomanCalculator.Parser.ExpressionValidator.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanCalculator.Parser.ExpressionValidator.Strategies
{
    public class LastValueValidatorStategy : IMathExpressionValidatorStrategy
    {
        public bool Validate(string previousValue)
        {
            return previousValue != null && (char.IsDigit(previousValue[0]) || previousValue == ")");
        }
    }
}

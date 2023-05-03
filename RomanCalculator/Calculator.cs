using RomanCalculator.Parser;
using RomanCalculator.Tree;
using System.Linq.Expressions;

namespace RomanCalculator
{
    public class Calculator
    {
        public string Evaluate(string expressionFormatRoman)
        {
            if(expressionFormatRoman is null) throw new ArgumentNullException(nameof(expressionFormatRoman));

            string expressionFormatArabic = ExpressionParse.ConvertExpressionRomanToArabic(expressionFormatRoman);

            Node root = ExpressionParse.BuildTree(expressionFormatArabic);

            ExpressionTree tree = new(root);

            Expression expression = tree.BuildExpressionTree();

            LambdaExpression lambdaExpression = Expression.Lambda(expression);
            Func<int> lambda = (Func<int>)lambdaExpression.Compile();

            int result = lambda();

            return RomanNumber.ConvertToRoman(result);
        }
    }
}
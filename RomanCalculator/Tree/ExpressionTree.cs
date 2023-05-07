using System.Linq.Expressions;

namespace RomanCalculator.Tree
{
    public class ExpressionTree
    {
        public Node Root { get; }

        public ExpressionTree(Node root)
        {
            if(root is null) throw new ArgumentNullException(nameof(root));
            Root = root;
        }

        public Expression BuildExpressionTree() => BuildExpressionTree(Root);


        private Expression BuildExpressionTree(Node root)
        {
            if (root is null) return null;

            if (int.TryParse(root.Value, out var value))
                return Expression.Constant(value);

            var left = BuildExpressionTree(root.Left);
            var right = BuildExpressionTree(root.Right);

            return root.Value switch
            {
                "+" => Expression.Add(left, right),
                "-" => Expression.Subtract(left, right),
                "*" => Expression.Multiply(left, right),
                _ => throw new InvalidOperationException($"Неизвестный оператор: {root.Value}")
            };
        }
    }
}

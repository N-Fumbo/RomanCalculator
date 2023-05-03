namespace RomanCalculator.Tree
{
    public class Node
    {
        public string Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(string value)
        {
            if (value is null) throw new ArgumentNullException(nameof(value));

            Value = value;
        }

        public Node(string value, Node left, Node right)
        {
            if (value is null) throw new ArgumentNullException(nameof(value));

            Value = value;
            Left = left;
            Right = right;
        }
    }
}
namespace Dar.CodeAnalysis.Binding
{
    internal sealed class BoundBinaryExpression : BoundExpression
    {
        public override Type Type => Op.Type;
        public override BoundNodeKind Kind => BoundNodeKind.BinaryExpression;
        public BoundBinaryOperator Op { get;}
        public BoundExpression Left { get; }
        public BoundExpression Right { get; }
        public BoundBinaryExpression(BoundExpression left, BoundBinaryOperator op, BoundExpression right)
        {
            Left = left;
            Right = right;
            Op = op;
        }        
    }
}
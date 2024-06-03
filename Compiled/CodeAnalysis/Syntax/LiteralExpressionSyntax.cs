namespace Dar.CodeAnalysis.Syntax
{
    public sealed class LiteralExpressionSyntax : ExpressionSyntax
{
    public override SyntaxKind Kind => SyntaxKind.LiteralExpression;
    public SyntaxToken LiteralToken {get;}
    public LiteralExpressionSyntax(SyntaxToken literalToken)
    {
        this.LiteralToken = literalToken;
    }
    public override IEnumerable<SyntaxNode> GetChildren()
    {
        yield return LiteralToken;
    }
}
}
namespace Dar.CodeAnalysis.Syntax
{
public sealed class SyntaxToken : SyntaxNode
{
    public override SyntaxKind Kind {get;}
    public int Position {get;}
    public string Text {get;}
    public object Value {get;}
    public SyntaxToken(SyntaxKind kind, int position, string text, object value)
    {
        this.Kind = kind;
        this.Position = position;
        this.Text = text;
        this.Value = value;
    }
    public override IEnumerable<SyntaxNode> GetChildren()
    {
        return Enumerable.Empty<SyntaxNode>();
    }
}
}
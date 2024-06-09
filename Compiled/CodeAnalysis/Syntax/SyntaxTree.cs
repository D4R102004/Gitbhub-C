namespace Dar.CodeAnalysis.Syntax
{
public sealed class SyntaxTree
{
    public IReadOnlyList<Diagnostic> Diagnostics {get;}
    public ExpressionSyntax Root {get;}
    public SyntaxToken EndOfFileToken {get;}
    public SyntaxTree(IEnumerable<Diagnostic> diagnostics, ExpressionSyntax root, SyntaxToken endOfFileToken)
    {
        this.Root = root;
        this.EndOfFileToken = endOfFileToken;
        this.Diagnostics = diagnostics.ToArray();
    }
    public static SyntaxTree Parse(string text)
    {
        var parser = new Parser(text);
        return parser.Parse();

    }
}
    
}
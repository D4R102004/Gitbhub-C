using System.Collections.Immutable;
using System.Diagnostics;
using Dar.CodeAnalysis.Text;

namespace Dar.CodeAnalysis.Syntax
{
public sealed class SyntaxTree
{
    private SyntaxTree(SourceText text)
    {
        var parser = new Parser(text);
        var root = parser.ParseCompilationUnit();
        var diagnostics = parser.Diagnostics.ToImmutableArray();
        this.Root = root;
        Text = text;
        this.Diagnostics = diagnostics;
    }

    public SourceText Text { get; }
    public ImmutableArray<Diagnostic> Diagnostics {get;}
    public CompilationUnitSyntax Root {get;}
    public static SyntaxTree Parse(string text)
    {
        var sourceText = SourceText.From(text);
        return Parse(sourceText);
    }
    public static SyntaxTree Parse(SourceText text)
    {
        return new SyntaxTree(text);

    }
    public static IEnumerable<SyntaxToken> ParseTokens(string text)
    {
        var sourceText = SourceText.From(text);
        return ParseTokens(sourceText);
    }
    public static IEnumerable<SyntaxToken> ParseTokens(SourceText text)
    {
        var lexer = new Lexer(text);
        while (true)
        {
            var token = lexer.Lex();
            if (token.Kind == SyntaxKind.EndOfFileToken) 
                break;
                
            yield return token;

        }
    }
}
    
}
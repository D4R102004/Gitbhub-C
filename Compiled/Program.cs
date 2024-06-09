using System.Drawing;
using Dar.CodeAnalysis.Syntax;
using Dar.CodeAnalysis.Binding;
namespace Dar.CodeAnalysis
{
internal static class Program
{
    // 1 + 2 * 3
    //   +
    //  / \
    // 1   *
    //    / \
    //   2   3
    private static void Main()
    {
        var showTree = false;
        while (true)
        {
            System.Console.Write("> ");
            var line = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(line)) return;
            if (line == "#showTree")
            {
                showTree = !showTree;
                System.Console.WriteLine(showTree ? "Showing parse trees" : "Not showing parse trees");
                continue;
            }
            var syntaxTree = SyntaxTree.Parse(line);
            var compilation = new Compilation(syntaxTree);
            var result = compilation.Evaluate();
            var diagnostics = result.Diagnostics;
            if (showTree)
            {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            PrettyPrint(syntaxTree.Root);
            Console.ResetColor();
            }                
                if (!diagnostics.Any())
            {
                System.Console.WriteLine(result.Value);
            }
            else
            {
                
                foreach (var diagnostic in diagnostics) 
                {
                    System.Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    System.Console.WriteLine(diagnostic);
                    Console.ResetColor();
                    var prefix = line.Substring(0, diagnostic.Span.Start);
                    var error = line.Substring(diagnostic.Span.Start, diagnostic.Span.Length);
                    var suffix = line.Substring(diagnostic.Span.End);
                    Console.Write("    ");
                    System.Console.Write(prefix);
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    System.Console.Write(error);
                    Console.ResetColor();
                    System.Console.Write(suffix);
                    System.Console.WriteLine();
                }
                System.Console.WriteLine();
            }
        }
    }
    static void PrettyPrint(SyntaxNode node, string indent = "", bool isLast = true)
    {
        // └──
        // ├──
        // │
        var marker = isLast ? "└──" : "├──";
        System.Console.Write(indent);
        System.Console.Write(marker);
        System.Console.Write(node.Kind);
        if (node is SyntaxToken t && t.Value != null)
        {
            System.Console.Write(" ");
            Console.Write(t.Value);
        }
        Console.WriteLine();
        indent += isLast ? "   " : "│   ";
        var lastChild = node.GetChildren().LastOrDefault();
        foreach (var child in node.GetChildren()) PrettyPrint(child, indent, child == lastChild);
    }
}











}
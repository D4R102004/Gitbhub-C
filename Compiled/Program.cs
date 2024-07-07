using System.Drawing;
using Dar.CodeAnalysis.Syntax;
using Dar.CodeAnalysis.Binding;
using System.Text;
using Dar.CodeAnalysis.Text;
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
        var variables = new Dictionary<VariableSymbol, object>();
        var textBuilder = new StringBuilder();
        Compilation previous = null;
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            if (textBuilder.Length == 0)
                System.Console.Write("» ");
            else
                System.Console.Write("· ");

            Console.ResetColor();
            
            var input = Console.ReadLine();

            var isBlank = string.IsNullOrEmpty(input);


            if (textBuilder.Length == 0)
            {
                if (isBlank)
                {
                    break;

                }
                else if (input == "#showTree")
                {
                    showTree = !showTree;
                    System.Console.WriteLine(showTree ? "Showing parse trees" : "Not showing parse trees");
                    continue;
                }
                else if (input == "#cls")
                {
                    Console.Clear();
                    continue;
                }
                else if (input == "#reset")
                {
                    previous = null;
                    continue;
                }

            }
            textBuilder.AppendLine(input);
            var text = textBuilder.ToString();
            var syntaxTree = SyntaxTree.Parse(text);

            if (!isBlank && syntaxTree.Diagnostics.Any())
                continue;
            
            var compilation = previous == null 
                                ? new Compilation(syntaxTree)
                                : previous.ContinueWith(syntaxTree);


            var result = compilation.Evaluate(variables);
            if (showTree)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                syntaxTree.Root.WriteTo(Console.Out);
                Console.ResetColor();
            }                
            if (!result.Diagnostics.Any())
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                System.Console.WriteLine(result.Value);
                Console.ResetColor();

                previous = compilation;
            }
            else
            {
                foreach (var diagnostic in result.Diagnostics) 
                {
                    var lineIndex = syntaxTree.Text.GetLineIndex(diagnostic.Span.Start);
                    var line = syntaxTree.Text.Lines[lineIndex];
                    var lineNumber = lineIndex + 1;
                        
                    var character = diagnostic.Span.Start - line.Start + 1;


                    System.Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    System.Console.Write($"({lineNumber}, {character}): ");
                    System.Console.WriteLine(diagnostic);
                    Console.ResetColor();

                    var prefixSpan = TextSpan.FromBounds(line.Start, diagnostic.Span.Start);
                    var suffixSpan = TextSpan.FromBounds(diagnostic.Span.End, line.End);
                    var prefix = syntaxTree.Text.ToString(prefixSpan);
                    var error = syntaxTree.Text.ToString(diagnostic.Span);
                    var suffix = syntaxTree.Text.ToString(suffixSpan);
                    Console.Write("    ");
                    System.Console.Write(prefix);
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    
                    System.Console.Write(error);
                    Console.ResetColor();
                    
                    System.Console.WriteLine(suffix);
                    
                }
                System.Console.WriteLine();
            }

            textBuilder.Clear();
        }
    }
}



}
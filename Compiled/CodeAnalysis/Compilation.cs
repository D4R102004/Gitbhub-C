using System.Collections.Immutable;
using Dar.CodeAnalysis.Binding;
using Dar.CodeAnalysis.Syntax;
namespace Dar.CodeAnalysis
{
    public class Compilation
    {
        public Compilation(SyntaxTree syntaxTree)
        {
            SyntaxTree = syntaxTree;
        }
        public SyntaxTree SyntaxTree { get; }
        public EvaluationResult Evaluate(Dictionary<VariableSymbol, object> variables)
        {
            var binder = new Binder(variables);
            var boundExpression = binder.BindExpression(SyntaxTree.Root);
            var diagnostics = SyntaxTree.Diagnostics.Concat(binder.Diagnostics).ToImmutableArray();
            if (diagnostics.Any())
            {
                return new EvaluationResult(diagnostics, null);
            }
            var evaluator = new Evaluator(boundExpression, variables);
            var value = evaluator.Evaluate();
            return new EvaluationResult(ImmutableArray<Diagnostic>.Empty, value);

        }
    }
}
namespace Dar.CodeAnalysis.Binding
{
    internal enum BoundNodeKind 
    {
        // Statements
        BlockStatement,
        ExpressionStatement,

        // Expressions
        LiteralExpression,
        VariableExpression,
        UnaryExpression,
        BinaryExpression,
        
        AssignmentExpression,
        
    }
}
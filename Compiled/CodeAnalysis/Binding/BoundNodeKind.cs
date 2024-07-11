namespace Dar.CodeAnalysis.Binding
{
    internal enum BoundNodeKind 
    {
        // Statements
        BlockStatement,
        VariableDeclaration,
        IfStatement,
        WhileStatement,
        ForStatement,
        LabelStatement,
        GoToStatement,
        ConditionalGoToStatement,
        ExpressionStatement,
        


        // Expressions
        LiteralExpression,
        VariableExpression,
        AssignmentExpression,
        UnaryExpression,
        BinaryExpression,
        
    }
}
namespace Dar.CodeAnalysis.Syntax
{
    public enum SyntaxKind 
    {
        // Tokens
        BadToken,
        EndOfFileToken,
        WhiteSpaceToken,
        NumberToken,
        PlusToken, 
        MinusToken, 
        StarToken, 
        SlashToken, 
        BangToken,
        EqualsToken,
        AmpersandAmpersandToken,
        PipePipeToken,
        EqualsEqualsToken,
        BangEqualsToken,
        LessToken,
        GreaterToken,
        LessOrEqualsToken,
        GreaterOrEqualsToken,
        OpenParenthesisToken, 
        CloseParenthesisToken, 
        OpenBraceToken,
        CloseBraceToken,
        IdentifierToken,
        
        //Keywords
        ElseKeyword,
        FalseKeyword,
        IfKeyword,
        TrueKeyword,
        LetKeyword,
        VarKeyword,

        // Nodes
        CompilationUnit,
        ElseClause,

        // Statements
        BlockStatement,
        VariableDeclaration,
        IfStatement,
        ExpressionStatement,
        

        // Expressions
        LiteralExpression,
        NameExpression,
        UnaryExpression,
        BinaryExpression, 
        ParenthesizedExpression,
        AssignmentExpression,
        
    }
    
}
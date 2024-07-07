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
        OpenParenthesisToken, 
        CloseParenthesisToken, 
        OpenBraceToken,
        CloseBraceToken,
        IdentifierToken,
        
        //Keywords
        
        FalseKeyword,
        TrueKeyword,
        LetKeyword,
        VarKeyword,

        // Nodes
        CompilationUnit,

        // Statements
        BlockStatement,
        VariableDeclaration,
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
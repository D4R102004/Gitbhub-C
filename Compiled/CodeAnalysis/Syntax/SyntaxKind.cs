namespace Dar.CodeAnalysis.Syntax
{
public enum SyntaxKind 
{
    //Tokens
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
    IdentifierToken,
    CommaToken,
    //Keywords
    
    FalseKeyword,
    TrueKeyword,

    //Expressions
    LiteralExpression,
    NameExpression,
    UnaryExpression,
    BinaryExpression, 
    ParenthesizedExpression,
        AssignmentExpression,
        
    }
    
}
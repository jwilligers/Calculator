namespace MajorProject
{
    public enum TokenType
    { // there are five types of tokens
        Variable, Number, Operator, Comment, Finish

    }
    class Token
    {
        TokenType tokenType;
        string value;
        public Token(TokenType _tokenType, string _value)
        {
            tokenType = _tokenType;
            value = _value; // tokens have a type and a value
        }
        public TokenType GetTokenType()
        { 
            return tokenType;
        }
        override public string ToString()
        {
 	        return value;
        }

    }
}

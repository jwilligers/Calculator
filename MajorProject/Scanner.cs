using System;

namespace MajorProject
{
    class Scanner
    {
        String input;
        int position;
        Token current;
        string argumentName;
        Boolean insideFunction;

        public Scanner(String _input, FunctionTable functionTable, Boolean _insideFunction = false, string _argumentName = "")
        { // remove whitespace
            input = _input.Replace("\t", "").Replace("\r", "");
            insideFunction = _insideFunction;
            argumentName = _argumentName;
            //input = functionTable.replaceAllFunctions(input);
            position = 0;
            MoveOn();
        }

        public void MoveOn() // get next token
        {
            while (position < input.Length && input[position] == ' ')
            {
                ++position;
            }
            if (position == input.Length)
            { // if the scanner is at the end
                current = new Token(TokenType.Finish, "");
            }
            else if (Char.IsLetter(input[position]))
            {
                string var = ""; 
                while (position != input.Length && Char.IsLetter(input[position]))
                { // get all letters together in a row to form variable name
                    var += input[position]; // single letter variable names are allowed
                    position++;
                }
                if (var == argumentName && insideFunction)
                {
                    current = new Token(TokenType.FunctionArgument, var);
                }   
                else
                {
                    current = new Token(TokenType.Variable, var);
                }
            }
            else if (Char.IsDigit(input[position]))
            {
                string num = "";
                while (position != input.Length && (Char.IsDigit(input[position]) || input[position] == '.'))
                { //get all digits together in a row to form a number
                    num += input[position];
                    position++;
                }
                current = new Token(TokenType.Number, num);
            }
            else if (input[position] == '#')
            {
                position++;
                string content = "";
                while (position != input.Length && input[position] != '\r' && input[position] != '\n')
                {
                    content += input[position];
                    position++;
                }
                current = new Token(TokenType.Comment, content);
            }
            else if (input[position] == '!')
            {
                position++;
                string content = "";
                while (position != input.Length && input[position] != '\r' && input[position] != '\n')
                {
                    content += input[position];
                    position++;
                }
                current = new Token(TokenType.FunctionDefinition, content);
            }
            else
            {
                current = new Token(TokenType.Operator, input[position].ToString());
                position++;
            }
        }
        public Token Current()
        {
            return current;
        }
    }

}

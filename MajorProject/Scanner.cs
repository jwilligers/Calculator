using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MajorProject
{
    class Scanner
    {
        String input;
        int position;
        Token current;

        public Scanner(String _input)
        { // remove whitespace
            input = _input.Replace("\t", "").Replace("\r", ""); 
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
                current = new Token(TokenType.Variable, var);
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

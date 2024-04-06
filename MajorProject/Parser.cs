using PolyLib;
using System;
using System.Collections.Generic;

namespace MajorProject
{
    class Parser
    {
        Scanner scanner;
        VariableTable table;
        public Parser(Scanner _scanner)
        {
            scanner = _scanner;
            table = new VariableTable();
            
        }

        public Worksheet ReadWorksheet()
        {
            List<Line> lines = new List<Line>();
            while (scanner.Current().GetTokenType() != TokenType.Finish)
            {
                lines.Add(ReadLine()); // read every line
            }
            return new Worksheet(lines.ToArray()); 
        }
        public Line ReadLine()
        {
            if (scanner.Current().GetTokenType() == TokenType.Comment)
            {
                String content = scanner.Current().ToString();
                scanner.MoveOn(); // move to next token
                return new CommentLine(content);
            }
            else if (scanner.Current().ToString() == "\n")
            {
                scanner.MoveOn(); // move to next token
                return new EmptyLine(); // detect empty lines
            }
            else
            {
                Expression first = ReadExpression(); 
                if (scanner.Current().ToString() == "=")
                {
                    scanner.MoveOn();
                    Expression second = ReadExpression(); // expression has "="
                    if (scanner.Current().ToString() == "\n")
                    {
                        scanner.MoveOn();
                        return new EquationLine(table, first, second);
                    }
                    else
                    { // There should be an empty line at the end of the worksheet
                        throw new InputException("Missing new line");
                    }
                }
                else
                {
                    if (scanner.Current().ToString() == "\n")
                    {
                        scanner.MoveOn();
                        return new ExpressionLine(first);
                    }
                    else
                    {
                        throw new InputException("Missing new line");
                    }
                }
            }
        }
        public Expression ReadExpression()
        {
            Expression first = ReadTerm();
            while ((scanner.Current().ToString() == "+") || (scanner.Current().ToString() == "-"))
            {
                if (scanner.Current().ToString() == "+")
                { //if the current token is "+", add the expressions on the left and right
                    scanner.MoveOn();
                    Expression second = ReadTerm(); 
                    first = new Addition(first, second);
                }
                else
                { //if the current token is "-", subtract the expressions on the right from the left
                    scanner.MoveOn();
                    Expression second = ReadTerm();
                    first = new Subtraction(first, second);
                }
            }
            return first;           
        }
        public Expression ReadTerm()
        {
            Expression first = ReadFactor();
            while ((scanner.Current().ToString() == "*") || (scanner.Current().ToString() == "/") || 
                   (scanner.Current().ToString() == "(" || (scanner.Current().GetTokenType() == TokenType.Variable)))
            {
                if (scanner.Current().ToString() == "*")
                {
                    scanner.MoveOn();
                    Expression second = ReadFactor();
                    first = new Multiplication(first, second);
                }
                else if (scanner.Current().ToString() == "/")
                {
                    scanner.MoveOn();
                    Expression second = ReadFactor();
                    first = new Division(first, second);
                }
                else
                { 
                    Expression second = ReadFactor();
                    first = new Multiplication(first, second);
                }
            }
            return first;
        }   
        public Expression ReadFactor()
        {
            if (scanner.Current().ToString() == "-")
            {
                scanner.MoveOn();
                Expression factor = ReadFactor();
                return new Subtraction(new Number(new Complex(0.0)), factor);
            } //same as 0-factor
            else
            {
                return ReadPower();
            }
        }
        public Expression ReadPower()
        {
            Expression first = ReadAtom();
            if (scanner.Current().ToString() == "^")
            {  // "^" means the token to the left is raised to the token on the right              
                scanner.MoveOn();
                Expression second = ReadFactor();
                return new Power(first, second);
            }
            else
            {
                return first;

//                return ReadNcr();
            }
        }
        public Expression ReadNpr()
        {
            Expression first = ReadAtom();
            if (scanner.Current().ToString() == "P")
            {  // "P" means permutations
                scanner.MoveOn();
                Expression second = ReadFactor();
                return new Power(first, second);
            }
            else
            {
                return first;
            }
        }
        public Expression ReadNcr()
        {
            Expression first = ReadAtom();
            if (scanner.Current().ToString() == "C")
            {  // "P" means combinations
                scanner.MoveOn();
                Expression second = ReadFactor();
                return new Combination(first, second);
            }
            else
            {
                return first;
            }
        }
        public Expression ReadAtom()
        {
            if (scanner.Current().GetTokenType() == TokenType.Number)
            {
                Expression result = new Number(new Complex(Double.Parse(scanner.Current().ToString())));
                scanner.MoveOn();
                return result;
            }
            else if (scanner.Current().GetTokenType() == TokenType.Variable)
            {
                string name = scanner.Current().ToString();
                scanner.MoveOn();
                switch (name.ToLower()) // special words that cannot be variables
                {
                    case "e": // constant e
                        return new Number(new Complex(Math.E));
                    case "i":
                        return new Number(new Complex(0, 1));
                    case "pi": //constant pi
                        return new Number(new Complex(Math.PI));
                    case "deg": //constant pi
                        return new Number(new Complex(Math.PI/180));
                    case "sin": // sin
                        return new Sin(ReadAtom());
                    case "cos": // cos
                        return new Cos(ReadAtom());
                    case "tan": // tan
                        return new Tan(ReadAtom());
                    case "sinh": // hyperbolic sin
                        return new Sinh(ReadAtom());
                    case "cosh": // hyperbolic cos
                        return new Cosh(ReadAtom());
                    case "tanh": // hyperbolic tan
                        return new Tanh(ReadAtom());
                    case "sech": // hyperbolic sec
                        return new Sech(ReadAtom());
                    case "csch": // hyperbolic cosec
                        return new Csch(ReadAtom());
                    case "coth": // hyperbolic cot
                        return new Coth(ReadAtom());
                    case "asin": // inverse sin
                        return new ASin(ReadAtom());
                    case "acos": // inverse cos
                        return new ACos(ReadAtom());
                    case "atan": // inverse tan
                        return new ATan(ReadAtom());
                    case "exp": // exponential
                        return new Exp(ReadAtom());
                    case "log": // log base 10
                        return new Log(ReadAtom());
                    case "ln": // log base e
                        return new Ln(ReadAtom());
                    case "fact": // Factorial
                        return new Fact(ReadAtom());
                    case "conj": // Conjugate
                        return new Conj(ReadAtom());
                    case "re": // Real component
                        return new Re(ReadAtom());
                    case "im": // Imaginary component
                        return new Im(ReadAtom());
                    case "arg": // Argument
                        return new Arg(ReadAtom());
                    case "sqrt": // Square Root
                        return new Sqrt(ReadAtom());
                    case "square": // Square
                        return new Square(ReadAtom());
                    case "abs": // Absolute Value
                        return new Abs(ReadAtom());
                    case "ceil": // Ceiling
                        return new Ceil(ReadAtom());
                    case "floor": // Floor
                        return new Floor(ReadAtom());
                    case "round": // Round
                        return new Round(ReadAtom());
                    case "inv": // Inverse
                        return new Inv(ReadAtom());
                    
                    default:
                        return new Variable(table, name);
                   }      
            }
            else
            {
                if (!(scanner.Current().ToString() == "("))
                {
                    throw new InputException("Bad input");
                }
                scanner.MoveOn();
                Expression result = ReadExpression();
                if (!(scanner.Current().ToString() == ")"))
                {
                    throw new InputException("Bad input");
                }
                scanner.MoveOn();
                return result; 
            }
        }
        public int lengthOfDictionary()
        {
            List<string> variables = new List<string>();
           
            foreach (KeyValuePair<string, Complex> pair in table)
            {
                variables.Add(pair.Key + " = " + pair.Value.ToString());
            }
            return variables.ToArray().Length;
        }
        public string[] returnValues()
        {
           List<string> variables = new List<string>();
           //System.Windows.Forms.MessageBox.Show("Count = "+table.Count.ToString());
           foreach (KeyValuePair<string,Complex> pair in table)
           {
               string number = pair.Value.ToString();

               variables.Add(pair.Key + " = " + number);           
           }
           return variables.ToArray();
        }
        public double formatOutput(string key, double value)
        {
            return Math.Round(value, 15 - key.Length); 
        }
    }
}
using PolyLib;
using System;
using System.Collections.Generic;

namespace MajorProject
{
    class Parser
    {
        Scanner scanner;
        VariableTable table;
        FunctionTable functionTable;


        static readonly Dictionary<string, UnaryFunctionType> UnaryFunctionMap =
            new(StringComparer.OrdinalIgnoreCase)
        {
            { "sin", UnaryFunctionType.Sin },
            { "cos", UnaryFunctionType.Cos },
            { "tan", UnaryFunctionType.Tan },

            { "asin", UnaryFunctionType.Asin },
            { "acos", UnaryFunctionType.Acos },
            { "atan", UnaryFunctionType.Atan },

            { "exp", UnaryFunctionType.Exp },
            { "ln",  UnaryFunctionType.Ln },

            { "sqrt",   UnaryFunctionType.Sqrt },
            { "square", UnaryFunctionType.Square },
            { "cbrt",   UnaryFunctionType.Cbrt },
            { "cube",   UnaryFunctionType.Cube },

            { "abs",  UnaryFunctionType.Abs },
            { "conj", UnaryFunctionType.Conj },
            { "re",   UnaryFunctionType.Re },
            { "im",   UnaryFunctionType.Im },
            { "arg",  UnaryFunctionType.Arg },

            { "floor", UnaryFunctionType.Floor },
            { "ceil",  UnaryFunctionType.Ceil },
            { "round", UnaryFunctionType.Round },

            { "inv", UnaryFunctionType.Inv }
        };



        public Parser(Scanner _scanner, FunctionTable _functionTable, Boolean insideFunction = false, string argumentName = "")
        {
            scanner = _scanner;
            functionTable = _functionTable;
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
            else if (scanner.Current().GetTokenType() == TokenType.FunctionDefinition)
            {
                String content = scanner.Current().ToString();
                String LHS = content.Split('=')[0].Replace(" ", "");
                String functionName = LHS.Split('(')[0];
                String argument = LHS.Substring(LHS.IndexOf('(')+1, LHS.IndexOf(')')- LHS.IndexOf('(')-1);

                String functionExpression = content.Split('=')[1].Replace(" ", "");
                scanner.MoveOn(); // move to next token
                return new FunctionLine(functionTable, functionName, argument, functionExpression);
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
            // Handle unary minus
            if (scanner.Current().ToString() == "-")
            {
                scanner.MoveOn();
                Expression factor = ReadFactor();
                return new Subtraction(new Number(new Complex(0.0)), factor);
            }

            // Read the core atom / custom operation
            Expression core = ReadCustomOperation();

            // -----------------------------------------
            // 1. SI UNIT SUFFIXES (e.g., 5m, 9.8m/s^2)
            // -----------------------------------------
            while (scanner.Current().GetTokenType() == TokenType.Variable)
            {
                string unitName = scanner.Current().ToString();

                // If it's not a unit, stop
                if (!UnitParser.TryParse(unitName, out Unit unit))
                    break;

                scanner.MoveOn();
                core = new QuantityExpression(core, unit);
            }

            // -----------------------------------------
            // 2. BASE DISPLAY OPERATOR (e.g., x @16)
            // -----------------------------------------
            if (scanner.Current().ToString() == "@")
            {
                scanner.MoveOn();

                if (scanner.Current().GetTokenType() != TokenType.Number)
                    throw new InputException("Base must be a number");

                int numberBase = int.Parse(scanner.Current().ToString());
                scanner.MoveOn();

                core = new DisplayBaseExpression(core, numberBase);
            }

            return core;
        }
        public Expression ReadCustomOperation()
        {
            Expression first = ReadAtom();
            if (scanner.Current().ToString() == "^")
            {  // "^" means the token to the left is raised to the token on the right              
                scanner.MoveOn();
                Expression second = ReadFactor();
                return new Power(first, second);
            }
            else if (scanner.Current().ToString() == "c")
            {  // "^" means the token to the left is raised to the token on the right              
                scanner.MoveOn();
                Expression second = ReadFactor();
                return new Combination(first, second);
            }
            else if (scanner.Current().ToString() == "C")
            {  // "^" means the token to the left is raised to the token on the right              
                scanner.MoveOn();
                Expression second = ReadFactor();
                return new Combination(first, second);
            }
            else if (scanner.Current().ToString() == "p")
            {  // "^" means the token to the left is raised to the token on the right              
                scanner.MoveOn();
                Expression second = ReadFactor();
                return new Permutation(first, second);
            }
            else if (scanner.Current().ToString() == "P")
            {  // "^" means the token to the left is raised to the token on the right              
                scanner.MoveOn();
                Expression second = ReadFactor();
                return new Permutation(first, second);
            }
            else
            {
                return first;
            }
        }

        public Expression ReadAtom()
        {
            var token = scanner.Current();

            // -----------------------------
            // 1. NUMBER
            // -----------------------------
            if (token.GetTokenType() == TokenType.Number)
            {
                var value = new Number(new Complex(double.Parse(token.ToString())));
                scanner.MoveOn();
                return value;
            }

            // -----------------------------
            // 2. VARIABLE OR FUNCTION NAME
            // -----------------------------
            if (token.GetTokenType() == TokenType.Variable)
            {
                string name = token.ToString();
                scanner.MoveOn();

                // -----------------------------------------
                // 2A. FUNCTION CALL: name(...)
                // -----------------------------------------
                if (scanner.Current().ToString() == "(")
                {
                    scanner.MoveOn(); // consume '('

                    List<Expression> args = new List<Expression>();

                    // Parse argument list
                    if (scanner.Current().ToString() != ")")
                    {
                        args.Add(ReadExpression());

                        while (scanner.Current().ToString() == ",")
                        {
                            scanner.MoveOn(); // consume comma
                            args.Add(ReadExpression());
                        }
                    }

                    if (scanner.Current().ToString() != ")")
                        throw new InputException("Missing ')' in function call");

                    scanner.MoveOn(); // consume ')'

                    string lower = name.ToLower();

                    // 1. Built-in unary function
                    if (UnaryFunctionMap.TryGetValue(lower, out var unaryType))
                    {
                        if (args.Count != 1)
                            throw new Exception($"{name}() takes exactly 1 argument");

                        return new UnaryFunction(unaryType, args[0]);
                    }

                    // 2. Built-in multi-argument function
                    if (MultiFunctionRegistry.Registry.ContainsKey(lower))
                    {
                        return new MultiFunction(name, args);
                    }

                    // 3. User-defined function (single argument for now)
                    if (functionTable.TryGetValue(name, out var def))
                    {
                        return new CustomFunction(name, def, args);
                    }

                    throw new Exception($"Unknown function '{name}'");
                }

                // -----------------------------------------
                // 2B. CONSTANTS
                // -----------------------------------------
                switch (name.ToLower())
                {
                    case "e": return new Number(new Complex(Math.E));
                    case "i": return new Number(new Complex(0, 1));
                    case "pi": return new Number(new Complex(Math.PI));
                    case "deg": return new Number(new Complex(Math.PI / 180));
                }

                // -----------------------------------------
                // 2C. VARIABLE
                // -----------------------------------------
                return new Variable(table, name);
            }

            // -----------------------------
            // 3. PARENTHESIZED EXPRESSION
            // -----------------------------
            if (token.ToString() == "(")
            {
                scanner.MoveOn();
                Expression inner = ReadExpression();

                if (scanner.Current().ToString() != ")")
                    throw new InputException("Missing ')'");

                scanner.MoveOn();
                return inner;
            }

            // -----------------------------
            // 4. INVALID TOKEN
            // -----------------------------
            throw new InputException("Bad input");
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
        public string[] returnFunctions()
        {
            List<string> functions = new List<string>();
            //System.Windows.Forms.MessageBox.Show("Count = "+table.Count.ToString());
            foreach (KeyValuePair<string, FunctionDefinition> pair in functionTable)
            {
                functions.Add(pair.Key + " = " + pair.Value);
            }
            return functions.ToArray();
        }
        public string[] returnValues()
        {
            List<string> variables = new List<string>();

            foreach (var pair in table)
            {
                string name = pair.Key;

                // Build an expression so we can read its unit
                Expression expr = new Variable(table, name);

                string value = expr.Value().ToString();
                string unit = expr.GetUnit().ToString();

                // Pretty aligned output
                variables.Add($"{name,-12} {value,-20} {unit}");
            }

            return variables.ToArray();
        }
        public double formatOutput(string key, double value)
        {
            return Math.Round(value, 15 - key.Length); 
        }
    }
}
using System;
using System.Runtime.InteropServices.WindowsRuntime;
using PolyLib;

namespace MajorProject
{
    abstract class Function : Expression
    {
        protected Expression expr;

        public double Round(double value)
        {
            if (Math.Abs(value) < Math.Pow(10, -10))
            {
                return 0;
            }
            else
            {
                return value;
            }
        }

        public Function(Expression _expr)
        {
            expr = _expr;
        }

        public Expression Argument()
        {
            return expr;
        }
        public Function Inverse(Expression RHS)
        {
            switch (this.GetType().Name.ToLower())
            {
                case "sin": // sin
                    return new ASin(RHS);
                case "cos": // cos
                    return new ACos(RHS);
                case "tan": // tan
                    return new ATan(RHS);
                case "asin": // inverse sin
                    return new Sin(RHS);
                case "acos": // inverse cos
                    return new Cos(RHS);
                case "atan": // inverse tan
                    return new Tan(RHS);
                case "exp": // exponential
                    return new Ln(RHS);
                case "ln": // log base e
                    return new Exp(RHS);
                case "conj": //Conjugate
                    return new Conj(RHS);
                case "sqrt":
                    return new Square(RHS);
                case "square":
                    return new Sqrt(RHS);
                default:
                    throw new Exception("Unknown function");
            }
        }
    }

    class Sin : Function
    {

        public Sin(Expression _expr)
            : base(_expr)
        {
        }
        public override Complex Value()
        {
            return Complex.Sin(expr.Value());
        }
        override public string ToString()
        {
            return "sin(" + expr.ToString() + ")";
        }

    }
    class Cos : Function
    {
        public Cos(Expression _expr)
            : base(_expr)
        {
        }

        public override Complex Value()
        {
            return Complex.Cos(expr.Value());
        }
        override public string ToString()
        {
            return "cos(" + expr.ToString() + ")";
        }

    }
    class Tan : Function
    {
        public Tan(Expression _expr)
            : base(_expr)
        {
        }

        public override Complex Value()
        {
            return Complex.Tan(expr.Value());
        }
        override public string ToString()
        {
            return "tan(" + expr.ToString() + ")";
        }
    }
    class Sinh : Function
    {
        public Sinh(Expression _expr)
            : base(_expr)
        {
        }

        public override Complex Value()
        {
            return Complex.Sinh(expr.Value());
        }
        override public string ToString()
        {
            return "sinh(" + expr.ToString() + ")";
        }
    }
    class Cosh : Function
    {
        public Cosh(Expression _expr)
            : base(_expr)
        {
        }

        public override Complex Value()
        {
            return Complex.Cosh(expr.Value());
        }
        override public string ToString()
        {
            return "cosh(" + expr.ToString() + ")";
        }
    }
    class Tanh : Function
    {
        public Tanh(Expression _expr)
            : base(_expr)
        {
        }

        public override Complex Value()
        {
            return Complex.Tanh(expr.Value());
        }
        override public string ToString()
        {
            return "tanh(" + expr.ToString() + ")";
        }
    }
    class Sech : Function
    {
        public Sech(Expression _expr)
            : base(_expr)
        {
        }

        public override Complex Value()
        {
            return Complex.Sech(expr.Value());
        }
        override public string ToString()
        {
            return "sech(" + expr.ToString() + ")";
        }
    }
    class Csch : Function
    {
        public Csch(Expression _expr)
            : base(_expr)
        {
        }

        public override Complex Value()
        {
            return Complex.Csch(expr.Value());
        }
        override public string ToString()
        {
            return "csch(" + expr.ToString() + ")";
        }
    }
    class Coth : Function
    {
        public Coth(Expression _expr)
            : base(_expr)
        {
        }

        public override Complex Value()
        {
            return Complex.Coth(expr.Value());
        }
        override public string ToString()
        {
            return "coth(" + expr.ToString() + ")";
        }
    }
    class Arg : Function
    {
        public Arg(Expression _expr)
            : base(_expr)
        {
        }

        public override Complex Value()
        {
            return new Complex(Complex.Arg(expr.Value()));
        }
        override public string ToString()
        {
            return "arg(" + expr.ToString() + ")";
        }
    }

    class Floor : Function
    {
        public Floor(Expression _expr)
            : base(_expr)
        {
        }

        public override Complex Value()
        {
            return Complex.Floor(expr.Value());
        }
        override public string ToString()
        {
            return "floor(" + expr.ToString() + ")";
        }
    }
    class Ceil : Function
    {
        public Ceil(Expression _expr)
            : base(_expr)
        {
        }

        public override Complex Value()
        {
            return Complex.Ceil(expr.Value());
        }
        override public string ToString()
        {
            return "ceil(" + expr.ToString() + ")";
        }
    }
    class Round : Function
    {
        public Round(Expression _expr)
            : base(_expr)
        {
        }

        public override Complex Value()
        {
            return Complex.Round(expr.Value());
        }
        override public string ToString()
        {
            return "round(" + expr.ToString() + ")";
        }
    }

    class ASin : Function
    {
        public ASin(Expression _expr)
            : base(_expr)
        {
        }

        public override Complex Value()
        {
            return Complex.ASin(expr.Value());
            //return Math.Asin(expr.Value());
        }
        override public string ToString()
        {
            return "asin(" + expr.ToString() + ")";
        }

    }
    class ACos : Function
    {

        public ACos(Expression _expr)
            : base(_expr)
        {
        }

        public override Complex Value()
        {

            return Complex.ACos(expr.Value());
            //return Complex.Acos(expr.Value());
        }
        override public string ToString()
        {
            return "acos(" + expr.ToString() + ")";
        }

    }
    class ATan : Function
    {
        public ATan(Expression _expr)
            : base(_expr)
        {
        }

        public override Complex Value()
        {
            if (expr.Value() != (Math.PI/2))
            {
                return Complex.ATan(expr.Value());
                //return Round(Math.Atan(expr.Value()));
            }
            else
            {
                return new Complex(0);
            }
        }
        override public string ToString()
        {
            return "atan(" + expr.ToString() + ")";
        }

    }
    class Re : Function
    {
        public Re(Expression _expr)
            : base(_expr)
        {
        }

        public override Complex Value()
        {
            return new Complex(expr.Value().Re);
        }
        override public string ToString()
        {
            return "Re(" + expr.ToString() + ")";
        }

    }
    class Im : Function
    {
        public Im(Expression _expr)
            : base(_expr)
        {
        }

        public override Complex Value()
        {
            return new Complex(expr.Value().Im);
        }
        override public string ToString()
        {
            return "Im(" + expr.ToString() + ")";
        }

    }
    class Ln : Function
    {
        public Ln(Expression _expr)
            : base(_expr)
        {
        }

        public override Complex Value()
        {
            return Complex.Log(expr.Value());
        }
        override public string ToString()
        {
            return "ln(" + expr.ToString() + ")";
        }

    }
    class Exp : Function
    {
        public Exp(Expression _expr)
            : base(_expr)
        {
        }

        public override Complex Value()
        {
            return Complex.Exp(expr.Value());
        }

        override public string ToString()
        {
            return "exp(" + expr.ToString() + ")";
        }
    }
    class Log : Function
    {
        public Log(Expression _expr)
            : base(_expr)
        {
        }

        public override Complex Value()
        {
            return Complex.Log(expr.Value()/Complex.Log(new Complex(10)));
        }
        override public string ToString()
        {
            return "ln(" + expr.ToString() + ")";
        }

    }
    class Fact : Function
    {
        public Fact(Expression _expr)
            : base(_expr)
        {
        }

        public override Complex Value()
        {
            return new Complex(fact(int.Parse(expr.Value().ToString())));
        }
        public int fact(int x)
        {
            int fact = 1;
            int i = 1;
            while (i <= x)
            {
                fact = fact * i;
                i++;

            }
            return fact;
        }

        override public string ToString()
        {
            return "fact(" + expr.ToString() + ")";
        }
    }
    class Conj : Function
    {
        public Conj(Expression _expr)
            : base(_expr)
        {
        }

        public override Complex Value()
        {
            return Complex.Conj(expr.Value());
        }
        override public string ToString()
        {
            return "conj(" + expr.ToString() + ")";
        }
    }
    class Sqrt : Function
    {
        public Sqrt(Expression _expr)
            : base(_expr)
        {
        }

        public override Complex Value()
        {
            return Complex.Sqrt(expr.Value());
        }
        override public string ToString()
        {
            return "sqrt(" + expr.ToString() + ")";
        }
    }
    class CustomFunction : Function
    {
        new readonly Expression expr;
        Expression equation;
        public CustomFunction(string functionName, Expression _equation, Expression _expr)
            : base(_expr)
        {
            expr = _expr;
            equation = _equation;
        }

        public override Complex Value()
        {
            return equation.Value();
            //ExpressionLine line = new ExpressionLine(equation.Replace("x", expr.ToString()));
            //return line.Result().Value();
        }
        override public string ToString()
        {
            return "functionName(" + expr.ToString() + ")";
        }
    }
    class Square : Function
    {
        public Square(Expression _expr)
            : base(_expr)
        {
        }

        public override Complex Value()
        {
            return Complex.Pow(expr.Value(), 2);
        }
        override public string ToString()
        {
            return "square(" + expr.ToString() + ")";
        }
    }
    class Abs : Function
    {
        public Abs(Expression _expr)
            : base(_expr)
        {
        }

        public override Complex Value()
        {
            return new Complex(Complex.Abs(expr.Value()));
        }
        override public string ToString()
        {
            return "abs(" + expr.ToString() + ")";
        }
    }
    class Inv : Function
    {
        public Inv(Expression _expr)
            : base(_expr)
        {
        }

        public override Complex Value()
        {
            return Complex.Inv(expr.Value());
        }
        override public string ToString()
        {
            return "inv(" + expr.ToString() + ")";
        }
    }
}

    
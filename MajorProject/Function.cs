using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            switch (this.GetType().Name)
            {
                case "Sin": // sin
                    return new ASin(RHS);
                case "Cos": // cos
                    return new ACos(RHS);
                case "Tan": // tan
                    return new ATan(RHS);
                case "ASin": // inverse sin
                    return new Sin(RHS);
                case "ACos": // inverse cos
                    return new Cos(RHS);
                case "ATan": // inverse tan
                    return new Tan(RHS);
                case "Exp": // exponential
                    return new Ln(RHS);
                case "Ln": // log base e
                    return new Exp(RHS);
                case "fact": // factorial
                    return new Fact(RHS);
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
        public override double Value()
        {
                return Round(Math.Sin(expr.Value()));
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

        public override double Value()
        {
            return Round(Math.Cos(expr.Value()));
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

        public override double Value()
        {
            return Round(Math.Tan(expr.Value()));
        }
        override public string ToString()
        {
            return "tan(" + expr.ToString() + ")";
        }

    }
    class ASin : Function
    {
        public ASin(Expression _expr)
            : base(_expr)
        {
        }

        public override double Value()
        {
            return Round(Math.Asin(expr.Value()));
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

        public override double Value()
        {
            return Round(Math.Acos(expr.Value()));
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

        public override double Value()
        {
            if (expr.Value() != (Math.PI/2))
            {
                return Round(Math.Atan(expr.Value()));
            }
            else
            {
                return 0;
            }
        }
        override public string ToString()
        {
            return "atan(" + expr.ToString() + ")";
        }

    }
    class Ln : Function
    {
        public Ln(Expression _expr)
            : base(_expr)
        {
        }

        public override double Value()
        {
            return Math.Log(expr.Value());
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

        public override double Value()
        {
            return Math.Exp(expr.Value());
        }

        override public string ToString()
        {
            return "exp(" + expr.ToString() + ")";
        }
    }
    class Fact : Function
    {
        public Fact(Expression _expr)
            : base(_expr)
        {
        }

        public override double Value()
        {
            return fact(int.Parse(expr.Value().ToString()));
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
}

    
using PolyLib;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.InteropServices.WindowsRuntime;

namespace MajorProject
{
    public abstract class Function : Expression
    {
        protected readonly Expression expr;

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

    

        protected Function(Expression expr)
        {
            this.expr = expr;
        }

        public Expression Argument() => expr;

        public abstract Function Inverse(Expression rhs);
        

        public static class FunctionMetadata
        {
            private static readonly Dictionary<UnaryFunctionType, UnaryFunctionType> _inverse =
                new()
                {
            { UnaryFunctionType.Sin,   UnaryFunctionType.Asin },
            { UnaryFunctionType.Cos,   UnaryFunctionType.Acos },
            { UnaryFunctionType.Tan,   UnaryFunctionType.Atan },
            { UnaryFunctionType.Asin,  UnaryFunctionType.Sin },
            { UnaryFunctionType.Acos,  UnaryFunctionType.Cos },
            { UnaryFunctionType.Atan,  UnaryFunctionType.Tan },
            { UnaryFunctionType.Exp,   UnaryFunctionType.Ln },
            { UnaryFunctionType.Ln,    UnaryFunctionType.Exp },
            { UnaryFunctionType.Sqrt,  UnaryFunctionType.Square },
            { UnaryFunctionType.Square,UnaryFunctionType.Sqrt },
            { UnaryFunctionType.Cube,UnaryFunctionType.Cbrt },
                    // etc.
                };

        }

    }
}

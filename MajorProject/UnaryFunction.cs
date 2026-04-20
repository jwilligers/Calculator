using PolyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MajorProject
{
    public enum UnaryFunctionType
    {
        Sin, Cos, Tan,
        Asin, Acos, Atan,
        Sinh, Cosh, Tanh,
        Sech, Csch, Coth,
        Exp, Ln, Log10,
        Sqrt, Square, Cube, Cbrt,
        Abs, Arg, Re, Im,
        Conj, Inv,
        Floor, Ceil, Round,
        Fact,
        Custom
    }

    public class UnaryFunction : Function
    {
        public UnaryFunctionType Type { get; }

        public UnaryFunction(UnaryFunctionType type, Expression expr) : base(expr)
        {
            Type = type;
        }

        public override Complex Value()
        {
            var v = expr.Value();

            return Type switch
            {
                UnaryFunctionType.Sin => Complex.Sin(v),
                UnaryFunctionType.Cos => Complex.Cos(v),
                UnaryFunctionType.Tan => Complex.Tan(v),

                UnaryFunctionType.Asin => Complex.ASin(v),
                UnaryFunctionType.Acos => Complex.ACos(v),
                UnaryFunctionType.Atan => Complex.ATan(v),

                UnaryFunctionType.Exp => Complex.Exp(v),
                UnaryFunctionType.Ln => Complex.Ln(v),

                UnaryFunctionType.Sqrt => Complex.Sqrt(v),
                UnaryFunctionType.Square => v * v,

                UnaryFunctionType.Cbrt => Complex.Pow(v, 1.0 / 3.0),
                UnaryFunctionType.Cube => v * v * v,

                UnaryFunctionType.Abs => new Complex(Complex.Abs(v)),
                UnaryFunctionType.Conj => Complex.Conj(v),

                UnaryFunctionType.Re => new Complex(v.Re),
                UnaryFunctionType.Im => new Complex(v.Im),
                UnaryFunctionType.Arg => new Complex(Complex.Arg(v)),

                UnaryFunctionType.Floor => Complex.Floor(v),
                UnaryFunctionType.Ceil => Complex.Ceil(v),
                UnaryFunctionType.Round => Complex.Round(v),

                UnaryFunctionType.Inv => Complex.Inv(v),

                _ => throw new Exception("Unknown unary function")
            };
        }

        public override string ToString()
        {
            return $"{Type.ToString().ToLower()}({expr})";
        }
        public override Function Inverse(Expression rhs)
        {
            if (rhs is UnaryFunction uf)
                return UnaryFunctionMetadata.Inverse(uf, rhs);

            throw new Exception("Inverse not supported for this function type");
        }
    }
    static class UnaryFunctionMetadata
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

            { UnaryFunctionType.Cube,  UnaryFunctionType.Cbrt },
            { UnaryFunctionType.Cbrt,  UnaryFunctionType.Cube }
            };

        public static UnaryFunction Inverse(UnaryFunction f, Expression rhs)
        {
            if (!_inverse.TryGetValue(f.Type, out var inv))
                throw new InvalidOperationException($"No inverse defined for {f.Type}");

            return new UnaryFunction(inv, rhs);
        }
    }

}

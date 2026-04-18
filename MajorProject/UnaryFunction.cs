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
        Sqrt, Square,
        Abs, Arg, Re, Im,
        Conj, Inv,
        Floor, Ceil, Round,
        Fact,
        Custom
    }

    public class UnaryFunction
    {
        public UnaryFunctionType Type { get; }
        public Expression Argument { get; }
        public Func<Complex, Complex>? CustomImpl { get; }

        public UnaryFunction(UnaryFunctionType type, Expression argument, Func<Complex, Complex>? customImpl = null)
        {
            Type = type;
            Argument = argument;
            CustomImpl = customImpl;
        }

        public Complex Value()
        {
            var z = Argument.Value();
            return Type switch
            {
                UnaryFunctionType.Sin => Complex.Sin(z),
                UnaryFunctionType.Cos => Complex.Cos(z),
                UnaryFunctionType.Tan => Complex.Tan(z),
                UnaryFunctionType.Asin => Complex.ASin(z),
                UnaryFunctionType.Acos => Complex.ACos(z),
                UnaryFunctionType.Atan => Complex.ATan(z),
                UnaryFunctionType.Sinh => Complex.Sinh(z),
                UnaryFunctionType.Cosh => Complex.Cosh(z),
                UnaryFunctionType.Tanh => Complex.Tanh(z),
                UnaryFunctionType.Sech => Complex.Sech(z),
                UnaryFunctionType.Csch => Complex.Csch(z),
                UnaryFunctionType.Coth => Complex.Coth(z),
                UnaryFunctionType.Exp => Complex.Exp(z),
                UnaryFunctionType.Ln => Complex.Log(z),
                UnaryFunctionType.Log10 => Complex.Log(z) / Complex.Log(new Complex(10)),
                UnaryFunctionType.Sqrt => Complex.Sqrt(z),
                UnaryFunctionType.Square => Complex.Pow(z, 2),
                UnaryFunctionType.Abs => new Complex(Complex.Abs(z)),
                UnaryFunctionType.Arg => new Complex(Complex.Arg(z)),
                UnaryFunctionType.Re => new Complex(z.Re),
                UnaryFunctionType.Im => new Complex(z.Im),
                UnaryFunctionType.Conj => Complex.Conj(z),
                UnaryFunctionType.Inv => Complex.Inv(z),
                UnaryFunctionType.Floor => Complex.Floor(z),
                UnaryFunctionType.Ceil => Complex.Ceil(z),
                UnaryFunctionType.Round => Complex.Round(z),
                UnaryFunctionType.Custom when CustomImpl != null => CustomImpl(z),
                _ => throw new NotSupportedException($"Unsupported function type {Type}")
            };
        }

    }

}

using PolyLib;
using System;

namespace MajorProject
{
    class Power : Operation
    {
        public Power(Expression _left, Expression _right)
            : base(_left, _right)
        {
        }
        public override Complex Value()
        {
            return Complex.Pow(left.Value(), right.Value());
        }
        override public string ToString()
        {
            return "(" + left.ToString() + "^" + right.ToString() + ")";
        }
        public override EquationLine IsolateLeft(VariableTable table, Expression rhs)
        {
            // left^right = rhs
            // right * ln(left) = ln(rhs)
            return new EquationLine(
                table,
                new Multiplication(right, new UnaryFunction(UnaryFunctionType.Ln, left)),
                new UnaryFunction(UnaryFunctionType.Ln, rhs)
            );
        }

        public override EquationLine IsolateRight(VariableTable table, Expression rhs)
        {
            // left^right = rhs
            // right * ln(left) = ln(rhs)
            return new EquationLine(
                table,
                new Multiplication(right, new UnaryFunction(UnaryFunctionType.Ln, left)),
                new UnaryFunction(UnaryFunctionType.Ln, rhs)
            );
        }
        public override Unit GetUnit()
        {
            var baseUnit = left.GetUnit();
            var expUnit = right.GetUnit();

            if (!expUnit.IsDimensionless())
                throw new Exception("Exponent must be dimensionless");

            int exp = (int)right.Value().Re;
            return baseUnit.Pow(exp);
        }
    }

}
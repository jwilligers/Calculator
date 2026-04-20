using PolyLib;
using System;
using System.Linq;

namespace MajorProject
{
    class Subtraction : Operation
    {
        public Subtraction(Expression _left, Expression _right)
            : base(_left, _right)
        {
        }

        override public Complex Value()
        {
            return left.Value() - right.Value();
        }
        override public string ToString()
        {
            return "(" + left.ToString() + "-" + right.ToString() + ")";
        }

        public override EquationLine IsolateLeft(VariableTable table, Expression rhs)
        {
            // x - right = rhs  →  x = rhs + right
            return new EquationLine(table, left, new Addition(rhs, right));
        }

        public override EquationLine IsolateRight(VariableTable table, Expression rhs)
        {
            // left - x = rhs  →  x = left - rhs
            return new EquationLine(table, right, new Subtraction(left, rhs));
        }
        public override Unit GetUnit()
        {
            var lu = left.GetUnit();
            var ru = right.GetUnit();
            // Simple rule: units must match
            if (!lu.IsDimensionless() || !ru.IsDimensionless())
            {
                if (!lu.Dimensions.SequenceEqual(ru.Dimensions))
                    throw new Exception("Unit mismatch in addition");
            }
            return lu;
        }
    }
}

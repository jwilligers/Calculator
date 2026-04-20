using PolyLib;
using System;
using System.Linq;

namespace MajorProject
{
    class Addition : Operation
    {
        public Addition(Expression _left, Expression _right) 
            : base(_left, _right)
        {
        }
        override public Complex Value()
        {
            return left.Value() + right.Value();
        }
        override public string ToString()
        {
            return "(" + left.ToString() + "+" + right.ToString() + ")";
        }

        public override EquationLine IsolateLeft(VariableTable table, Expression rhs)
        {
            // x + right = rhs  →  x = rhs - right
            return new EquationLine(table, left, new Subtraction(rhs, right));
        }

        public override EquationLine IsolateRight(VariableTable table, Expression rhs)
        {
            // left + x = rhs  →  x = rhs - left
            return new EquationLine(table, right, new Subtraction(rhs, left));
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

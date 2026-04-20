using System;

namespace MajorProject
{
    abstract class Operation : Expression
    {
        protected Expression left, right;

        public Operation(Expression _left, Expression _right)
        {
            left = _left;
            right = _right;
        }
        public Expression GetLeft()
        {
            return left;
        }

        public abstract EquationLine IsolateLeft(VariableTable table, Expression rhs);
        public abstract EquationLine IsolateRight(VariableTable table, Expression rhs);

        public Expression GetRight()
        {
            return right;
        }
    }
}

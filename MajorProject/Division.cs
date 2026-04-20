using PolyLib;

namespace MajorProject
{
    class Division : Operation
    {
        public Division(Expression _left, Expression _right)
            : base(_left, _right)
        {
        }
        override public Complex Value()
        {
            return left.Value() / right.Value();
        }
        override public string ToString()
        {
            return "(" + left.ToString() + "/" + right.ToString() + ")";
        }

        public override EquationLine IsolateLeft(VariableTable table, Expression rhs)
        {
            // x / right = rhs  →  x = rhs * right
            return new EquationLine(table, left, new Multiplication(rhs, right));
        }

        public override EquationLine IsolateRight(VariableTable table, Expression rhs)
        {
            // left / x = rhs  →  x = left / rhs
            return new EquationLine(table, right, new Division(left, rhs));
        }
        public override Unit GetUnit()
        {
            return left.GetUnit() / right.GetUnit();
        }
    }
}

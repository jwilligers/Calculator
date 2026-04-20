using PolyLib;

namespace MajorProject
{
    class Multiplication : Operation
    {
        public Multiplication(Expression _left, Expression _right)
            : base(_left, _right)
        {
        }
        override public Complex Value()
        {
            return left.Value() * right.Value();
        }

        override public string ToString()
        {
            return "(" + left.ToString() + "*" + right.ToString() + ")";
        }
        public override EquationLine IsolateLeft(VariableTable table, Expression rhs)
        {
            // x * right = rhs  →  x = rhs / right
            return new EquationLine(table, left, new Division(rhs, right));
        }

        public override EquationLine IsolateRight(VariableTable table, Expression rhs)
        {
            // left * x = rhs  →  x = rhs / left
            return new EquationLine(table, right, new Division(rhs, left));
        }
        public override Unit GetUnit()
        {
            return left.GetUnit() * right.GetUnit();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        public EquationLine isolateLeft(VariableTable table, Expression RHS)
        {
            switch (this.GetType().Name)
            {
                case "Addition":
                    return new EquationLine(table, left, new Subtraction(RHS, right));
                case "Subtraction":
                    return new EquationLine(table, left, new Addition(RHS, right));
                case "Multiplication":
                    return new EquationLine(table, left, new Division(RHS, right));
                case "Division":
                    return new EquationLine(table, left, new Multiplication(RHS, right));
                case "Power":
                    return new EquationLine(table, new Multiplication(right, new Ln(left)), new Ln(RHS));
                default:
                    throw new Exception("Unknown operator");
            }
        }
        public EquationLine isolateRight(VariableTable table, Expression RHS)
        {
            switch (this.GetType().Name)
            {
                case "Addition":
                    return new EquationLine(table, right, new Subtraction(RHS, left));
                case "Subtraction":
                    return new EquationLine(table, right, new Subtraction(left, RHS)); // left minus RHS is variable
                case "Multiplication":
                    return new EquationLine(table, right, new Division(RHS, left));
                case "Division":
                    return new EquationLine(table, right, new Division(left, RHS)); // left on RHS is variable
                case "Power":
                    return new EquationLine(table, new Multiplication(right, new Ln(left)), new Ln(RHS));
                default:
                    throw new Exception("Unknown operator");
            }
        }
        public Expression GetRight()
        {
            return right;
        }
    }
}

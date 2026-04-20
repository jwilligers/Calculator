using System;
using PolyLib;

namespace MajorProject
{
    class EquationLine : Line
    {
        VariableTable table;
        Expression left, right;

        public EquationLine(VariableTable _table, Expression _left, Expression _right)
        {
            table = _table;
            left = _left;
            right = _right;
        }
        public String Solve()
        {
            try
            {
                Complex rhsValue = right.Value();
                if (left is Number)
                {
                    throw new SolvedException();
                }
                if (left is Variable v)
                {
                    if (((Variable)left).IsSet())
                    {
                        throw new SolvedException();
                    }
                    table.setValue(left.ToString(), rhsValue);
                    return left.ToString() + " = " + rhsValue;
                }
                else if (left is Function)
                {
                    return new EquationLine(table, ((Function)left).Argument(), ((Function)left).Inverse(right)).Solve();
                }
                else if (left is Operation op)
                {
                    try
                    {
                        // If left side of the operation is known, variable must be on the right
                        Complex _ = op.GetLeft().Value();
                        return op.IsolateRight(table, right).Solve();
                    }
                    catch (UnknownVariableException)
                    {
                        // Otherwise, assume variable is on the left
                        Complex _ = op.GetRight().Value();
                        return op.IsolateLeft(table, right).Solve();
                    }
                }
                else
                {
                    throw new Exception("Unexpected expression in equation");
                }
            }
            catch (UnknownVariableException)
            {
                Complex leftValue = left.Value();
                return new EquationLine(table, right, left).Solve();
            }
        }
        override public string ToString()
        {
            return left.ToString() + " = " + right.ToString() + "\r\n";
        }
    }
}

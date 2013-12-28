using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
                double rhsValue = right.Value();
                if (left is Number)
                {
                    throw new SolvedException();
                }
                if (left is Variable)
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
                else if (left is Operation)
                {
                    Operation LHS = (Operation)left;
                    try
                    {
                        double leftValue = LHS.GetLeft().Value();
                        return LHS.isolateRight(table, right).Solve();
                    }
                    catch (UnknownVariableException)
                    {
                        double rightValue = LHS.GetRight().Value();
                        return LHS.isolateLeft(table, right).Solve();
                    }
                    //    new EquationLine(table, ((Function)left).Argument(), ((Function)left).Inverse(right)).Solve();
                }
                else
                {
                    throw new Exception("Unexpected expression in equation");
                }
            }
            catch (UnknownVariableException)
            {
                double leftValue = left.Value();
                return new EquationLine(table, right, left).Solve();
            }
        }
        override public string ToString()
        {
            return left.ToString() + " = " + right.ToString() + "\r\n";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PolyLib;

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
    }
}

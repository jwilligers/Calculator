using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MajorProject
{
    class Division : Operation
    {
        public Division(Expression _left, Expression _right)
            : base(_left, _right)
        {
        }
        override public double Value()
        {
            return left.Value() / right.Value();
        }
        override public string ToString()
        {
            return "(" + left.ToString() + "/" + right.ToString() + ")";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MajorProject
{
    class Power : Operation
    {
        public Power(Expression _left, Expression _right)
            : base(_left, _right)
        {
        }
        public override double Value()
        {
            return Math.Pow(left.Value(), right.Value());
        }
        override public string ToString()
        {
            return "(" + left.ToString() + "^" + right.ToString() + ")";
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PolyLib;

namespace MajorProject
{
    class Power : Operation
    {
        public Power(Expression _left, Expression _right)
            : base(_left, _right)
        {
        }
        public override Complex Value()
        {
            return Complex.Pow(left.Value(), right.Value());
        }
        override public string ToString()
        {
            return "(" + left.ToString() + "^" + right.ToString() + ")";
        }
    }
}
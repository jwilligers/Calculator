﻿using PolyLib;

namespace MajorProject
{
    class Addition : Operation
    {
        public Addition(Expression _left, Expression _right) 
            : base(_left, _right)
        {
        }
        override public Complex Value()
        {
            return left.Value() + right.Value();
        }
        override public string ToString()
        {
            return "(" + left.ToString() + "+" + right.ToString() + ")";
        }
    }
}

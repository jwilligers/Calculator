using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MajorProject
{
    class Number : Expression
    {
        double value;

        public Number(double _value)
        {
            value = _value;
        }
        public override double Value()
        {
            return value;
        }
        override public string ToString()
        {
            return value.ToString();
        }
    }
}

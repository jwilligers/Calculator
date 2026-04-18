using PolyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajorProject
{
    internal sealed class Quantity
    {
        public Complex Value { get; }
        public Unit Unit { get; }

        public Quantity(Complex value, Unit unit)
        {
            Value = value;
            Unit = unit;
        }

        public override string ToString() => $"{Value} {Unit}";
    }

}

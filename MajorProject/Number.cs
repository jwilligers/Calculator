using PolyLib;

namespace MajorProject
{
    class Number : Expression
    {
        Complex value;

        public Number(Complex _value)
        {
            value = _value;
        }
        public override Complex Value()
        {
            return value;
        }
        public Expression ComplexToNumber(Complex complex)
        {
            return new Number(complex);
        }
        override public string ToString()
        {
            return value.ToString();
        }
    }
}

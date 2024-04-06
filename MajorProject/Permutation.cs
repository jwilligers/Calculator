using PolyLib;

namespace MajorProject
{
    class Combination : Operation
    {
        public Combination(Expression _left, Expression _right)
            : base(_left, _right)
        {
        }
        public int fact(int x)
        {
            int fact = 1;
            int i = 1;
            while (i <= x)
            {
                fact = fact * i;
                i++;

            }
            return fact;
        }
        public int fact(Complex c)
        {
            return fact(int.Parse(c.ToString()));
        }

        public override Complex Value()
        {
            return new Complex(fact(left.Value()) / fact(left.Value() - right.Value()));
        }
        override public string ToString()
        {
            return "(" + left.ToString() + "C" + right.ToString() + ")";
        }
    }
}
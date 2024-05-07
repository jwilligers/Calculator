using MajorProject.Polynomial;
using System;

namespace MajorProject
{
    class PolynomialLine : Line
    {
        String content;
        Polynomial.Polynomial polynomial;

        public PolynomialLine(String _content)
        {
            content = _content;
            polynomial = new Polynomial.Polynomial(content);
        }
        public String Content()
        {
            return content;
        }
        override public string ToString()
        {
            return polynomial.ToString() + " " + polynomial.Evaluate(new PolyLib.Complex(10));
        }
    }

}

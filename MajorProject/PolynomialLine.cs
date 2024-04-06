using System;

namespace MajorProject
{
    class PolynomialLine : Line
    {
        String content;

        public PolynomialLine(String _content)
        {
            content = _content;
        }
        public String Content()
        {
            return content;
        }
        override public string ToString()
        {
            return content;
        }
    }

}

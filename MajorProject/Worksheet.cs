using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MajorProject
{
    class Worksheet
    {
        Line[] lines;

        public Worksheet(Line[] _lines)
        {
            lines = _lines;
        }

        public override string ToString()
        {
            string result = "";
            foreach (Line line in lines)
            {
                result += line.ToString();
            }
            return result;
        }
        public int NumLines()
        {
            return lines.Length;
        }
        public Line GetLine(int index)
        {
            return lines[index];
        }
    }
}

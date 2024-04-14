using System.Collections.Generic;
using PolyLib;
using MajorProject.Polynomial;

namespace MajorProject
{
    class FunctionTable:Dictionary<string,Polynomial.Polynomial>
    {
        public FunctionTable()
        {
        }
        public bool hasValue(string name)
        {
            return ContainsKey(name);
        }
        public Polynomial.Polynomial lookUpValue(string name)
        {
            return this[name];
        }
        public void setValue(string name, Polynomial.Polynomial value)
        {
            this[name] = value;
        }

    }
}

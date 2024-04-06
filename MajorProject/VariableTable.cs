using System.Collections.Generic;
using PolyLib;

namespace MajorProject
{
    class VariableTable:Dictionary<string,Complex>
    {
        public VariableTable()
        {
        }
        public bool hasValue(string name)
        {
            return ContainsKey(name);
        }
        public Complex lookUpValue(string name)
        {
            return this[name];
        }
        public void setValue(string name, Complex value)
        {
            this[name] = value;
        }

    }
}

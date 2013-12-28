using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MajorProject
{
    class VariableTable:Dictionary<string,double>
    {
        public VariableTable()
        {
        }
        public bool hasValue(string name)
        {
            return ContainsKey(name);
        }
        public double lookUpValue(string name)
        {
            return this[name];
        }
        public void setValue(string name, double value)
        {
            this[name] = value;
        }

    }
}

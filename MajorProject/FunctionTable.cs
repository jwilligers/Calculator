using System;
using System.Collections.Generic;
using PolyLib;

namespace MajorProject
{

    // string
    class FunctionTable:Dictionary<string,string>
    {
        public FunctionTable()
        {
        }
        public bool exists(string name)
        {
            return ContainsKey(name);
        }
        public string lookUpEquation(string name)
        {
            return this[name];
        }
        public void setValue(string name, string equation)
        {
            this[name] = equation;
        }
        public void addBuiltinFunctions(string typeName)
        {
            this.Add("sin", "sin(val1)");
            this.Add("cos", "cos(val1)");
            this.Add("tan", "tan(val1)");
        }

    }
}
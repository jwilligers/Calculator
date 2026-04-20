using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajorProject
{
    class FunctionDefinition
    {
        public string[] Parameters { get; }
        public Expression Body { get; }

        public FunctionDefinition(string[] parameters, Expression body)
        {
            Parameters = parameters;
            Body = body;
        }
    }

}

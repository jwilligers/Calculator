using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MajorProject
{
    class UnknownVariableException:Exception
    {
        public UnknownVariableException(string message) : base(message)
        {
        }

    }
}

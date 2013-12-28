using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MajorProject
{
    class InputException:Exception
    {
        public InputException(string message)
            : base(message)
        {
        }
    }
}

using System;

namespace MajorProject
{
    class UnknownVariableException:Exception
    {
        public UnknownVariableException(string message) : base(message)
        {
            Console.WriteLine(message);
        }

    }
}

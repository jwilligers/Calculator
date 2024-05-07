using System;

namespace MajorProject
{
    class InputException:Exception
    {
        public InputException(string message)
            : base(message)
        {
            Console.WriteLine(message);
        }
    }
}

using PolyLib;
using System;

namespace MajorProject
{
    static class BaseConverter
    {
        public static string ToBaseString(Complex value, int numberBase)
        {
            if (numberBase < 2 || numberBase > 36)
                throw new Exception("Base must be between 2 and 36");

            if (value.Im != 0)
                throw new Exception("Base conversion only supports real numbers");

            long n = (long)value.Re;
            return Convert.ToString(n, numberBase).ToUpper();
        }
    }
}

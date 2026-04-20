using PolyLib;

namespace MajorProject
{
    class BaseStringComplex : Complex
    {
        private readonly string display;

        public BaseStringComplex(string display)
            : base(0) // value unused
        {
            this.display = display;
        }

        public override string ToString()
        {
            return display;
        }
    }
}

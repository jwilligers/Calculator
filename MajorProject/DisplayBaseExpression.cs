using PolyLib;

namespace MajorProject
{
    class DisplayBaseExpression : Expression
    {
        private readonly Expression inner;
        private readonly int numberBase;

        public DisplayBaseExpression(Expression inner, int numberBase)
        {
            this.inner = inner;
            this.numberBase = numberBase;
        }

        public override Complex Value()
        {
            string converted = BaseConverter.ToBaseString(inner.Value(), numberBase);

            Unit unit = inner.GetUnit();
            if (!unit.IsDimensionless())
                converted += $" [{unit}]";

            return new BaseStringComplex(converted);
        }


        public override Unit GetUnit()
        {
            return inner.GetUnit();
        }

        public override string ToString()
        {
            string converted = BaseConverter.ToBaseString(inner.Value(), numberBase);
            Unit unit = inner.GetUnit();

            if (unit.IsDimensionless())
                return converted;

            return $"{converted} [{unit}]";
        }
    }
}

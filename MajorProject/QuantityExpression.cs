using PolyLib;

namespace MajorProject
{
    class QuantityExpression : Expression
    {
        private readonly Expression inner;
        private readonly Unit unit;

        public QuantityExpression(Expression inner, Unit unit)
        {
            this.inner = inner;
            this.unit = unit;
        }

        public override Complex Value()
        {
            return inner.Value();
        }

        public override Unit GetUnit()
        {
            return unit;
        }

        public override string ToString()
        {
            return $"{inner.ToString()} [{unit}]";
        }
    }
}

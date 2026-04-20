using PolyLib;

namespace MajorProject
{
    public abstract class Expression
    {
        public abstract Complex Value();

        // New: unit metadata for this expression (default: dimensionless)
        public virtual Unit GetUnit()
        {
            return new Unit(UnitType.None);
        }
    }

}

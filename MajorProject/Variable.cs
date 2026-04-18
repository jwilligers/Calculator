using PolyLib;

namespace MajorProject
{
    class Variable : Expression
    {
        VariableTable table;
        string name;
        Unit unit;
        public Variable(VariableTable _table, string _name)
        {
            this.table = _table;
            this.name = _name;
            this.unit = new Unit(UnitType.None);
        }
        public Variable(VariableTable _table, string _name, Unit unit)
        {
            this.table = _table;
            this.name = _name;
            this.unit = unit;
        }

        public bool IsSet()
        {
            return table.hasValue(name);
        }

        public override Complex Value()
        {
            if (table.hasValue(name))
            {
                return table.lookUpValue(name);
            }
            else
            {
                throw new UnknownVariableException("No known value for " + name);
            }
        }

        override public string ToString()
        {
            return name;
        }
    }
}

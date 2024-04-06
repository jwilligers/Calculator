using PolyLib;

namespace MajorProject
{
    class Variable : Expression
    {
        VariableTable table;
        string name;
       
        public Variable(VariableTable _table, string _name)
        {
            table = _table;
            name = _name;
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

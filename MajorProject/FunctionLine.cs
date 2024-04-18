using System;

namespace MajorProject
{
    class FunctionLine : Line
    {
        String functionName;
        String argument;
        String functionExpression;
        FunctionTable table;


        public FunctionLine(FunctionTable _table, String _functionName, String _argument, String _functionExpression)
        {
            this.table = _table;
            this.functionName = _functionName;
            this.argument = _argument;
            this.functionExpression = _functionExpression;
            table.setValue(functionName, functionExpression);
        }
        override public string ToString()
        {
            return functionName + " takes argument " + argument + "and has expression " + functionExpression;
        }
    }

}

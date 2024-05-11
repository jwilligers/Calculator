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
            this.table.setValue(functionName+"(x)", createTree());
        }
        override public string ToString()
        {
            return functionName + " takes argument " + argument + " and has expression " + functionExpression;
        }
        public Expression createTree()
        {
            Scanner scanner = new Scanner(functionExpression + "\n\n", table);
            Parser parser = new Parser(scanner, table, true, "x");
            Worksheet worksheet = parser.ReadWorksheet();

            String[] solutions = new String[worksheet.NumLines()];

            bool progress;
            do
            {
                progress = false;
                for (int index = 0; index < worksheet.NumLines(); index++)
                {
                    Line currentLine = worksheet.GetLine(index);
                    if (currentLine is EquationLine)
                    {
                        EquationLine equation = (EquationLine)currentLine;
                        try
                        {
                            String solution = equation.Solve();
                            solutions[index] = solution;
                            progress = true;
                        }
                        catch (SolvedException)
                        {
                        }
                        catch (UnknownVariableException)
                        {
                        }
                    }
                }
            } while (progress);
            return null;
        }
    }
}
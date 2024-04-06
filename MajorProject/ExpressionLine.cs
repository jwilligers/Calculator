﻿namespace MajorProject
{
    class ExpressionLine : Line
    {
        Expression expression;

        public ExpressionLine(Expression _expression)
        {
            expression = _expression;
        }
        public Expression Result()
        {
            return expression;
        }
        override public string ToString()
        {
            return expression.ToString() + "\r\n";
        }
    }

}

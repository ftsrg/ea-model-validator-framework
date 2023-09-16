using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OCLtoSQL
{
    /// <summary>
    /// Sequence of expressions separated by logical operators
    /// </summary>
    public class LogicalExpression : BinaryExpression
    {
        public LogicalExpression(Expression expression) : base (expression)
        {
        }
    }
}

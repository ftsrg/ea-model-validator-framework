using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OCLtoSQL
{
    /// <summary>
    /// Represents a sequence of expressions that have relational operators between them.
    /// </summary>
    public class RelationalExpression : BinaryExpression
    {
        public RelationalExpression(Expression expression) : base(expression)
        {
        }
    }
}

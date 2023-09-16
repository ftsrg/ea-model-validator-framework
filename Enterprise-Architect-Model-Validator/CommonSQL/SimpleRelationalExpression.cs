using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OCLtoSQL
{
    /// <summary>
    /// Represents a sequence of simple expressions (not collections) that have relational operators between them. 
    /// </summary>
    public class SimpleRelationalExpression : BinaryExpression
    {
        public SimpleRelationalExpression(Expression expression) : base(expression)
        {
        }
    }
}

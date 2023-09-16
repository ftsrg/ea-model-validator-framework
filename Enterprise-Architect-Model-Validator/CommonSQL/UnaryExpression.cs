using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OCLtoSQL
{
    /// <summary>
    /// Expression with an unary operator before it.
    /// </summary>
    public class UnaryExpression : Expression
    {
        public UnaryExpression(string operation, Expression expression)
        {
            this.operation = operation;
            this.expression = expression;
        }

        /// <summary>
        /// Unary operator.
        /// </summary>
        public string operation { get; private set; }

        /// <summary>
        /// Expression before which is the unary operator.
        /// </summary>
        public Expression expression { get; private set; }
    }
}

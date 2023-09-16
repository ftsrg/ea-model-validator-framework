using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OCLtoSQL
{
    /// <summary>
    /// Represents a number in expressions.
    /// </summary>
    public class NumberExpression : Expression
    {
        public NumberExpression(string number)
        {
            this.number = number;
        }

        /// <summary>
        /// Represented number.
        /// </summary>
        public string number { get; private set; }
    }
}

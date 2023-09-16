using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OCLtoSQL
{
    /// <summary>
    /// Represents a string in the expressions.
    /// </summary>
    public class StringExpression : Expression
    {
        public StringExpression(string value)
        {
            this.value = value;
        }

        public string value { get; private set; }
    }
}

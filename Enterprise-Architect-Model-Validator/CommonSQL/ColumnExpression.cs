using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OCLtoSQL
{
    /// <summary>
    /// Represents a table column
    /// </summary>
    public class ColumnExpression : Expression
    {
        /// <summary>
        /// Creates new ColumnExpression.
        /// </summary>
        /// <param name="value">Name of the new column.</param>
        public ColumnExpression(string value)
        {
            this.columnName = value;
        }

        /// <summary>
        /// Name of the column.
        /// </summary>
        public string columnName { get; private set; }
    }
}
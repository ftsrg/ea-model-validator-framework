using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OCLtoSQL
{
    /// <summary>
    /// Binds the inner queries to an outer one. Used for advanced functions like forAll.
    /// </summary>
    public class TableBinding
    {
        public TableBinding(string name, string tableName, string alias)
        {
            this.name = name;
            this.tableName = tableName;
            this.alias = alias;
        }

        /// <summary>
        /// Name of the binding used in the declaration parts of advanced functions
        /// </summary>
        public string name { get; private set; }

        /// <summary>
        /// Name of the table to be bound to.
        /// </summary>
        public string tableName { get; private set; }

        /// <summary>
        /// Alias to be used for the binding in hte WHERE clauses of the inner queries.
        /// </summary>
        public string alias { get; private set; }
    }
}

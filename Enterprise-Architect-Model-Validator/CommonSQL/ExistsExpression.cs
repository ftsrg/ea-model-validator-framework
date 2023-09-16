using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OCLtoSQL
{
    /// <summary>
    /// Represents the Exists OCL structure - it tests an expression over the given collection of data.
    /// </summary>
    public class ExistsExpression : BindingExpression
    {
        public ExistsExpression(Select onSelect, List<TableBinding> tableBindings, LogicalExpression logicalExpression)
            : base(onSelect, tableBindings, logicalExpression)
        {
        }
    }
}

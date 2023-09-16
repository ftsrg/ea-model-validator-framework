using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OCLtoSQL
{
    /// <summary>
    /// Represents the ForAll OCL structure - it tests an expression over the given collection of data.
    /// </summary>
    public class ForAllExpression : BindingExpression
    {
        public ForAllExpression(Select onSelect, List<TableBinding> tableBindings, LogicalExpression logicalExpression)
            : base(onSelect, tableBindings, logicalExpression)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OCLtoSQL
{
    /// <summary>
    /// Represents the ForAll/Exists OCL structure - it tests an expression over the given collection of data.
    /// </summary>
    public class BindingExpression : Expression
    {
        /// <summary>
        /// Creates new BindingExpression.
        /// </summary>
        /// <param name="onSelect">Select representing data the forall/exists goes over.</param>
        /// <param name="logicalExpression">The tested expression.</param>
        /// <param name="tableBindings">Bindings that were specified in the exists.</param>
        public BindingExpression(Select onSelect, List<TableBinding> tableBindings, LogicalExpression logicalExpression)
        {
            this.onSelect = onSelect;
            this.logicalExpression = logicalExpression;
            this.tableBindings = tableBindings;
        }

        /// <summary>
        /// Select representing data the forall/exists goes over.
        /// </summary>
        public Select onSelect { get; private set; }

        /// <summary>
        /// Bindings that were specified in the forall/exists.
        /// </summary>
        public List<TableBinding> tableBindings { get; private set; }

        /// <summary>
        /// The tested expression.
        /// </summary>
        public LogicalExpression logicalExpression { get; private set; }
    }
}
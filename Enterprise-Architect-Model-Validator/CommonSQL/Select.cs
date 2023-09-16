using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OCLtoSQL
{
    /// <summary>
    /// Represents a SQL select.
    /// </summary>
    public class Select : Expression
    {
        /// <summary>
        /// Creates a new select.
        /// </summary>
        /// <param name="firstTable">The first table the select gets data from.</param>
        /// <param name="tableBinding">Possible binding to a table (in an advanced OCL structure). Null if none.</param>
        public Select(string firstTable, TableBinding tableBinding)
        {
            init();
            this.firstTable = firstTable;
            this.tableBinding = tableBinding;
        }

        /// <summary>
        /// Creates a new select.
        /// </summary>
        /// <param name="expression">Expression that is added into the header of the new select.</param>
        public Select(Expression expression)
        {
            init();
            selectList.Add(expression);
        }

        private void init()
        {
            this.from = new List<NavigationItem>();
            this.selectList = new List<Expression>();
            this.selectOperationList = new List<string>();
            this.tableBinding = null;
        }

        /// <summary>
        /// Merges to selects into one if possible,
        /// if not, creates a new select containing both as subexpressions.
        /// </summary>
        /// <param name="op">Operation between the selects.</param>
        /// <param name="select">Select this select is trying to be joined to.</param>
        /// <returns></returns>
        public Select add(string op, Select select)
        {
            if (isSelectMergable(select))
            {
                this.selectList.AddRange(select.selectList);
                this.selectOperationList.Add(op);
                this.selectOperationList.AddRange(select.selectOperationList);

                if (this.firstTable == null)
                {
                    this.firstTable = select.firstTable;
                    this.from.AddRange(select.from);
                }

                return this;
            }
            else
            {
                //SELECT (select1) op (select2)
                Select newSelect = new Select(this);
                newSelect.selectOperationList.Add(op);
                newSelect.selectList.Add(select);

                return newSelect;
            }
        }

        /// <summary>
        /// Decides if merging of selects is possible.
        /// </summary>
        /// <param name="select">Select that is being considered for joining this one.</param>
        /// <returns>True if this select and the given one ore joinable,
        /// false otherwise.</returns>
        public bool isSelectMergable(Select select)
        {
            if ((this.firstTable == null)
                || (select.firstTable == null))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Name of the first table in the select FROM clause.
        /// </summary>
        public string firstTable;

        /// <summary>
        /// Rows of the select FROM clause that represent each INNER JOIN with other tables.
        /// </summary>
        public List<NavigationItem> from;

        /// <summary>
        /// Possible binding to a table (in an advanced OCL structure). Null if none.
        /// </summary>
        public TableBinding tableBinding;

        /// <summary>
        /// Sequence of operations in the select SELECT clause
        /// </summary>
        public List<Expression> selectList;

        /// <summary>
        /// Operations between the selectList.
        /// </summary>
        public List<string> selectOperationList;
    }
}

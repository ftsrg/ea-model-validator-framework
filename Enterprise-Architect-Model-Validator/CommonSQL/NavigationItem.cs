using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OCLtoSQL
{
    /// <summary>
    /// Contains information needed for joining a new table in a select.
    /// </summary>
    public class NavigationItem
    {
        /// <summary>
        /// Creates new Navigation item.
        /// 
        /// ... sourceTable sT ...
        /// INNER JOIN targetTable tT ON sT.onSource = tT.onTarget  
        /// </summary>
        /// <param name="targetTable">Table being joined.</param>
        /// <param name="onSource">Column of the table that is the new table being joined to.</param>
        /// <param name="onTarget">Column in the table beaing joined.</param>
        public NavigationItem(string targetTable, string onSource, string onTarget)
        {
            this.targetTable = targetTable;
            this.onSource = onSource;
            this.onTarget = onTarget;
        }

        /// <summary>
        /// Table being joined.
        /// </summary>
        public string targetTable { get; private set; }

        /// <summary>
        /// Column of the table that is the new table being joined to.
        /// </summary>
        public string onSource { get; private set; }

        /// <summary>
        /// Column in the table beaing joined.
        /// </summary>
        public string onTarget { get; private set; }
    }
}

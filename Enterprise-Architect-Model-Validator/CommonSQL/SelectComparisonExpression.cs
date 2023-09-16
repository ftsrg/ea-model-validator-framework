using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OCLtoSQL
{
    /// <summary>
    /// Serves as the basic type for comparing two sets defined by selects.
    /// </summary>
    public class SelectComparisonExpression: Expression
    {
        public SelectComparisonExpression(Select selectX, Select selectY)
        {
            this.selectX = selectX;
            this.selectY = selectY;
        }

        /// <summary>
        /// Set on which the comparison call was made
        /// </summary>
        public Select selectX { get; private set; }

        /// <summary>
        /// Set that is compared to the one the comparison was called on.
        /// </summary>
        public Select selectY { get; private set; }
    }
}

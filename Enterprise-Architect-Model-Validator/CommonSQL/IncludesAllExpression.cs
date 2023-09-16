using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OCLtoSQL
{
    /// <summary>
    /// Represents the OCL includesAll function
    /// </summary>
    public class IncludesAllExpression : SelectComparisonExpression
    {
        public IncludesAllExpression(Select selectX, Select selectY) : base(selectX, selectY)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OCLtoSQL
{
    /// <summary>
    /// Represents the OCL includes function
    /// </summary>
    public class IncludesExpression : SelectComparisonExpression
    {
        public IncludesExpression(Select selectX, Select selectY) : base(selectX, selectY)
        {
        }
    }
}

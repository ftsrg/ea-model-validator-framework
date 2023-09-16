using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OCLtoSQL
{
    /// <summary>
    /// Represents the call of an aggregate function
    /// </summary>
    public class AggregateFunctionExpression : Expression
    {
        public AggregateFunctionExpression(string functionName, List<Expression> selectList, List<string> selectOperationList)
        {
            this.functionName = functionName;
            this.selectList = selectList;
            this.selectOperationList = selectOperationList;
        }

        /// <summary>
        /// Name of the called aggregate function
        /// </summary>
        public string functionName;

        /// <summary>
        /// List of expressions that are inside of the aggregate function.
        /// </summary>
        public List<Expression> selectList;

        /// <summary>
        /// List of binary operations between the ones in the selectList
        /// </summary>
        public List<string> selectOperationList;
    }
}

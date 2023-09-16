using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OCLtoSQL
{
    /// <summary>
    /// Sequence of expression with binary expressions between them.
    /// </summary>
    public class BinaryExpression : Expression
    {
        /// <summary>
        /// Creates a new BinaryExpression with the given expression as the start of the sequence.
        /// </summary>
        /// <param name="expression"></param>
        public BinaryExpression(Expression expression)
        {
            operations = new List<string>();
            expressions = new List<Expression>() {expression};
        }

        /// <summary>
        /// Adds a new expression to the sequence along with the operation before it.
        /// </summary>
        /// <param name="operation">Name of the operation that concatenates the new expression to the existing sequence.</param>
        /// <param name="expression">Name of the expression that is concatenated to the existing sequence.</param>
        public void Add(string operation, Expression expression)
        {
            operations.Add(operation);
            expressions.Add(expression);
        }

        /// <summary>
        /// List of expressions that are inside of the aggregate function.
        /// </summary>
        public List<Expression> expressions;

        /// <summary>
        /// List of binary operations between the ones in the selectList
        /// </summary>
        public List<string> operations;
    }
}

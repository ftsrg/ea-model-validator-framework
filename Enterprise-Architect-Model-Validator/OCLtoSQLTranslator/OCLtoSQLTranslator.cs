using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

using Antlr.Runtime;
using Antlr.Runtime.Tree;
//using OCLtoSQLTranslator;

namespace OCLtoSQL
{
    /// <summary>
    /// Enables to parse OCL into basic SQL structures.
    /// </summary>
    public class OCLtoSQLTranslator
    {
        /// <summary>
        /// Parses given OCL and transformes it into basic SQL structures.
        /// </summary>
        /// <param name="ddlPackage">Where to get data about the structure of database.</param>
        /// <param name="context">Context of the given OCL constraint.</param>
        /// <param name="OCLCostraint">OCL constraint itself.</param>
        /// <returns>Basic SQL structure corresponding to the given OCL input.</returns>
        public static OCLtoSQL.Expression translate(DDLPackage ddlPackage, string context, string OCLCostraint)
        {
            OCLConstraintLexer lex = new OCLConstraintLexer(new ANTLRStringStream(OCLCostraint));
            CommonTokenStream tokens = new CommonTokenStream(lex);
            OCLConstraintParser parser = new OCLConstraintParser(tokens);

            Expression expression;
            try
            {
                expression = parser.constraint(ddlPackage, context);
            }
            catch (RecognitionException e)
            {
                //e.StackTrace
                return null;
            }

            return expression;
        }
    }
}

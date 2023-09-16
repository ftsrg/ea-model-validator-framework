using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace OCLtoSQL
{
    /// <summary>
    /// Provides T-SQL code generation from the translated OCL constraints.
    /// </summary>
    public class TSQLGenerator
    {
        /// <summary>
        /// Generates T-SQL code out of the given basic SQL structures.
        /// </summary>
        /// <param name="expression">Basic SQL structures translated from an OCL constraint.</param>
        /// <param name="context">Context of the given translated constraint. Used for Self op[erator binding.</param>
        /// <param name="constraintName">Name of the given translated constraint. Used for naming of the structures created by the result T-SQL code.</param>
        /// <returns></returns>
        public static string generate(Expression expression, string context, string constraintName, GenerationSettings settings)
        {
            TSQLGenerator generator = new TSQLGenerator();
            generator.context = context;

            string generatedCode = "";
            string booleanQuery = "";

            booleanQuery = generator.generateCodeFor(expression);

            if ((constraintName == null) || (constraintName == ""))
            {
                constraintName = "function" + Guid.NewGuid().ToString();
            }

            generatedCode += generator.createBitFunction(constraintName, booleanQuery, settings.createAndReplaceFunctions, settings.databaseSchema);

            return generatedCode;
        }

        private string context;
        private bool usedSelf = false;
        private bool isOuterExpression = true;

        private string generateCodeFor(Expression expression)
        {
            string generatedCode = "";

            string typeName = expression.GetType().Name;
            switch (typeName)
            {
                case "LogicalExpression":
                    generatedCode = generateCodeFor((LogicalExpression)expression);
                    break;

                case "RelationalExpression":
                    generatedCode = generateCodeFor((RelationalExpression)expression);
                    break;

                case "SimpleRelationalExpression":
                    generatedCode = generateCodeFor((SimpleRelationalExpression)expression);
                    break;

                case "Select":
                    generatedCode = generateCodeFor((Select)expression);
                    break;

                case "UnaryExpression":
                    generatedCode = generateCodeFor((UnaryExpression)expression);
                    break;

                case "StringExpression":
                    generatedCode = generateCodeFor((StringExpression)expression);
                    break;

                case "ColumnExpression":
                    generatedCode = generateCodeFor((ColumnExpression)expression);
                    break;

                case "NumberExpression":
                    generatedCode = generateCodeFor((NumberExpression)expression);
                    break;

                case "IncludesAllExpression":
                    generatedCode = generateCodeFor((IncludesAllExpression)expression);
                    break;

                case "IncludesExpression":
                    generatedCode = generateCodeFor((IncludesExpression)expression);
                    break;

                case "ForAllExpression":
                    generatedCode = generateCodeFor((ForAllExpression)expression);
                    break;

                case "ExistsExpression":
                    generatedCode = generateCodeFor((ExistsExpression)expression);
                    break;

                default:
                    throw new Exception();
            }

            return generatedCode;
        }

        private string generateCodeFor(LogicalExpression logicalExpression)
        {
            string generatedCode = "";

            bool isOuterExpression = this.isOuterExpression;
            this.isOuterExpression = false;

            generatedCode += generateCodeFor(logicalExpression.expressions[0]);

            int i = 1;
            foreach (string operation in logicalExpression.operations)
            {
                if (operation.ToUpper() == "IMPLIES")
                {
                    //x => y === ~(x ^ ~y)
                    generatedCode = String.Format(
                        "NOT ({0} AND NOT ({1}))",
                        generatedCode,
                        generateCodeFor(logicalExpression.expressions[i])
                        );
                }
                else
                {
                    generatedCode += "\n" + operation.ToUpper() + " ";
                    generatedCode += generateCodeFor(logicalExpression.expressions[i]);
                }
                ++i;
            }

            if (usedSelf && isOuterExpression)
            {
                generatedCode = String.Format(
                    "NOT EXISTS (SELECT {0}ID \nFROM {0} AS SELFT \nWHERE NOT ({1}))",
                    context,
                    generatedCode
                    );
            }
            else
            {
                generatedCode = String.Format("{0}", generatedCode);
            }

            return generatedCode;
        }

        private string generateCodeFor(RelationalExpression relationalExpression)
        {
            string generatedCode;

            Select select1 = (Select)(relationalExpression.expressions[0]);
            Select select2 = (Select)(relationalExpression.expressions[1]);

            if (((select1.firstTable != null)
                || (select2.firstTable != null)
                )
                && select1.isSelectMergable(select2)
                )
            {   //selects mergeable and one has Navigation
                string selectHeader1 = generateSelectHeaderString(select1);
                string selectHeader2 = generateSelectHeaderString(select2);

                string navigation;
                string binding = "";
                if (select1.firstTable != null)
                {
                    navigation = generateNavigationString(select1.firstTable, select1.from);
                    if (select1.tableBinding != null)
                    {
                        binding = generateBindingForSelf(select1.tableBinding) + " AND ";
                        usedSelf = isSelectBindingCausedBySelfOperator(select1);
                    }
                }
                else
                {
                    navigation = generateNavigationString(select2.firstTable, select2.from);
                    if (select2.tableBinding != null)
                    {
                        binding = generateBindingForSelf(select2.tableBinding) + " AND ";
                        usedSelf = isSelectBindingCausedBySelfOperator(select2);
                    }
                }

                generatedCode = String.Format(
                    "NOT EXISTS (SELECT 1\n{0}\nWHERE {4} NOT ({1} {2} {3}))",
                    navigation,
                    selectHeader1,
                    relationalExpression.operations[0],
                    selectHeader2,
                    binding
                    );
            }
            else
            {
                string expr1 = generateCodeFor(select1);
                string expr2 = generateCodeFor(select2);
                string op = relationalExpression.operations[0];

                generatedCode = String.Format("{0} {1} {2}", expr1, op, expr2);
            }

            return generatedCode;
        }

        private string generateCodeFor(SimpleRelationalExpression simpleRelationalExpression)
        {
            string generatedCode;

            string expr1 = generateCodeFor(simpleRelationalExpression.expressions[0]);
            string expr2 = generateCodeFor(simpleRelationalExpression.expressions[1]);
            string op = simpleRelationalExpression.operations[0];

            generatedCode = String.Format("{0} {1} {2}", expr1, op, expr2);

            return generatedCode;
        }

        private string generateCodeFor(Select select)
        {
            //select header
            string selectHeader = generateSelectHeaderString(select);

            //navigtation
            string navigation = "";
            if (select.firstTable != null)
            {
                navigation = "\n" + generateNavigationString(select.firstTable, select.from);
            }

            //self binding
            string binding = "";
            if (select.tableBinding != null)
            {
                binding = "\nWHERE " + generateBindingForSelf(select.tableBinding);
                usedSelf = isSelectBindingCausedBySelfOperator(select);
            }

            string generatedCode = String.Format("(SELECT {0}{1}{2})", selectHeader, navigation, binding);

            return generatedCode;
        }

        private string generateCodeFor(AggregateFunctionExpression aggregateFunctionExpression)
        {
            string header = generateSelectHeaderString(aggregateFunctionExpression.selectList, aggregateFunctionExpression.selectOperationList);

            string generatedCode = String.Format("{0}({1})", aggregateFunctionExpression.functionName.ToUpper(), header);

            return generatedCode;
        }

        private string generateCodeFor(UnaryExpression unaryExpression)
        {
            string generatedCode = String.Format("{0} ({1})", unaryExpression.operation.ToUpper(), generateCodeFor(unaryExpression.expression));

            return generatedCode;
        }

        private string generateCodeFor(StringExpression stringExpression)
        {
            string generatedCode = String.Format("N{0}", stringExpression.value);

            return generatedCode;
        }

        private string generateCodeFor(ColumnExpression columnExpression)
        {
            string generatedCode = String.Format("{0}", columnExpression.columnName);

            return generatedCode;
        }

        private string generateCodeFor(NumberExpression numberExpression)
        {
            string generatedCode = String.Format("{0}", numberExpression.number);

            return generatedCode;
        }

        private string generateCodeFor(IncludesExpression includesExpression)
        {
            string generatedCode;

            string generatedX = generateCodeFor(includesExpression.selectX);
            string generatedY = generateCodeFor(includesExpression.selectY);

            generatedCode = String.Format("EXISTS(({0})\nINTERSECT\n({1}))", generatedX, generatedY);

            return generatedCode;
        }

        private string generateCodeFor(IncludesAllExpression includesAllExpression)
        {
            string generatedCode;

            string generatedX = generateCodeFor(includesAllExpression.selectX);
            string generatedY = generateCodeFor(includesAllExpression.selectY);

            generatedCode = String.Format("NOT EXISTS(({0})\nEXCEPT\n({1}))", generatedX, generatedY);

            return generatedCode;
        }

        private string generateCodeFor(ForAllExpression forAllExpression)
        {
            return generateCodeFor(forAllExpression, true);
        }

        private string generateCodeFor(ExistsExpression existsExpression)
        {
            return generateCodeFor(existsExpression, false);
        }

        private string generateCodeFor(BindingExpression bindingExpression, bool isForAll)
        {
            string generatedCode;

            Select select = bindingExpression.onSelect;

            //select header
            string selectHeader = generateSelectHeaderString(select);

            //alias of the table that is to be bound with the possible outer binding
            string bindingForAlias;

            string navigation = "";
            if (bindingExpression.onSelect.from.Count > 0)
            {
                NavigationItem navigationItem = select.from[select.from.Count - 1];
                select.from.RemoveAt(select.from.Count - 1);
                bindingForAlias = "T1";

                navigation += "\n" + generateNavigationString(select.firstTable, select.from);

                //the table the others are joining on
                string sourceTableAlias = "T" + (select.from.Count + 1).ToString();

                foreach (TableBinding tableBinding in bindingExpression.tableBindings)
                {
                    string targetTableAlias = tableBinding.alias;
                    navigation += generateNavigationItem(navigationItem, sourceTableAlias, targetTableAlias);
                }
            }
            else
            {
                bindingForAlias = bindingExpression.tableBindings[0].alias;

                navigation = String.Format("\nFROM {0} {1}", select.firstTable, bindingExpression.tableBindings[0].alias);
                for (int i = 1; i < bindingExpression.tableBindings.Count; ++i)
                {
                    navigation += String.Format("\nCROSS JOIN {0} {1}", bindingExpression.tableBindings[i].tableName, bindingExpression.tableBindings[i].alias);
                }
            }

            //also test possible binding from an outer structure!!! (-> add to WHERE)
            string binding = "";
            if (select.tableBinding != null)
            {
                binding = " AND " + generateBinding(select.tableBinding, bindingForAlias);
                usedSelf = isSelectBindingCausedBySelfOperator(select);
            }

            string generatedCalledOn = String.Format("SELECT {0}{1}", selectHeader, navigation);
            string generatedTest = generateCodeFor(bindingExpression.logicalExpression);

            if (isForAll)
            {
                generatedCode = String.Format("NOT EXISTS({0}\nWHERE NOT ({1}){2})", generatedCalledOn, generatedTest, binding);
            }
            else
            {
                generatedCode = String.Format("EXISTS({0}\nWHERE {1}{2})", generatedCalledOn, generatedTest, binding);
            }

            return generatedCode;
        }

        private bool isSelectBindingCausedBySelfOperator(Select select)
        {
            return (select.tableBinding.name == "self");
        }

        private string generateSelectHeaderString(Select select)
        {
            if (select.selectList.Count == 0)
            {
                string tableName;
                if (select.from.Count == 0)
                {
                    tableName = select.firstTable;
                }
                else
                {
                    tableName = select.from.Last().targetTable;
                }
                string columnName = getPKColumnFromTable(tableName);

                select.selectList.Add(new ColumnExpression(columnName));
            }

            return generateSelectHeaderString(select.selectList, select.selectOperationList);
        }

        private string generateSelectHeaderString(List<Expression> selectList, List<string> selectOperationList)
        {
            string selectHeader = generateCodeFor(selectList[0]);
            int i = 1;
            foreach (string operation in selectOperationList)
            {
                selectHeader += " " + operation + " " + generateCodeFor(selectList[i]);
                ++i;
            }

            return selectHeader;
        }

        private string generateNavigationString(string firstTable, List<NavigationItem> navigationItems)
        {
            string navigation;

            string commonTableAlias = "T";
            int tableCount = 1;
            navigation = String.Format("FROM {0} {1}", firstTable, commonTableAlias + tableCount.ToString());
            foreach (NavigationItem navigationItem in navigationItems)
            {
                string sourceTableAlias = commonTableAlias + tableCount.ToString();
                ++tableCount;
                string targetTableAlias = commonTableAlias + tableCount.ToString();

                navigation += generateNavigationItem(navigationItem, sourceTableAlias, targetTableAlias);
            }

            return navigation;
        }

        private string generateNavigationItem(NavigationItem navigationItem, string sourceTableAlias, string targetTableAlias)
        {
            return String.Format("\nINNER JOIN {0} {1} ON {2}.{3} = {1}.{4}",
                        navigationItem.targetTable,
                        targetTableAlias,
                        sourceTableAlias,
                        navigationItem.onSource,
                        navigationItem.onTarget
                    );
        }

        private string generateBindingForSelf(TableBinding tableBinding)
        {
            return generateBinding(tableBinding, "T1");
        }

        private string generateBinding(TableBinding tableBinding, string forAlias)
        {
            string columnName = getPKColumnFromTable(tableBinding.tableName);
            string binding = String.Format("({2}.{0}ID = {1}.{0}ID)", tableBinding.tableName, tableBinding.alias, forAlias);

            return binding;
        }

        private string getPKColumnFromTable(string tableName)
        {
            string columnName = tableName + "ID";

            //first letter of the column is lower case
            columnName = columnName[0].ToString().ToLower()[0] + columnName.Substring(1);

            return columnName;
        }

        private string createBitFunction(string functionName, string booleanQuerry, bool reCreate, string schema)
        {
            string result = "";

            string schemaPrestring;
            if (schema == "")
            {
                schemaPrestring = "";
            }
            else
            {
                schemaPrestring = String.Format("[{0}].", schema, functionName);
            }

            string fullFunctionName = String.Format("{0}[{1}IsViolated]", schemaPrestring, functionName);

            if (reCreate)
            {
                result += String.Format(
                    "IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'{0}') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))\nDROP FUNCTION {0}\n\nGO\n\n",
                    fullFunctionName
                    );
            }
            result += String.Format(
                "CREATE FUNCTION {0}()\nRETURNS bit\nAS\nBEGIN\n\tDECLARE @result bit = (CASE WHEN\n\t\t\t{1}\n\t\tTHEN 0\n\t\tELSE 1 END)\n\n\tRETURN @result\nEND\n\nGO\n",
                fullFunctionName,
                booleanQuerry
                );

            return result;
        }
    }
}

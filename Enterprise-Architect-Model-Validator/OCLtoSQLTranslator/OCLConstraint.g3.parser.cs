using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OCLtoSQL
{
    partial class OCLConstraintParser
    {
        private Expression simpleFunctionCall(Select onExpression, string functionName, List<Expression> parameters)
        {
            switch (functionName.ToUpper())
            {
                case "SIZE":
                    return callCount(onExpression);

                case "SUM":
                case "MAX":
                case "MIN":
                case "AVERAGE":
                    return callAggregateFunction(onExpression, functionName);

                case "NOTEMPTY":
                    return callNotEmpty(onExpression);

                case "ISEMPTY":
                    return callIsEmpty(onExpression);

                case "INCLUDES":
                    return callIncludes(onExpression, parameters);

                case "INCLUDESALL":
                    return callIncludesAll(onExpression, parameters);

                default:
                    throw new Exception();
            }
        }

        private Expression callCount(Select onExpression)
        {
            onExpression.selectList.Clear();
            onExpression.selectOperationList.Clear();

            onExpression.selectList.Add(new ColumnExpression("COUNT(*)"));

            return onExpression;
        }

        private Expression callNotEmpty(Select onExpression)
        {
            Expression expressionWithCount = callCount(onExpression);

            SimpleRelationalExpression simpleRelationalExpression = new SimpleRelationalExpression(expressionWithCount);
            simpleRelationalExpression.operations.Add(">");
            simpleRelationalExpression.expressions.Add(new NumberExpression("0"));

            return simpleRelationalExpression;
        }

        private Expression callIsEmpty(Select onExpression)
        {
            Expression expressionWithCount = callCount(onExpression);

            SimpleRelationalExpression simpleRelationalExpression = new SimpleRelationalExpression(expressionWithCount);
            simpleRelationalExpression.operations.Add("=");
            simpleRelationalExpression.expressions.Add(new NumberExpression("0"));

            return simpleRelationalExpression;
        }

        private Expression callAggregateFunction(Select onExpression, string functionName)
        {
            AggregateFunctionExpression aggregateFunctionExpression = new AggregateFunctionExpression(functionName, onExpression.selectList, onExpression.selectOperationList);

            onExpression.selectList.Clear();
            onExpression.selectOperationList.Clear();

            onExpression.selectList.Add(aggregateFunctionExpression);

            return onExpression;
        }

        private Expression callIncludes(Select onExpression, List<Expression> parameters)
        {
            Select selectX = fillEmptySelect(onExpression);
            Select selectY = fillEmptySelect((Select)((LogicalExpression)parameters[0]).expressions[0]);

            return new IncludesExpression(selectX, selectY);
        }

        private Expression callIncludesAll(Select onExpression, List<Expression> parameters)
        {
            Select selectX = fillEmptySelect(onExpression);
            Select selectY = fillEmptySelect((Select)((LogicalExpression)parameters[0]).expressions[0]);

            return new IncludesAllExpression(selectX, selectY);
        }

        private Select fillEmptySelect(Select select)
        {
            if (select.selectList.Count == 0)
            {
                string ID = select.firstTable + "ID";

                //first letter of the column is lower case
                ID = ID[0].ToString().ToLower()[0] + ID.Substring(1);
                select.selectList.Add(new ColumnExpression(ID));
            }

            return select;
        }

        private TableBinding registerBinding(string name, string tableName)
        {
            string alias = String.Format("BIND{0}{1}", name, tableBindings.Count.ToString());

            TableBinding tableBinding = new TableBinding(name, tableName, alias);
			tableBindings.Add(tableBinding);

            return tableBinding;
        }

        private void unregisterBindings(List<TableBinding> tableBindings)
        {
            foreach (TableBinding tableBinding in tableBindings)
            {
                this.tableBindings.Remove(tableBinding);
            }
        }

        private TableBinding tryToGetBinding(string name)
        {
            for (int i = tableBindings.Count - 1; i >= 0; --i)
            {
                if (tableBindings[i].name == name)
                {
                    return tableBindings[i];
                }
            }

            return null;
        }

        private Expression advancedFunctionCall(Select onExpression, string functionName, List<TableBinding> tableBindings, List<Expression> parameters)
        {
            switch (functionName.ToUpper())
            {
                case "FORALL":
                    return new ForAllExpression(onExpression, tableBindings, (LogicalExpression)(parameters[0]));

                case "EXISTS":
                    return new ExistsExpression(onExpression, tableBindings, (LogicalExpression)(parameters[0]));

                default:
                    throw new Exception();
            }
        }

        string defaultContext = null;
	    DDLPackage ddlPackage;
	    List<TableBinding> tableBindings = new List<TableBinding>();
    }

}

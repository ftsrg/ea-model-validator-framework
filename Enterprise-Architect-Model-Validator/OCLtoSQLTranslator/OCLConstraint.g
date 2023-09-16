grammar OCLConstraint;

options {
    language=CSharp3;
    TokenLabelType=CommonToken;
}


@members
{ 
	//End after first mistake (no recovery)
	protected override object RecoverFromMismatchedToken(IIntStream input, int ttype, BitSet follow) 
	{ 
			throw new MismatchedTokenException(ttype, input); 
	}
	public override object RecoverFromMismatchedSet(IIntStream input, 
	RecognitionException e, BitSet follow) 
	{ 
			throw e; 
	}
} 

@rulecatch
{ 
	catch (RecognitionException e) 
	{ 
		throw e; 
	}
} 

@lexer::namespace{OCLtoSQL}
@parser::namespace{OCLtoSQL}

public
constraint[DDLPackage ddlPackage, string context] returns [Expression expression]
	@init
	{
		this.ddlPackage = ddlPackage;
		defaultContext = context;
		tableBindings.Add(new TableBinding("self", context, "SELFT"));
	}
  : 'inv' COLON lo=logicalExpression EOF	{$expression = lo;}
  ;

logicalExpression returns [Expression expression]
  : e1=relationalExpression
		{
			$expression = new LogicalExpression(e1);
		}
    ( op=logicalOperator e2=relationalExpression
		{
			((LogicalExpression)$expression).Add(op, e2);
		}
	)*
  ;

relationalExpression returns [Expression expression]
  : e1=arithmeticExpression
		{
			$expression = e1;
		}
    ( op=relationalOperator e2=arithmeticExpression
		{
			$expression = new RelationalExpression(e1);
			((RelationalExpression)$expression).Add(op, e2);
		}
	)?
  ;

arithmeticExpression returns [Expression expression]
  : e1=unaryExpression
		{
			$expression = e1;
		}
    ( op=arithmeticOperator e2=unaryExpression
		{
			 $expression = ((Select)$expression).add(op, (Select)e2);
		}
	)*
  ;

unaryExpression returns [Expression expression]
  : ( op=unaryOperator e1=postfixExpression )
		{
			$expression = ((Select)e1).selectList[0] = new UnaryExpression(op, ((Select)e1).selectList[0]);
		}
  | e1=postfixExpression
		{
			$expression = e1;
		}
  ;

postfixExpression returns [Expression expression] @init{string context = null;}
  : (STRING | NUMBER) => l=literal
		{
			$expression = l;
		}
  | n=NAME
		{
			TableBinding tableBinding = tryToGetBinding(n.Text);
			if (tableBinding == null)
			{
				context = n.Text;
			}
			else
			{
				context = tableBinding.tableName;
			}

			$expression = new Select(context, tableBinding);
		}
	(	(DOT) => DOT n=NAME
			{
				List<NavigationItem> navigationItems = ddlPackage.getNavigation(context, n.Text);

				if (navigationItems == null) //is a column
				{
					ColumnExpression columnExpression = new ColumnExpression(n.Text);
					((Select)$expression).selectList.Add(columnExpression);
				}
				else //add data for join(s)
				{
					((Select)$expression).from.AddRange(navigationItems);
					context = navigationItems[navigationItems.Count-1].targetTable;
				}
			}

		| (	RARROW NAME LPAREN NAME (COMMA NAME)* BAR) =>
		  RARROW f=NAME LPAREN bl=bindingList[context] BAR ap=actualParameterList RPAREN
			{
				$expression = advancedFunctionCall((Select)$expression, f.Text, bl, ap);
				unregisterBindings(bl);
			}
		| RARROW f=NAME LPAREN ap=actualParameterList RPAREN
			{
				$expression = simpleFunctionCall((Select)$expression, f.Text, ap);
			}
	)*
  ;

bindingList[string tableName] returns [List<TableBinding> tableBindings]
  : n=NAME
		{
			$tableBindings = new List<TableBinding>();
			$tableBindings.Add(registerBinding(n.Text, tableName));
		}
				
	(COMMA n=NAME
		{
			$tableBindings.Add(registerBinding(n.Text, tableName));
		}
	)*
  ;

literal returns [Select select]
  : STRING {$select = new Select(new StringExpression($STRING.Text));}
  | NUMBER {$select = new Select(new NumberExpression($NUMBER.Text));}
  ;

actualParameterList returns [List<Expression> parameters] @init{$parameters = new List<Expression>();}
  : (le=logicalExpression
		{
			$parameters.Add(le);
		}
		(COMMA le2=logicalExpression
			{
				$parameters.Add(le2);
			}
		)*
	)?
  ;

arithmeticOperator returns [string op]
  : ao=addOperator		{$op = ao;}
  | mo=multiplyOperator	{$op = mo;}
  ;

logicalOperator returns [string op]
  : 'and'	{$op = "AND";}
  | 'or'	{$op = "OR";}
  | 'implies'	{$op = "IMPLIES";}
  //| 'xor'	{$op = "XOR";}
  ;

relationalOperator returns [string op]
  : EQUAL	{$op = $EQUAL.Text;}
  | GT		{$op = $GT.Text;}
  | LT		{$op = $LT.Text;}
  | GE		{$op = $GE.Text;}
  | LE		{$op = $LE.Text;}
  | NEQUAL	{$op = $NEQUAL.Text;}
  ;

addOperator returns [string op]
  : PLUS	{$op = $PLUS.Text;}
  | MINUS	{$op = $MINUS.Text;}
  ;

multiplyOperator returns [string op]
  : MULT	{$op = $MULT.Text;}
  | DIVIDE	{$op = $DIVIDE.Text;}
  ;

unaryOperator returns [string op]
  : MINUS	{$op = $MINUS.Text;}
  | 'not'	{$op = "NOT";}
  ;

//////////////////////////////////////////////////////////////////////////////

WS
	:	(' '
	|	'\t'
	|	'\n'
	|	'\r')
	{ $channel=Hidden; }
	;

LPAREN			: '(';
RPAREN			: ')';
LBRACK			: '[';
RBRACK			: ']';
LCURLY			: '{';
RCURLY			: '}';
COLON			: ':';
DCOLON			: '::';
COMMA			: ',';
EQUAL			: '=';
NEQUAL			: '<>';
LT				: '<';
GT				: '>';
LE				: '<=';
GE				: '>=';
RARROW			: '->';
DOTDOT			: '..';
DOT				: '.';
POUND			: '#';
SEMICOL			: ';';
BAR				: '|';
ATSIGN			: '@';
PLUS			: '+';
MINUS			: '-';
MULT			: '*';
DIVIDE			: '/';

NAME 
    : ( ('a'..'z') | ('A'..'Z') | ('_') ) 
        ( ('a'..'z') | ('0'..'9') | ('A'..'Z') | ('_') )* 
  ;

NUMBER 
  : ('0'..'9')+
    ( { input.LA(2) != '.' }? '.' ('0'..'9')+ )?
    ( ('e' | 'E') ('+' | '-')? ('0'..'9')+ )?
  ;

STRING : '\'' 
	(
	( ~ ('\'' | '\\' | '\n' | '\r') )
	| ('\\' ( ( 'n' | 't' | 'b' | 'r' | 'f' | '\\' | '\'' | '\"' )
		| ('0'..'3')
		  (('0'..'7')
			('0'..'7')?
		  )?
		|	('4'..'7')
		  (('0'..'9')
		  )?
		) ) )*
	'\''
    ;

SL_COMMENT: '--' (~'\n')* '\n'
	{$channel=Hidden;}
        ; 
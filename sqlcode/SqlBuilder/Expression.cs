//--------------------------------------------------------------------------------------------------//
//                                                                                                  //
//        DPO(Data Persistent Object)                                                               //
//                                                                                                  //
//          Copyright(c) Datum Connect Inc.                                                         //
//                                                                                                  //
// This source code is subject to terms and conditions of the Datum Connect Software License. A     //
// copy of the license can be found in the License.html file at the root of this distribution. If   //
// you cannot locate the  Datum Connect Software License, please send an email to                   //
// datconn@gmail.com. By using this source code in any fashion, you are agreeing to be bound        //
// by the terms of the Datum Connect Software License.                                              //
//                                                                                                  //
// You must not remove this notice, or any other, from this software.                               //
//                                                                                                  //
//                                                                                                  //
//--------------------------------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys.Data.Coding
{
	public sealed class Expression : IQueryScript
	{
		public static readonly Expression COUNT = new Expression().Append("COUNT(*)");
		public static readonly Expression STAR = new Expression().Append("*");

		private readonly StringBuilder script = new StringBuilder();

		/// <summary>
		/// Compound expression
		/// </summary>
		private bool compound = false;

		internal Expression()
		{
		}

		public string Query => script.ToString();

		private Expression AppendValue(object value)
		{
			script.Append(new SqlValue(value));
			return this;
		}

		private Expression Append(object x)
		{
			script.Append(x);
			return this;
		}

		private Expression Append(string x)
		{
			script.Append(x);
			return this;
		}

		private Expression AppendSpace(string x) => Append(x).AppendSpace();
		private Expression WrapSpace(string x) => AppendSpace().Append(x).AppendSpace();
		private Expression AffixSpace(string x) => AppendSpace().Append(x);
		private Expression AppendSpace() => Append(" ");


		internal static Expression Assign(string name, object value)
		{
			return ColumnName(name, null).WrapSpace("=").AppendValue(value);
		}

		internal static Expression Equal(string name, object value)
		{
			if (value == null || value == DBNull.Value)
				return ColumnName(name, null).AffixSpace("IS NULL");
			else
				return ColumnName(name, null).WrapSpace("=").AppendValue(value);
		}

		internal static Expression ColumnName(string name, string dbo)
		{
			Expression exp = new Expression();
			if (dbo != null)
				exp.Append(dbo)
					.Append(".");

			if (name == "*" || string.IsNullOrEmpty(name))
			{
				exp.Append("*");
			}
			else
			{
				exp.Append(new ColumnName(name));
			}

			return exp;
		}

		internal static Expression AllColumnNames(string dbo)
		{
			Expression exp = new Expression();
			if (dbo != null)
				exp.Append(dbo).Append(".");

			exp.Append("*");
			return exp;
		}

		public static Expression ParameterName(Context context, string name)
		{
			Expression exp = new Expression().Append(context.CreateParameter(name));
			return exp;
		}

		public static Expression AddParameter(Context context, string columnName, string parameterName)
		{
			Expression exp = new Expression()
				.Append(new ColumnName(columnName))
				.Append(" = ")
				.Append(context.CreateParameter(parameterName, columnName));

			return exp;
		}

		internal static Expression Join(Expression[] expl)
		{
			Expression exp = new Expression()
				.Append(string.Join<Expression>(",", expl));
			return exp;
		}

		internal static Expression Write(string any)
		{
			return new Expression().Append(any);
		}

		#region implicit section

		public static implicit operator Expression(VariableName value)
		{
			return new Expression().Append(value);    // s= 'string'
		}

		public static implicit operator Expression(string value)
		{
			return new Expression().AppendValue(value);    // s= 'string'
		}

		public static implicit operator Expression(bool value)
		{
			return new Expression().AppendValue(value);    // b=1 or b=0
		}


		public static implicit operator Expression(char value)
		{
			return new Expression().AppendValue(value);    // ch= 'c'
		}

		public static implicit operator Expression(byte value)
		{
			return new Expression().AppendValue(value);
		}

		public static implicit operator Expression(sbyte value)
		{
			return new Expression().AppendValue(value);
		}


		public static implicit operator Expression(int value)
		{
			return new Expression().AppendValue(value);
		}

		public static implicit operator Expression(short value)
		{
			return new Expression().AppendValue(value);
		}

		public static implicit operator Expression(ushort value)
		{
			return new Expression().AppendValue(value);
		}

		public static implicit operator Expression(uint value)
		{
			return new Expression().AppendValue(value);
		}

		public static implicit operator Expression(long value)
		{
			return new Expression().AppendValue(value);
		}

		public static implicit operator Expression(ulong value)
		{
			return new Expression().AppendValue(value);
		}

		public static implicit operator Expression(double value)
		{
			return new Expression().AppendValue(value);
		}

		public static implicit operator Expression(float value)
		{
			return new Expression().AppendValue(value);
		}

		public static implicit operator Expression(decimal value)
		{
			return new Expression().AppendValue(value);
		}

		public static implicit operator Expression(Guid value)
		{
			return new Expression().AppendValue(value);    // NULL
		}

		public static implicit operator Expression(DateTime value)
		{
			return new Expression().AppendValue(value);    //dt = '10/20/2012'
		}

		public static implicit operator Expression(DBNull value)
		{
			return new Expression().AppendValue(value);    // NULL
		}

		public static implicit operator Expression(Enum value)
		{
			return new Expression().AppendValue(Convert.ToInt32(value));    // NULL
		}

		#endregion


		/// <summary>
		/// string s = (string)expr;
		/// </summary>
		/// <param name="expr"></param>
		/// <returns></returns>
		public static explicit operator string(Expression expr)
		{
			return expr.ToString();
		}

		public Expression AS(VariableName name)
		{
			this.WrapSpace("AS").Append(name);
			return this;
		}


		public Expression this[Expression exp] => this.Append("[").Append(exp).Append("]");

		public Expression IN(SqlBuilder select)
		{
			this.WrapSpace($"IN ({select.Query})");
			return this;
		}

		public Expression IN(params Expression[] collection)
		{
			string values = string.Join(", ", collection.Select(x => x.ToString()));
			return this.AffixSpace($"IN ({values})");
		}

		public Expression IN<T>(IEnumerable<T> collection) => this.AffixSpace($"IN ({string.Join<T>(", ", collection)})");

		public Expression IS() => this.Append("IS");
		public Expression IS_NULL() => this.Append("IS NULL");
		public Expression IS_NOT_NULL() => this.Append("IS NOT NULL");
		public Expression NULL() => this.Append("NULL");

		public Expression NOT(Expression exp) => OPR("NOT", exp);
		public Expression BETWEEN(Expression exp1, Expression exp2) => this.WrapSpace($"BETWEEN").Append(OPR(exp1, "AND", exp2));
		public Expression EXISTS(SqlBuilder condition) => this.Append($"EXISTS ({condition})");

		public static Expression WHEN(Expression condition, Expression then)
		{
			return new Expression().AppendSpace("WHEN").Append(condition).WrapSpace("THEN").Append(then);
		}

		public static Expression CASE(Expression _case, Expression[] whens, Expression _else)
		{
			var expr = new Expression()
				.AppendSpace("CASE")
				.Append(_case)
				.AppendSpace();

			foreach (var when in whens)
			{
				expr.Append(when).AppendSpace();
			}

			if (_else is object)
				expr.AppendSpace("ELSE").Append(_else).AppendSpace();

			expr.Append("END");

			return expr;
		}

		#region +-*/, compare, logical operation

		/// <summary>
		/// Expression to string
		/// </summary>
		/// <param name="exp"></param>
		/// <returns></returns>
		private static string Expr2Str(Expression exp)
		{
			if (exp.compound)
				return string.Format("({0})", exp);
			else
				return exp.ToString();
		}

		internal static Expression OPR(Expression exp1, string opr, Expression exp2)
		{
			Expression exp = new Expression()
				.Append(string.Format("{0} {1} {2}", Expr2Str(exp1), opr, Expr2Str(exp2)));

			exp.compound = true;
			return exp;
		}

		// AND(A==1, B!=3, C>4) => "(A=1 AND B<>3 AND C>4)"
		internal static Expression OPR(Expression exp1, string opr, Expression[] exps)
		{
			Expression exp = new Expression();
			exp.Append("(")
			   .Append(string.Format("{0}", Expr2Str(exp1)));

			foreach (Expression exp2 in exps)
			{
				exp.Append(string.Format(" {0} {1}", opr, Expr2Str(exp2)));
			}

			exp.compound = true;
			return exp.Append(")");
		}

		private static Expression OPR(string opr, Expression exp1)
		{
			Expression exp = new Expression()
				.Append(string.Format("{0} {1}", opr, Expr2Str(exp1)));

			return exp;
		}

		public static Expression operator -(Expression exp1)
		{
			return OPR("-", exp1);
		}

		public static Expression operator +(Expression exp1)
		{
			return OPR("+", exp1);
		}

		public static Expression operator +(Expression exp1, Expression exp2)
		{
			return OPR(exp1, "+", exp2);
		}

		public static Expression operator -(Expression exp1, Expression exp2)
		{
			return OPR(exp1, "-", exp2);
		}

		public static Expression operator *(Expression exp1, Expression exp2)
		{
			return OPR(exp1, "*", exp2);
		}

		public static Expression operator /(Expression exp1, Expression exp2)
		{
			return OPR(exp1, "/", exp2);
		}

		public static Expression operator %(Expression exp1, Expression exp2)
		{
			return OPR(exp1, "%", exp2);
		}


		public static Expression operator ==(Expression exp1, Expression exp2)
		{
			if (exp2 is null || exp2.ToString() == "NULL")
			{
				Expression exp = new Expression().Append(exp1).Append(" IS NULL");
				return exp;
			}

			return OPR(exp1, "=", exp2);
		}


		public static Expression operator !=(Expression exp1, Expression exp2)
		{
			if (exp2 is null || exp2.ToString() == "NULL")
			{
				Expression exp = new Expression().Append(exp1).Append(" IS NOT NULL");
				return exp;
			}

			return OPR(exp1, "<>", exp2);
		}

		public static Expression operator >(Expression exp1, Expression exp2)
		{
			return OPR(exp1, ">", exp2);
		}

		public static Expression operator <(Expression exp1, Expression exp2)
		{
			return OPR(exp1, "<", exp2);
		}

		public static Expression operator >=(Expression exp1, Expression exp2)
		{
			return OPR(exp1, ">=", exp2);
		}

		public static Expression operator <=(Expression exp1, Expression exp2)
		{
			return OPR(exp1, "<=", exp2);
		}


		public static Expression operator &(Expression exp1, Expression exp2)
		{
			return OPR(exp1, "AND", exp2);
		}

		public static Expression operator |(Expression exp1, Expression exp2)
		{
			return OPR(exp1, "OR", exp2);
		}

		public static Expression operator ~(Expression exp)
		{
			return OPR("NOT", exp);
		}

		#endregion


		public static Expression Function(string func, params Expression[] expressions)
		{
			Expression exp = new Expression()
				.Append(func)
				.Append("(")
				.Append(string.Join<Expression>(",", expressions))
				.Append(")");

			return exp;
		}

		public override bool Equals(object obj)
		{
			return script.Equals(((Expression)obj).script);
		}

		public override int GetHashCode()
		{
			return script.GetHashCode();
		}

		public override string ToString()
		{
			return script.ToString();
		}
	}
}

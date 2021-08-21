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
	public static class FluentExpression
	{
		#region SqlExpr/SqlClause: ColumName/ParameterName/AddParameter


		public static Expression Assign(this string name, object value)
		{
			return Expression.Assign(name, value);
		}

		public static Expression Equal(this string name, object value)
		{
			return Expression.Equal(name, value);
		}


		public static Expression AS(this string columnName, string name)
		{
			return columnName.ColumnName().AS(name);
		}

		/// <summary>
		/// "name" -> "[name]"
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public static Expression ColumnName(this string name)
		{
			return Expression.ColumnName(name, null);
		}

		public static Expression ColumnName(this string name, string dbo)
		{
			return Expression.ColumnName(name, dbo);
		}

		public static Expression ColumnName(this string[] names)
		{
			var L = names.Select(column => column.ColumnName()).ToArray();
			return Expression.Join(L);
		}

		public static Expression Func(this string name, params Expression[] args)
		{
			return Expression.Function(name, args);
		}


		/// <summary>
		/// write directly into SQL clause
		/// </summary>
		/// <param name="any"></param>
		/// <returns></returns>
		public static Expression Inject(this string any)
		{
			return Expression.Write(any);
		}


		/// <summary>
		/// "name" -> "@name"
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public static Expression ParameterName(this Context context, string name)
		{
			return Expression.ParameterName(context, name);
		}

		/// <summary>
		/// "name" -> "[name]=@name"
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public static Expression AddParameter(this Context context, string columnName)
		{
			return Expression.AddParameter(context, columnName, columnName);
		}

		/// <summary>
		/// Add SQL parameter
		/// e.g. context.AddParameter(NodeDpo._ID, TaskDpo._ParentID) -> "[ID]=@ParentID"
		/// </summary>
		/// <param name="columnName"></param>
		/// <param name="parameterName"></param>
		/// <returns></returns>
		public static Expression AddParameter(this Context context, string columnName, string parameterName)
		{
			return Expression.AddParameter(context, columnName, parameterName);
		}

		#endregion

		public static Expression AND(this Expression exp1, Expression exp2)
		{
			return Expression.OPR(exp1, "AND", exp2);
		}

		public static Expression AND(this IEnumerable<Expression> expl)
		{
			if (expl.Count() > 1)
				return Expression.OPR(expl.First(), "AND", expl.Skip(1).ToArray());
			else
				return expl.First();
		}


		public static Expression OR(this Expression exp1, Expression exp2)
		{
			return Expression.OPR(exp1, "OR", exp2);
		}

		public static Expression OR(this IEnumerable<Expression> expl)
		{
			if (expl.Count() > 1)
				return Expression.OPR(expl.First(), "OR", expl.Skip(1).ToArray());
			else
				return expl.First();
		}


		public static Expression LEN(this Expression expr)
		{
			return Expression.Function("LEN", expr);
		}

		public static Expression SUBSTRING(this Expression expr, Expression start, Expression length)
		{
			return Expression.Function("SUBSTRING", expr, start, length);
		}


		public static Expression SUM(this Expression expr)
		{
			return Expression.Function("SUM", expr);
		}

		public static Expression MAX(this Expression expr)
		{
			return Expression.Function("MAX", expr);
		}

		public static Expression MIN(this Expression expr)
		{
			return Expression.Function("MIN", expr);
		}

		public static Expression COUNT(this Expression expr)
		{
			return Expression.Function("COUNT", expr);
		}

		public static Expression GETDATE()
		{
			return Expression.Function("GETDATE");
		}

		public static Expression NOT(this Expression expr)
		{
			return new Expression().NOT(expr);
		}

		public static Expression EXISTS(this SqlBuilder sql)
		{
			return new Expression().EXISTS(sql);
		}

		public static Expression WHEN(this Expression condition, Expression then)
		{
			return Expression.WHEN(condition, then);
		}
	}
}

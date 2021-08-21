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
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys.Data.Coding
{
	/// <summary>
	/// SQL clauses builder
	/// </summary>
	public class SqlBuilder : IQueryScript
	{
		private readonly List<string> script = new List<string>();
		protected bool compound = false;

		public SqlBuilder()
		{
		}

		public string Query
		{
			get
			{
				StringBuilder builder = new StringBuilder();
				foreach (string item in script)
					builder.Append(item);

				return builder.ToString().Trim();
			}
		}

		protected SqlBuilder Append(string text)
		{
			script.Add(text);
			return this;
		}

		protected SqlBuilder AppendSpace(string text)
		{
			script.Add(text + " ");
			return this;
		}

		protected SqlBuilder AppendLine(string value)
		{
			return Append(value).AppendLine();
		}

		protected SqlBuilder AppendLine()
		{
			return Append(Environment.NewLine);
		}

		private SqlBuilder TABLE_NAME(TableName tableName, string alias)
		{
			AppendSpace(tableName.ToString());
			if (!string.IsNullOrEmpty(alias))
				AppendSpace(alias);

			return this;
		}

		public SqlBuilder USE(string database)
		{
			return AppendLine($"USE {database}");
		}


		public SqlBuilder SET(string key, Expression value)
		{
			return AppendLine($"SET {key} {value}");
		}

		#region SELECT clause

		public SqlBuilder SELECT() => AppendSpace("SELECT");

		public SqlBuilder DISTINCT() => AppendSpace("DISTINCT");

		public SqlBuilder ALL() => AppendSpace("ALL");

		public SqlBuilder TOP(int n)
		{
			if (n > 0)
				return AppendSpace($"TOP {n}");

			return this;
		}

		protected SqlBuilder COLUMNS(string columns)
		{
			return AppendSpace(columns);
		}

		public SqlBuilder COLUMNS(IEnumerable<string> columns)
		{
			if (columns.Count() == 0)
				return COLUMNS("*");
			else
			{
				var L = columns.Select(column => column.ColumnName());
				return COLUMNS(string.Join(",", L));
			}
		}

		public SqlBuilder COLUMNS(params Expression[] columns)
		{
			if (columns.Count() == 0)
				return COLUMNS("*");
			else
			{
				var L = columns.Select(column => column.ToString());
				return COLUMNS(string.Join(", ", L));
			}
		}

		#endregion

		public SqlBuilder FROM<T>(string alias = null)
		{
			return FROM(typeof(T).TableName(), alias);
		}

		public SqlBuilder FROM(TableName from, string alias = null) => AppendSpace($"FROM").TABLE_NAME(from, alias);


		public SqlBuilder UPDATE<T>(string alias = null)
		{
			return UPDATE(typeof(T).TableName(), alias);
		}

		public SqlBuilder UPDATE(TableName tableName, string alias = null)
		{
			return AppendSpace($"UPDATE").TABLE_NAME(tableName, alias);
		}

		public SqlBuilder SET(params Expression[] assignments) => SET(string.Join<Expression>(", ", assignments));

		public SqlBuilder SET(string assignments) => AppendSpace("SET").AppendSpace(assignments);

		public SqlBuilder INSERT_INTO<T>(params string[] columns)
		{
			return INSERT_INTO(typeof(T).TableName(), columns);
		}

		public SqlBuilder INSERT_INTO(TableName tableName)
		{
			AppendSpace($"INSERT INTO").TABLE_NAME(tableName, null);

			return this;
		}

		public SqlBuilder INSERT_INTO(TableName tableName, IEnumerable<string> columns)
		{
			AppendSpace($"INSERT INTO").TABLE_NAME(tableName, null);

			if (columns.Count() > 0)
				AppendSpace($"({JoinColumns(columns)})");

			return this;
		}

		public SqlBuilder VALUES(params object[] values)
		{
			return AppendLine($"VALUES ({JoinValues(values)})");
		}

		private static string JoinValues(object[] values)
		{
			return string.Join(",", values.Select(x => new SqlValue(x).ToString()));
		}

		public SqlBuilder DELETE<T>()
		{
			return DELETE(typeof(T).TableName());
		}

		public SqlBuilder DELETE(TableName tableName)
		{
			return AppendSpace($"DELETE FROM").TABLE_NAME(tableName, null);
		}


		#region WHERE clause

		public SqlBuilder WHERE(Expression exp)
		{
			AppendSpace($"WHERE {exp}");
			return this;
		}

		public SqlBuilder WHERE(string exp)
		{
			if (string.IsNullOrEmpty(exp))
				return this;

			return AppendSpace($"WHERE {exp}");
		}

		#endregion


		#region INNER/OUT JOIN clause

		public SqlBuilder LEFT() => AppendSpace("LEFT");

		public SqlBuilder RIGHT() => AppendSpace("RIGHT");

		public SqlBuilder INNER() => AppendSpace("INNER");

		public SqlBuilder OUTTER() => AppendSpace("OUTTER");

		public SqlBuilder JOIN<T>(string alias = null) => JOIN(typeof(T).TableName(), alias);

		public SqlBuilder JOIN(TableName tableName, string alias = null) => AppendSpace("JOIN").TABLE_NAME(tableName, alias);

		public SqlBuilder ON(Expression exp)
		{
			AppendSpace($"ON {exp}");
			return this;
		}

		#endregion



		#region GROUP BY / HAVING clause
		public SqlBuilder GROUP_BY(params Expression[] columns)
		{
			if (columns == null || columns.Length == 0)
				return this;

			string _columns = string.Join(",", columns.Select(x => $"{x}"));
			return AppendSpace($"GROUP BY {_columns}");
		}

		public SqlBuilder GROUP_BY(params string[] columns)
		{
			if (columns == null || columns.Length == 0)
				return this;

			return AppendSpace($"GROUP BY {JoinColumns(columns)}");
		}

		public SqlBuilder HAVING(Expression expr)
		{
			return AppendSpace($"HAVING {expr}");
		}

		#endregion



		public SqlBuilder ORDER_BY(params Expression[] columns)
		{
			if (columns == null || columns.Length == 0)
				return this;

			string _columns = string.Join(",", columns.Select(x => $"{x}"));
			return AppendSpace($"ORDER BY {_columns}");
		}

		public SqlBuilder ORDER_BY(params string[] columns)
		{
			if (columns == null || columns.Length == 0)
				return this;

			return AppendSpace($"ORDER BY {JoinColumns(columns)}");
		}

		public SqlBuilder UNION() => AppendSpace("UNION");
		public SqlBuilder DESC() => AppendSpace("DESC");
		public SqlBuilder ASC() => AppendSpace("ASC");

		private static string JoinColumns(IEnumerable<string> columns)
		{
			return string.Join(",", columns.Select(x => new ColumnName(x)));
		}


		/// <summary>
		/// concatenate 2 clauses in TWO lines
		/// </summary>
		/// <param name="clause1"></param>
		/// <param name="clause2"></param>
		/// <returns></returns>
		public static SqlBuilder operator +(SqlBuilder clause1, SqlBuilder clause2)
		{
			var builder = new SqlBuilder()
				.AppendLine(clause1.Query)
				.AppendLine(clause2.Query);

			builder.compound = true;
			return builder;
		}

		/// <summary>
		/// concatenate 2 clauses in one line
		/// </summary>
		/// <param name="clause1"></param>
		/// <param name="clause2"></param>
		/// <returns></returns>
		public static SqlBuilder operator -(SqlBuilder clause1, SqlBuilder clause2)
		{
			return new SqlBuilder()
				.Append(clause1.Query)
				.Append(" ")
				.Append(clause2.Query);
		}

		public static explicit operator string(SqlBuilder sql)
		{
			return sql.Query;
		}


		public override string ToString() => Query;
	}
}

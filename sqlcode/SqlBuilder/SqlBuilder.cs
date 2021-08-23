﻿//--------------------------------------------------------------------------------------------------//
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
    public sealed class SqlBuilder : IQueryScript
    {
        private readonly List<string> script = new List<string>();

        public SqlBuilder()
        {
        }

        public string Script
        {
            get
            {
                StringBuilder builder = new StringBuilder();
                foreach (string item in script)
                    builder.Append(item);

                return builder.ToString().Trim();
            }
        }

        /// <summary>
        /// Append any code
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public SqlBuilder Append(string text)
        {
            script.Add(text);
            return this;
        }

        /// <summary>
        /// Add a new line
        /// </summary>
        /// <returns></returns>
        private SqlBuilder AppendLine()
        {
            return Append(Environment.NewLine);
        }

        private SqlBuilder AppendSpace(string text)
        {
            script.Add(text + " ");
            return this;
        }

        private SqlBuilder AppendSemicolon(string text)
        {
            script.Add(text + ";");
            return this;
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
            return AppendSpace($"USE {database}");
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

        private SqlBuilder COLUMNS(string columns)
        {
            return AppendSpace(columns);
        }

        public SqlBuilder COLUMNS()
        {
            return COLUMNS("*");
        }

        public SqlBuilder COLUMNS(params Expression[] columns)
        {
            if (columns.Count() == 0)
                return COLUMNS("*");
            else
                return COLUMNS(JoinColumns(columns));
        }

        public SqlBuilder COLUMNS(params string[] columns)
        {
            if (columns.Length == 0)
                return COLUMNS("*");
            else
                return COLUMNS(JoinColumns(columns));
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

        public SqlBuilder SET(params Expression[] assignments) => AppendSpace("SET").AppendSpace(string.Join<Expression>(", ", assignments));

        public SqlBuilder INSERT_INTO<T>(params string[] columns)
        {
            return INSERT_INTO(typeof(T).TableName(), columns);
        }

        public SqlBuilder INSERT_INTO(TableName tableName)
        {
            AppendSpace($"INSERT INTO").TABLE_NAME(tableName, null);

            return this;
        }
        public SqlBuilder INSERT_INTO(TableName tableName, IEnumerable<Expression> columns)
        {
            AppendSpace($"INSERT INTO").TABLE_NAME(tableName, null);

            if (columns.Count() > 0)
                AppendSpace($"({JoinColumns(columns)})");

            return this;
        }

        public SqlBuilder INSERT_INTO(TableName tableName, IEnumerable<string> columns)
        {
            AppendSpace($"INSERT INTO").TABLE_NAME(tableName, null);

            if (columns.Count() > 0)
                AppendSpace($"({JoinColumns(columns)})");

            return this;
        }

        public SqlBuilder VALUES(params Expression[] values)
        {
            return AppendSpace($"VALUES ({string.Join<Expression>(", ", values)})");
        }

        public SqlBuilder DELETE_FROM<T>()
        {
            return DELETE_FROM(typeof(T).TableName());
        }

        public SqlBuilder DELETE_FROM(TableName tableName)
        {
            return AppendSpace($"DELETE FROM").TABLE_NAME(tableName, null);
        }

        /// <summary>
        /// skip WHERE if expr is null
        /// </summary>
        /// <param name="expr"></param>
        /// <returns></returns>
        public SqlBuilder WHERE(Expression expr)
        {
            if (expr is null)
                return this;

            return WHERE(expr.Script);
        }

        /// <summary>
        /// skip WHERE if expr is null or empty
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public SqlBuilder WHERE(string condition)
        {
            if (!string.IsNullOrEmpty(condition))
                AppendSpace($"WHERE {condition}");

            return this;
        }


        #region INNER/OUT JOIN clause

        public SqlBuilder LEFT() => AppendSpace("LEFT");

        public SqlBuilder RIGHT() => AppendSpace("RIGHT");

        public SqlBuilder INNER() => AppendSpace("INNER");

        public SqlBuilder OUTTER() => AppendSpace("OUTTER");
        public SqlBuilder FULL() => AppendSpace("FULL");

        public SqlBuilder JOIN<T>(string alias = null) => JOIN(typeof(T).TableName(), alias);

        public SqlBuilder JOIN(TableName tableName, string alias = null) => AppendSpace("JOIN").TABLE_NAME(tableName, alias);

        public SqlBuilder ON(Expression expr)
        {
            AppendSpace($"ON {expr}");
            return this;
        }

        #endregion



        #region GROUP BY / HAVING clause
        public SqlBuilder GROUP_BY(params Expression[] columns)
        {
            if (columns == null || columns.Length == 0)
                return this;

            return AppendSpace($"GROUP BY {JoinColumns(columns)}");
        }

        public SqlBuilder GROUP_BY(params string[] columns)
        {
            if (columns == null || columns.Length == 0)
                return this;

            return AppendSpace($"GROUP BY {JoinColumns(columns)}");
        }

        public SqlBuilder HAVING(Expression condition)
        {
            return AppendSpace($"HAVING {condition}");
        }

        #endregion



        public SqlBuilder ORDER_BY(params Expression[] columns)
        {
            if (columns == null || columns.Length == 0)
                return this;

            return AppendSpace($"ORDER BY {JoinColumns(columns)}");
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

        public SqlBuilder INTO(TableName tableName) => AppendSpace("INTO").TABLE_NAME(tableName, null);

        public SqlBuilder ALTER() => AppendSpace("ALTER");
        public SqlBuilder CREATE() => AppendSpace("CREATE");
        public SqlBuilder DROP() => AppendSpace("DROP");

        private static string JoinColumns(IEnumerable<Expression> columns)
        {
            return string.Join(", ", columns.Select(x => x.ToString()));
        }

        private static string JoinColumns(IEnumerable<string> columns)
        {
            return string.Join(", ", columns.Select(x => new ColumnName(x)));
        }


        public static explicit operator string(SqlBuilder sql)
        {
            return sql.Script;
        }


        public override string ToString() => Script;
    }
}
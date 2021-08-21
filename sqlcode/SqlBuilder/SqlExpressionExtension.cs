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
    public static class SqlExpressionExtension 
    {
        #region SqlExpr/SqlClause: ColumName/ParameterName/AddParameter

    
        public static SqlExpression Assign(this string name, object value)
        {
          return SqlExpression.Assign(name, value);
        }

        public static SqlExpression Equal(this string name, object value)
        {
            return SqlExpression.Equal(name, value);
        }


        public static SqlExpression AS(this string columnName, string name)
		{
            return columnName.ColumnName().AS(name);
        }

        /// <summary>
        /// "name" -> "[name]"
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static SqlExpression ColumnName(this string name)
        {
            return SqlExpression.ColumnName(name, null);
        }

        public static SqlExpression ColumnName(this string name, string dbo)
        {
            return SqlExpression.ColumnName(name, dbo);
        }

        public static SqlExpression ColumnName(this string[] names)
        {
            var L = names.Select(column => column.ColumnName()).ToArray();
            return SqlExpression.Join(L);
        }

        public static SqlExpression Func(this string name, params SqlExpression[] args)
        {
            return SqlExpression.Func(name, args);
        }


        /// <summary>
        /// write directly into SQL clause
        /// </summary>
        /// <param name="any"></param>
        /// <returns></returns>
        public static SqlExpression Inject(this string any)
        {
            return SqlExpression.Write(any);
        }
        /// <summary>
        /// "name" -> "@name"
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static SqlExpression ParameterName(this string name)
        {
            return SqlExpression.ParameterName(name);
        }


        /// <summary>
        /// "name" -> "[name]=@name"
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static SqlExpression AddParameter(this string columnName)
        {
            return SqlExpression.AddParameter(columnName, columnName);
        }

        /// <summary>
        /// Add SQL parameter
        /// e.g. NodeDpo._ID.AddParameter(TaskDpo._ParentID) -> "[ID]=@ParentID"
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="parameterName"></param>
        /// <returns></returns>
        public static SqlExpression AddParameter(this string columnName, string parameterName)
        {
            return SqlExpression.AddParameter(columnName, parameterName);
        }

        #endregion

        public static SqlExpression AND(this SqlExpression exp1, SqlExpression exp2)
        {
            return SqlExpression.OPR(exp1, "AND", exp2);
        }

        public static SqlExpression AND(this IEnumerable<SqlExpression> expl)
        {
            if(expl.Count() >1)
                return SqlExpression.OPR(expl.First(), "AND", expl.Skip(1).ToArray());
            else
                return expl.First();
        }


        public static SqlExpression OR(this SqlExpression exp1, SqlExpression exp2)
        {
            return SqlExpression.OPR(exp1, "OR", exp2);
        }

        public static SqlExpression OR(this IEnumerable<SqlExpression> expl)
        {
            if (expl.Count() > 1)
                return SqlExpression.OPR(expl.First(), "OR", expl.Skip(1).ToArray());
            else
                return expl.First();
        }


        public static SqlExpression LEN(this SqlExpression expr)
        {
            return SqlExpression.Func("LEN", expr);
        }

        public static SqlExpression SUBSTRING(this SqlExpression expr, SqlExpression start, SqlExpression length)
        {
            return SqlExpression.Func("SUBSTRING", expr, start, length);
        }


        public static SqlExpression SUM(this SqlExpression expr)
        {
            return SqlExpression.Func("SUM", expr);
        }

        public static SqlExpression MAX(this SqlExpression expr)
        {
            return SqlExpression.Func("MAX", expr);
        }

        public static SqlExpression MIN(this SqlExpression expr)
        {
            return SqlExpression.Func("MIN", expr);
        }

        public static SqlExpression COUNT(this SqlExpression expr)
        {
            return SqlExpression.Func("COUNT", expr);
        }

        public static SqlExpression GETDATE()
        {
            return SqlExpression.Func("GETDATE");
        }
    }
}

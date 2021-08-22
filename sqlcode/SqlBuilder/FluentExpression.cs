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

        public static Expression Assign(this string name, object value)
        {
            return Expression.OPR(new Expression(new ColumnName(name)), "=", new Expression(new SqlValue(value)));
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
            return new Expression(new ColumnName(name));
        }

        public static Expression ColumnName(this string name, string dbo)
        {
            return new Expression(new ColumnName(dbo, name));
        }

        public static Expression ColumnName(this string[] names)
        {
            var L = names.Select(column => column.ColumnName()).ToArray();
            return Expression.Join(", ", L);
        }

        public static Expression Func(this string name, params Expression[] args)
        {
            return Expression.Function(name, args);
        }


        /// <summary>
        /// "name" -> "@name"
        /// </summary>
        /// <param name="parameterName"></param>
        /// <returns></returns>
        public static Expression ParameterName(this Context context, string parameterName, object value = null)
        {
            return new Expression(context.CreateParameter(parameterName, value));
        }


        public static Expression AND(this IEnumerable<Expression> expList)
        {
            return Expression.OPR("AND", expList);
        }


        public static Expression OR(this IEnumerable<Expression> expList)
        {
            return Expression.OPR("OR", expList);
        }


        public static Expression NOT(this Expression expr)
        {
            return new Expression().NOT(expr);
        }

        public static Expression EXISTS(this SqlBuilder sql)
        {
            return new Expression().EXISTS(sql);
        }
    }
}

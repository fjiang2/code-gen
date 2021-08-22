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
        /// <summary>
        /// Create variable 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Expression AsVariable(this string name)
        {
            return new Expression(new VariableName(name));
        }

        /// <summary>
        /// Create parameter: @parameterName with value
        /// </summary>
        /// <param name="context"></param>
        /// <param name="parameterName">name of parameter</param>
        /// <param name="value">the value of parameter</param>
        /// <returns></returns>
        public static Expression AsParameter(this Context context, string parameterName, object value = null)
        {
            return new Expression(context.CreateParameter(parameterName, value));
        }

        /// <summary>
        /// Create column name: "name" -> [name]
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Expression AsColumn(this string name)
        {
            return new Expression(new ColumnName(name));
        }

        /// <summary>
        /// Create column name:  [Categories].[CategoryID], C.[CategoryID]
        /// </summary>
        /// <param name="name"></param>
        /// <param name="owner"></param>
        /// <returns></returns>

        public static Expression AsColumn(this string name, string owner)
        {
            return new Expression(new ColumnName(owner, name));
        }

        /// <summary>
        /// Assing value to column: [column-Name] = value
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Expression AsColumnAssign(this string columnName, object value)
        {
            return columnName.AsColumn().Assign(value);
        }

        /// <summary>
        /// Create AND operation chain
        /// </summary>
        /// <param name="exprList"></param>
        /// <returns></returns>
        public static Expression AND(this IEnumerable<Expression> exprList)
        {
            return Expression.AND(exprList.ToArray());
        }

        /// <summary>
        /// Create OR operation chain
        /// </summary>
        /// <param name="exprList"></param>
        /// <returns></returns>
        public static Expression OR(this IEnumerable<Expression> exprList)
        {
            return Expression.OR(exprList.ToArray());
        }


        /// <summary>
        /// Create SQL: EXISTS(SELECT * FROM Products)
        /// </summary>
        /// <param name="select"></param>
        /// <returns></returns>
        public static Expression EXISTS(this SqlBuilder select)
        {
            return Expression.EXISTS(select);
        }

        /// <summary>
        /// Create function call
        /// </summary>
        /// <param name="func"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static Expression Function(this string func, params Expression[] args)
        {
            return Expression.Function(func, args);
        }

    }
}

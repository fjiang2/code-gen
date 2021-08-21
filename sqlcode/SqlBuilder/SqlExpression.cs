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
    public sealed class SqlExpression : SqlBuilderInfo
    {
        public static readonly SqlExpression COUNT = new SqlExpression().Append("COUNT(*)");

        private readonly StringBuilder script = new StringBuilder();

        private SqlExpression()
        {
        }

        private SqlExpression AppendValue(object value)
        {
            script.Append(new SqlValue(value));
            return this;
        }

        private SqlExpression Append(object x)
        {
            script.Append(x);
            return this;
        }

        private SqlExpression Append(string x)
        {
            script.Append(x);
            return this;
        }

        private SqlExpression AppendSpace(string x) => Append(x).AppendSpace();
        private SqlExpression WrapSpace(string x) => AppendSpace().Append(x).AppendSpace();
        private SqlExpression AffixSpace(string x) => AppendSpace().Append(x);
        private SqlExpression AppendSpace() => Append(" ");


        internal static SqlExpression Assign(string name, object value)
        {
            return ColumnName(name, null).WrapSpace("=").AppendValue(value);
        }

        internal static SqlExpression Equal(string name, object value)
        {
            if (value == null || value == DBNull.Value)
                return ColumnName(name, null).WrapSpace("IS NULL");
            else
                return ColumnName(name, null).WrapSpace("=").AppendValue(value);
        }

        internal static SqlExpression ColumnName(string name, string dbo)
        {
            SqlExpression exp = new SqlExpression();
            if (dbo != null)
                exp.Append(dbo)
                    .Append(".");

            if (name == "*" || string.IsNullOrEmpty(name))
            {
                exp.Append("*");
            }
            else
            {
                exp.Append("[" + name + "]");
            }

            return exp;
        }

        internal static SqlExpression AllColumnNames(string dbo)
        {
            SqlExpression exp = new SqlExpression();
            if (dbo != null)
                exp.Append(dbo).Append(".");

            exp.Append("*");
            return exp;
        }

        internal static SqlExpression ParameterName(string name)
        {
            SqlExpression exp = new SqlExpression().Append(name.SqlParameterName());
            exp.AddParam(name, null);
            return exp;
        }

        internal static SqlExpression AddParameter(string columnName, string parameterName)
        {
            SqlExpression exp = new SqlExpression()
                .Append("[" + columnName + "]")
                .Append("=")
                .Append(parameterName.SqlParameterName());

            exp.AddParam(parameterName, columnName);

            return exp;
        }

        internal static SqlExpression Join(SqlExpression[] expl)
        {
            SqlExpression exp = new SqlExpression()
                .Append(string.Join<SqlExpression>(",", expl));
            return exp;
        }

        internal static SqlExpression Write(string any)
        {
            return new SqlExpression().Append(any);
        }

        #region implicit section

        public static implicit operator SqlExpression(VariableName value)
        {
            return new SqlExpression().Append(value);    // s= 'string'
        }

        public static implicit operator SqlExpression(string value)
        {
            return new SqlExpression().AppendValue(value);    // s= 'string'
        }

        public static implicit operator SqlExpression(bool value)
        {
            return new SqlExpression().AppendValue(value);    // b=1 or b=0
        }


        public static implicit operator SqlExpression(char value)
        {
            return new SqlExpression().AppendValue(value);    // ch= 'c'
        }

        public static implicit operator SqlExpression(byte value)
        {
            return new SqlExpression().AppendValue(value);
        }

        public static implicit operator SqlExpression(sbyte value)
        {
            return new SqlExpression().AppendValue(value);
        }


        public static implicit operator SqlExpression(int value)
        {
            return new SqlExpression().AppendValue(value);
        }

        public static implicit operator SqlExpression(short value)
        {
            return new SqlExpression().AppendValue(value);
        }

        public static implicit operator SqlExpression(ushort value)
        {
            return new SqlExpression().AppendValue(value);
        }

        public static implicit operator SqlExpression(uint value)
        {
            return new SqlExpression().AppendValue(value);
        }

        public static implicit operator SqlExpression(long value)
        {
            return new SqlExpression().AppendValue(value);
        }

        public static implicit operator SqlExpression(ulong value)
        {
            return new SqlExpression().AppendValue(value);
        }

        public static implicit operator SqlExpression(float value)
        {
            return new SqlExpression().AppendValue(value);
        }

        public static implicit operator SqlExpression(DateTime value)
        {
            return new SqlExpression().AppendValue(value);    //dt = '10/20/2012'
        }

        public static implicit operator SqlExpression(DBNull value)
        {
            return new SqlExpression().AppendValue(value);    // NULL
        }

        public static implicit operator SqlExpression(Enum value)
        {
            return new SqlExpression().AppendValue(Convert.ToInt32(value));    // NULL
        }

        #endregion


        /// <summary>
        /// string s = (string)expr;
        /// </summary>
        /// <param name="expr"></param>
        /// <returns></returns>
        public static explicit operator string(SqlExpression expr)
        {
            return expr.ToString();
        }

        public SqlExpression AS(VariableName name)
        {
            this.WrapSpace("AS").Append(name);
            return this;
        }


        public SqlExpression this[SqlExpression exp] => this.Append("[").Append(exp).Append("]");

        public SqlExpression IN(SqlBuilder select)
        {
            this.WrapSpace($"IN ({select.Query})");
            this.Merge(select);
            return this;
        }

        public SqlExpression IN(params SqlExpression[] collection)
        {
            string values = string.Join(", ", collection.Select(x => x.ToString()));
            return this.AffixSpace($"IN ({values})");
        }

        public SqlExpression IN<T>(IEnumerable<T> collection) => this.AffixSpace($"IN ({string.Join<T>(", ", collection)})");

        public SqlExpression BETWEEN(SqlExpression exp1, SqlExpression exp2) => this.AffixSpace($"BETWEEN {exp1} AND {exp2}");

        public SqlExpression IS() => this.WrapSpace("IS");
        public SqlExpression IS_NULL() => this.WrapSpace("IS NULL");
        public SqlExpression IS_NOT_NULL() => this.WrapSpace("IS NOT NULL");
        public SqlExpression NOT() => this.WrapSpace("NOT");
        public SqlExpression NULL() => this.WrapSpace("NULL");


        #region +-*/, compare, logical operation

        /// <summary>
        /// Compound expression
        /// </summary>
        private bool compound = false;

        private static string ExpToString(SqlExpression exp)
        {
            if (exp.compound)
                return string.Format("({0})", exp);
            else
                return exp.ToString();
        }

        internal static SqlExpression OPR(SqlExpression exp1, string opr, SqlExpression exp2)
        {
            SqlExpression exp = new SqlExpression()
                .Append(string.Format("{0} {1} {2}", ExpToString(exp1), opr, ExpToString(exp2)));

            exp.Merge(exp1).Merge(exp2);

            exp.compound = true;
            return exp;
        }

        // AND(A==1, B!=3, C>4) => "(A=1 AND B<>3 AND C>4)"
        internal static SqlExpression OPR(SqlExpression exp1, string opr, SqlExpression[] exps)
        {
            SqlExpression exp = new SqlExpression();
            exp.Append("(")
               .Append(string.Format("{0}", ExpToString(exp1)));

            foreach (SqlExpression exp2 in exps)
            {
                exp.Append(string.Format(" {0} {1}", opr, ExpToString(exp2)));
            }

            exp.compound = true;
            return exp.Append(")");
        }

        private static SqlExpression OPR(string opr, SqlExpression exp1)
        {
            SqlExpression exp = new SqlExpression()
                .Append(string.Format("{0} {1}", opr, ExpToString(exp1)));

            exp.Merge(exp1);
            return exp;
        }

        public static SqlExpression operator -(SqlExpression exp1)
        {
            return OPR("-", exp1);
        }

        public static SqlExpression operator +(SqlExpression exp1)
        {
            return OPR("+", exp1);
        }

        public static SqlExpression operator +(SqlExpression exp1, SqlExpression exp2)
        {
            return OPR(exp1, "+", exp2);
        }

        public static SqlExpression operator -(SqlExpression exp1, SqlExpression exp2)
        {
            return OPR(exp1, "-", exp2);
        }

        public static SqlExpression operator *(SqlExpression exp1, SqlExpression exp2)
        {
            return OPR(exp1, "*", exp2);
        }

        public static SqlExpression operator /(SqlExpression exp1, SqlExpression exp2)
        {
            return OPR(exp1, "/", exp2);
        }

        public static SqlExpression operator %(SqlExpression exp1, SqlExpression exp2)
        {
            return OPR(exp1, "%", exp2);
        }


        public static SqlExpression operator ==(SqlExpression exp1, SqlExpression exp2)
        {
            if ((object)exp2 == null || exp2.ToString() == "NULL")
            {
                SqlExpression exp = new SqlExpression().Append(exp1).Append(" IS NULL");
                exp.Merge(exp1);
                return exp;
            }

            return OPR(exp1, "=", exp2);
        }


        public static SqlExpression operator !=(SqlExpression exp1, SqlExpression exp2)
        {
            if ((object)exp2 == null || exp2.ToString() == "NULL")
            {
                SqlExpression exp = new SqlExpression().Append(exp1).Append(" IS NOT NULL");
                exp.Merge(exp1);
                return exp;
            }

            return OPR(exp1, "<>", exp2);
        }

        public static SqlExpression operator >(SqlExpression exp1, SqlExpression exp2)
        {
            return OPR(exp1, ">", exp2);
        }

        public static SqlExpression operator <(SqlExpression exp1, SqlExpression exp2)
        {
            return OPR(exp1, "<", exp2);
        }

        public static SqlExpression operator >=(SqlExpression exp1, SqlExpression exp2)
        {
            return OPR(exp1, ">=", exp2);
        }

        public static SqlExpression operator <=(SqlExpression exp1, SqlExpression exp2)
        {
            return OPR(exp1, "<=", exp2);
        }


        public static SqlExpression operator &(SqlExpression exp1, SqlExpression exp2)
        {
            return OPR(exp1, "AND", exp2);
        }

        public static SqlExpression operator |(SqlExpression exp1, SqlExpression exp2)
        {
            return OPR(exp1, "OR", exp2);
        }

        public static SqlExpression operator ~(SqlExpression exp)
        {
            return OPR("NOT", exp);
        }

        #endregion


        #region SQL Function

        internal static SqlExpression Func(string func, params SqlExpression[] expl)
        {
            SqlExpression exp = new SqlExpression()
                .Append(func)
                .Append("(")
                .Append(string.Join<SqlExpression>(",", expl))
                .Append(")");

            //exp.Merge(exp1);
            return exp;
        }


        #endregion


        public override bool Equals(object obj)
        {
            return script.Equals(((SqlExpression)obj).script);
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

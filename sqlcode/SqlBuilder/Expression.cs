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
    public sealed partial class Expression : IQueryScript
    {
        public static readonly Expression STAR = new Expression("*");
        public static readonly Expression COUNT_STAR = new Expression("COUNT(*)");
        

        private readonly StringBuilder script = new StringBuilder();

        /// <summary>
        /// Compound expression
        /// </summary>
        private bool compound = false;

        internal Expression(VariableName name)
        {
            script.Append(name);
        }

        internal Expression(ColumnName name)
        {
            script.Append(name);
        }

        internal Expression(ParameterName name)
        {
            script.Append(name);
        }

        internal Expression(SqlValue value)
        {
            script.Append(value);
        }

        private Expression(Expression expr)
        {
            this.script = new StringBuilder(expr.script.ToString());
            this.compound = expr.compound;
        }

        private Expression(string text)
        {
            script.Append(text);
        }


        public string Query => script.ToString();
        public Expression this[Expression exp] => this.Append("[").Append(exp).Append("]");

        private Expression Append(Expression expr)
        {
            script.Append(expr);
            return this;
        }

        private Expression Append(VariableName name)
        {
            script.Append(name);
            return this;
        }

        private Expression Append(string text)
        {
            script.Append(text);
            return this;
        }

        private Expression AppendSpace(string text) => Append(text).AppendSpace();
        private Expression WrapSpace(string text) => AppendSpace().Append(text).AppendSpace();
        private Expression AffixSpace(string text) => AppendSpace().Append(text);
        private Expression AppendSpace() => Append(" ");

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

        internal static Expression Join(string separator, IEnumerable<Expression> expList)
        {
            return new Expression(string.Join(separator, expList));
        }

        internal static Expression OPR(Expression exp1, string opr, Expression exp2)
        {
            Expression exp = new Expression(string.Format("{0} {1} {2}", Expr2Str(exp1), opr, Expr2Str(exp2)))
            {
                compound = true
            };

            return exp;
        }

        // AND(A==1, B!=3, C>4) => "(A=1 AND B<>3 AND C>4)"
        internal static Expression OPR(string opr, IEnumerable<Expression> expList)
        {
            Expression exp = Join($" {opr} ", expList);
            exp.compound = true;
            return exp;
        }

        private static Expression OPR(string opr, Expression exp1)
        {
            return new Expression(string.Format("{0} {1}", opr, Expr2Str(exp1)));
        }


        public static Expression Assign(Expression name, object value) => OPR(name, "=", new Expression(new SqlValue(value)));
        public Expression Assign(object value) => Assign(this, value);
        public Expression Assign() => new Expression(this).WrapSpace("=");

        public Expression AS(VariableName name) => new Expression(this).WrapSpace("AS").Append(name);

        public Expression IN(SqlBuilder select) => new Expression(this).WrapSpace($"IN ({select.Query})");
        public Expression IN(params Expression[] collection) => new Expression(this).AffixSpace($"IN ({Join(", ", collection)})");
        public Expression IN<T>(IEnumerable<T> collection) => this.AffixSpace($"IN ({string.Join<T>(", ", collection)})");

        public Expression IS() => new Expression(this).AffixSpace("IS");
        public Expression IS_NULL() => new Expression(this).AffixSpace("IS NULL");
        public Expression IS_NOT_NULL() => new Expression(this).AffixSpace("IS NOT NULL");
        public Expression NULL() => new Expression(this).AffixSpace("NULL");

        public static Expression BETWEEN(Expression expr, Expression expr1, Expression expr2) => new Expression(expr).WrapSpace($"BETWEEN").Append(OPR(expr1, "AND", expr2));
        public Expression BETWEEN(Expression expr1, Expression expr2) => BETWEEN(this, expr1, expr2);

        public static Expression EXISTS(SqlBuilder condition) => new Expression($"EXISTS ({condition})");

        public Expression CASE(Expression _case)
        {
            var expr = new Expression(this)
                .AppendSpace("CASE")
                .Append(_case);

            return expr;
        }


        public Expression WHEN(Expression condition)
        {
            return new Expression(this).WrapSpace("WHEN").Append(condition);
        }

        public Expression THEN(Expression then)
        {
            return new Expression(this).WrapSpace("THEN").Append(then);
        }

        public Expression ELSE(Expression _else)
        {
            return new Expression(this).WrapSpace("ELSE").Append(_else).AppendSpace();
        }

        public Expression END()
        {
            return new Expression(this).Append("END");
        }

        public static Expression WHEN(Expression condition, Expression then)
        {
            return new Expression("WHEN").AppendSpace().Append(condition).WrapSpace("THEN").Append(then);
        }

        public static Expression CASE(Expression _case, Expression[] whens, Expression _else)
        {
            var expr = new Expression("CASE")
                .AppendSpace()
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

        #region implicit section

        public static implicit operator Expression(VariableName value)
        {
            return new Expression(value);    // s= 'string'
        }

        public static implicit operator Expression(string value)
        {
            return new Expression(new SqlValue(value));    // s= 'string'
        }

        public static implicit operator Expression(bool value)
        {
            return new Expression(new SqlValue(value));    // b=1 or b=0
        }


        public static implicit operator Expression(char value)
        {
            return new Expression(new SqlValue(value));     // ch= 'c'
        }

        public static implicit operator Expression(byte value)
        {
            return new Expression(new SqlValue(value));
        }

        public static implicit operator Expression(sbyte value)
        {
            return new Expression(new SqlValue(value));
        }


        public static implicit operator Expression(int value)
        {
            return new Expression(new SqlValue(value));
        }

        public static implicit operator Expression(short value)
        {
            return new Expression(new SqlValue(value));
        }

        public static implicit operator Expression(ushort value)
        {
            return new Expression(new SqlValue(value));
        }

        public static implicit operator Expression(uint value)
        {
            return new Expression(new SqlValue(value));
        }

        public static implicit operator Expression(long value)
        {
            return new Expression(new SqlValue(value));
        }

        public static implicit operator Expression(ulong value)
        {
            return new Expression(new SqlValue(value));
        }

        public static implicit operator Expression(double value)
        {
            return new Expression(new SqlValue(value));
        }

        public static implicit operator Expression(float value)
        {
            return new Expression(new SqlValue(value));
        }

        public static implicit operator Expression(decimal value)
        {
            return new Expression(new SqlValue(value));
        }

        public static implicit operator Expression(Guid value)
        {
            return new Expression(new SqlValue(value));
        }

        public static implicit operator Expression(DateTime value)
        {
            return new Expression(new SqlValue(value));   //dt = '10/20/2012'
        }

        public static implicit operator Expression(DBNull value)
        {
            return new Expression(new SqlValue(value));   // NULL
        }

        public static implicit operator Expression(Enum value)
        {
            return new Expression(new SqlValue(Convert.ToInt32(value)));
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



        #region +-*/, compare, logical operation


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
                Expression exp = new Expression(exp1).Append(" IS NULL");
                return exp;
            }

            return OPR(exp1, "=", exp2);
        }


        public static Expression operator !=(Expression exp1, Expression exp2)
        {
            if (exp2 is null || exp2.ToString() == "NULL")
            {
                Expression exp = new Expression(exp1).Append(" IS NOT NULL");
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

      
       

        public static Expression AND(params Expression[] expList) => OPR("AND", expList);
        public static Expression AND(Expression expr1, Expression expr2) => OPR(expr1, "AND", expr2);
        public Expression AND(Expression expr) => AND(this, expr);

        public static Expression OR(params Expression[] expList) => OPR("OR", expList);
        public static Expression OR(Expression expr1, Expression expr2) => OPR(expr1, "OR", expr2);
        public Expression OR(Expression expr) => OR(this, expr);

        public static Expression NOT(Expression expr) => OPR("NOT", expr);
        public Expression NOT() => NOT(this);


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

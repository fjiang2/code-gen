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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys.Data.Coding
{
    public sealed partial class Expression : IQueryScript
    {
        public static readonly Expression NULL = new Expression("NULL");
        public static readonly Expression STAR = new Expression("*");
        

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

        private static Expression Join(string separator, IEnumerable<Expression> expList)
        {
            return new Expression(string.Join(separator, expList));
        }

        private static Expression OPR(Expression exp1, string opr, Expression exp2)
        {
            Expression exp = new Expression(string.Format("{0} {1} {2}", Expr2Str(exp1), opr, Expr2Str(exp2)))
            {
                compound = true
            };

            return exp;
        }

        // AND(A==1, B!=3, C>4) => "(A=1 AND B<>3 AND C>4)"
        private static Expression OPR(string opr, IEnumerable<Expression> expList)
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

        public static Expression BETWEEN(Expression expr, Expression expr1, Expression expr2) => new Expression(expr).WrapSpace($"BETWEEN").Append(OPR(expr1, "AND", expr2));
        public Expression BETWEEN(Expression expr1, Expression expr2) => BETWEEN(this, expr1, expr2);

        public Expression IS() => new Expression(this).AffixSpace("IS");
        public Expression IS_NULL() => new Expression(this).AffixSpace("IS NULL");
        public Expression IS_NOT_NULL() => new Expression(this).AffixSpace("IS NOT NULL");


        public static Expression EXISTS(SqlBuilder condition) => new Expression($"EXISTS ({condition})");


        public static Expression LIKE(Expression expr, Expression pattern) => OPR(expr, "LIKE", pattern); 
        public Expression LIKE(Expression pattern) => LIKE(this, pattern);

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

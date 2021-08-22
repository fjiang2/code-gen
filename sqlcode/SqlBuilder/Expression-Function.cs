//                                                                                                  //
//--------------------------------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys.Data.Coding
{
    public sealed partial class Expression
    {
        public static readonly Expression GETDATE = Function("GETDATE");
        public static readonly Expression GETUTCDATE = Function("GETUTCDATE");
        public static readonly Expression SYSDATETIME = Function("SYSDATETIME");

        public static Expression Function(string func, params Expression[] expressions)
        {
            Expression exp = new Expression(func)
                .Append("(")
                .Append(string.Join<Expression>(",", expressions))
                .Append(")");

            return exp;
        }


        public static Expression CAST(Expression expr, Type type) => new Expression($"CAST({expr} AS {type.SqlType()})");
        public static Expression CAST<T>(Expression expr) => CAST(expr, typeof(T));
        public Expression CAST(Type type) => CAST(this, type);
        public Expression CAST<T>() => CAST(typeof(T));


        public static Expression CONVERT(Type type, Expression expr) => Function("CONVERT", type.SqlType(), expr);
        public static Expression CONVERT<T>(Expression expr) => CONVERT(typeof(T), expr);
        public Expression CONVERT(Type type) => CONVERT(type, this);
        public Expression CONVERT<T>() => CONVERT(typeof(T));


        public Expression DATEADD(DateInterval interval, Expression number) => Function("DATEADD", interval.DateIntervalType(), number, this);
        public Expression DATEDIFF(DateInterval interval, Expression date) => Function("DATEDIFF", interval.DateIntervalType(), this, date);
        public Expression DATEPART(DateInterval interval) => Function("DATEPART", interval.DateIntervalType(), this);
        public Expression DATENAME(DateInterval interval) => Function("DATENAME", interval.DateIntervalType(), this);


        public Expression LEN() => Function("LEN", this);
        public Expression DATALENGTH() => Function("DATALENGTH", this);
        public Expression SUBSTRING(Expression start, Expression length) => Function("SUBSTRING", this, start, length);
        public Expression STUFF(Expression start, Expression length, Expression new_string) => Function("STUFF", this, start, length, new_string);
        public Expression LOWER() => Function("LOWER", this);
        public Expression UPPER() => Function("UPPER", this);
        public Expression UNICODE() => Function("UNICODE", this);
        public Expression LEFT(Expression number) => Function("LEFT", this, number);
        public Expression RIGHT(Expression number) => Function("RIGHT", this, number);
        public Expression TRIM() => Function("TRIM", this);
        public Expression LTRIM() => Function("LTRIM", this);
        public Expression RTRIM() => Function("RTRIM", this);
        public Expression STR() => Function("STR", this);
        public Expression REPLACE(Expression old_string, Expression new_string) => Function("REPLACE", this, old_string, new_string);
        public Expression CONCAT(params Expression[] args)
        {
            var list = new List<Expression>();
            list.Add(this);
            list.AddRange(args);
            return Function("CONCAT", list.ToArray());
        }


        public Expression SUM() => Function("SUM", this);
        public Expression MAX() => Function("MAX", this);
        public Expression MIN() => Function("MIN", this);
        public Expression COUNT() => Function("COUNT", this);
    }
}
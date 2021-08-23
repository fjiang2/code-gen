using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Data;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sys.CodeBuilder;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest_CodeBuilder
    {
        [TestMethod]
        public void Test_ClassTypeInfo()
        {
            TypeInfo dict = TypeInfo.Generic<int, string>(new TypeInfo("Dictionary"));
            string code = dict.ToString();
            Debug.Assert(code == "Dictionary<int, string>");

            dict = new TypeInfo(typeof(Dictionary<int, string>));
            code = dict.ToString();
            Debug.Assert(code == "Dictionary<int, string>");
        }

        [TestMethod]
        public void Test_NewInstance()
        {
            Statement sent = new Statement();
            sent.Assign("x", new New(typeof(string[]), new Expression[] { new Value("a"), new Value("b"), new Value("c") }));
            string code = sent.ToString();
            Debug.Assert(code == "x = new string[] { \"a\", \"b\", \"c\" };");

            sent = new Statement();
            sent.Assign("x", new New(typeof(List<string>), new Expression[] { new Value("a"), new Value("b"), new Value("c") }));
            code = sent.ToString();
            Debug.Assert(code == "x = new List<string> { \"a\", \"b\", \"c\" };");

            sent = new Statement();
            sent.Assign("x", new New(typeof(List<string>), new Arguments()));
            code = sent.ToString();
            Debug.Assert(code == "x = new List<string>();");

            sent = new Statement();
            sent.Assign("x", new New(typeof(List<int>), new Arguments(new Argument(1), new Argument(2)), new Expression[] { 3, 4, 5 }));
            code = sent.ToString();
            Debug.Assert(code == "x = new List<int>(1, 2) { 3, 4, 5 };");

            sent = new Statement();
            var _string = new TypeInfo(typeof(string));
            var _args = new Arguments(new Argument("EmployeeID"), new Argument(_string));
            var _expr = new Expression[]
            {
               new Expression("Unique", true),
               new Expression("AllowDBNull", true),
               new Expression("MaxLength", 24),
            };
            sent.Assign("x", new New(typeof(DataColumn), _args, _expr));
            code = sent.ToString();
            Debug.Assert(code == "x = new DataColumn(EmployeeID, typeof(string)) { Unique = true, AllowDBNull = true, MaxLength = 24 };");

            sent = new Statement();
            sent.Assign("x", new New(typeof(DataColumn), _args).AddProperty("Unique", true).AddProperty("AllowDBNull", true).AddProperty("MaxLength", 24));
            code = sent.ToString();
            Debug.Assert(code == "x = new DataColumn(EmployeeID, typeof(string)) { Unique = true, AllowDBNull = true, MaxLength = 24 };");


            sent = new Statement();
            sent.Assign("x", new New(typeof(Dictionary<string, object>)).AddKeyValue(new Value("a"), 1).AddKeyValue(new Value("b"), 3));
            code = sent.ToString();
            Debug.Assert(code == "x = new Dictionary<string, object> { [\"a\"] = 1, [\"b\"] = 3 };");

        }

        [TestMethod]
        public void Test_ImplictOperator()
        {
            var _implict = Operator.Implicit(new TypeInfo(typeof(Expression)), new Parameter(new TypeInfo(typeof(int)), "value"));
            _implict.Body.Return("new Expression(value)");
            string code = _implict.ToString();
            Debug.Assert(code == @"public static implicit operator Expression(int value)
{
	return new Expression(value);
}");
        }

        [TestMethod]
        public void Test_ExplictOperator()
        {
            var _explict = Operator.Explicit(new TypeInfo(typeof(string)), new Parameter(new TypeInfo(typeof(Expression)), "expr"));
            _explict.Body.Return("expr.ToString()");
            string code = _explict.ToString();
            Debug.Assert(code == @"public static explicit operator string(Expression expr)
{
	return expr.ToString();
}");
        }


        [TestMethod]
        public void Test_Operator()
        {
            var _operator = new Operator(
                new TypeInfo(typeof(Expression)),
                Operation.GE,
                new Parameter(new TypeInfo(typeof(Expression)), "expr1"),
                new Parameter(new TypeInfo(typeof(Expression)), "expr2")
                );

            _operator.Body.Return("new Expression($\"{exp1} > {exp2}\")");
            string code = _operator.ToString();
            Debug.Assert(code == "public static Expression operator >=(Expression expr1, Expression expr2)\r\n{\r\n\treturn new Expression($\"{exp1} > {exp2}\");\r\n}");

            _operator = new Operator(
               new TypeInfo(typeof(Expression)),
               Operation.NOT,
               new Parameter(new TypeInfo(typeof(Expression)), "expr")
               );

            _operator.Body.Return("new Expression($\"!{expr}\")");
            code = _operator.ToString();
            Debug.Assert(code == "public static Expression operator !(Expression expr)\r\n{\r\n\treturn new Expression($\"!{expr}\");\r\n}");

        }

    }
}

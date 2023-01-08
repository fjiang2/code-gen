//--------------------------------------------------------------------------------------------------//
//                                                                                                  //
//        syscode(C# Code Builder)                                                                  //
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
using System.Threading.Tasks;

namespace Sys.CodeBuilder
{
    class CommonMethodGenerator : ICommonMethod
    {
        private const string SQM = "\\\"";
        private const string QM = "\"";
        private const string LC = "{";
        private const string RC = "}";

        private Class clss;
        private readonly string className;
        private readonly IEnumerable<PropertyInfo> variables;
        private readonly TypeInfo classType;

        public bool IsExtensionMethod { get; set; }

        public CommonMethodGenerator(Class clss, string className, IEnumerable<PropertyInfo> variables)
        {
            this.clss = clss;
            this.className = className;
            this.variables = variables;
            this.classType = new TypeInfo { UserType = className };

        }

        public void Map()
        {
            Assign("Map");
        }

        public void Copy()
        {
            Assign("Copy");
        }

        private void Assign(string methodName)
        {
            Method mtd = new Method(methodName)
            {
                Modifier = Modifier.Public,
            };
            mtd.Params.Add(className, "obj");

            var sent = mtd.Statement;
            foreach (var variable in variables)
            {
                sent.AppendFormat("this.{0} = obj.{0};", variable);
            }

            clss.Add(mtd);
        }


        public void StaticCopy()
        {
            Method mtd = new Method("Copy")
            {
                Modifier = Modifier.Public | Modifier.Static,
                IsExtensionMethod = IsExtensionMethod
            };

            mtd.Params.Add(className, "from");
            mtd.Params.Add(className, "to");

            var sent = mtd.Statement;
            foreach (var variable in variables)
            {
                sent.AppendFormat("to.{0} = from.{0};", variable);
            }

            clss.Add(mtd);
        }


        public void Clone()
        {
            Method mtd = new Method(classType, "Clone")
            {
                Modifier = Modifier.Public,
            };

            var sent = mtd.Statement;
            sent.AppendFormat("var obj = new {0}();", className);
            sent.AppendLine();

            foreach (var variable in variables)
            {
                sent.AppendFormat("obj.{0} = this.{0};", variable);
            }

            sent.AppendLine();
            sent.Return("obj");

            clss.Add(mtd);
        }

        public void StaticClone()
        {
            Method mtd = new Method(classType, "Clone")
            {
                Modifier = Modifier.Public | Modifier.Static,
                IsExtensionMethod = IsExtensionMethod
            };

            mtd.Params.Add(className, "from");
            var sent = mtd.Statement;

            sent.AppendFormat("var obj = new {0}();", className);
            sent.AppendLine();

            foreach (var variable in variables)
            {
                sent.AppendFormat("obj.{0} = from.{0};", variable);
            }

            sent.AppendLine();
            sent.Return("obj");

            clss.Add(mtd);
        }

        public void Equals()
        {
            Method mtd = new Method(new TypeInfo { Type = typeof(bool) }, "Equals")
            {
                Modifier = Modifier.Public | Modifier.Override,
            };

            mtd.Params.Add<object>("obj");

            var sent = mtd.Statement;
            sent.AppendFormat("var x = ({0})obj;", className);
            sent.AppendLine();

            sent.AppendLine("return ");

            variables.ForEach(
                variable => sent.Append($"this.{variable}.Equals(x.{variable})"),
                variable => sent.AppendLine("&& ")
                );

            sent.Append(";");

            clss.Add(mtd);
        }

        public void GetHashCode(string property)
        {
            Method mtd = new Method(new TypeInfo { Type = typeof(int) }, "GetHashCode")
            {
                Modifier = Modifier.Public | Modifier.Override,
            };

            var sent = mtd.Statement;
            sent.AppendLine($"return {property};");

            clss.Add(mtd);
        }

        public void Compare()
        {
            Method mtd = new Method(new TypeInfo { Type = typeof(bool) }, "Compare")
            {
                Modifier = Modifier.Public,
            };

            mtd.Params.Add(className, "obj");

            var sent = mtd.Statement;

            sent.AppendLine("return ");

            variables.ForEach(
                variable => sent.Append($"this.{variable}.Equals(obj.{variable})"),
                variable => sent.AppendLine("&& ")
                );

            sent.Append(";");

            clss.Add(mtd);
        }


        public void StaticCompare()
        {
            Method mtd = new Method(new TypeInfo { Type = typeof(bool) }, "Compare")
            {
                Modifier = Modifier.Public | Modifier.Static,
                IsExtensionMethod = IsExtensionMethod
            };

            mtd.Params.Add(className, "a");
            mtd.Params.Add(className, "b");

            var sent = mtd.Statement;

            sent.AppendLine("return ");

            variables.ForEach(
                variable => sent.Append($"a.{variable} == b.{variable}"),
                variable => sent.AppendLine("&& ")
                );

            sent.Append(";");

            clss.Add(mtd);
        }

        public void StaticToSimpleString()
        {
            Method mtd = new Method(new TypeInfo { Type = typeof(string) }, "ToSimpleString")
            {
                Modifier = Modifier.Public | Modifier.Static,
                IsExtensionMethod = IsExtensionMethod
            };

            mtd.Params.Add(className, "obj");

            var sent = mtd.Statement;
            StringBuilder builder = new StringBuilder("\"{{");
            int index = 0;
            variables.ForEach(
                variable => builder.Append($"{variable}:{{{index++}}}"),
                variable => builder.Append(", ")
                );

            builder.AppendLine("}}\", ");

            variables.ForEach(
                variable => builder.Append($"obj.{variable}"),
                variable => builder.AppendLine(", ")
                );

            sent.AppendFormat("return string.Format({0});", builder);

            clss.Add(mtd);
        }

        public void ToString(bool useFormat)
        {
            if (useFormat)
                ToString_v1();
            else
                ToString_v2();
        }

        private void ToString_v1()
        {
            Method mtd = new Method(new TypeInfo { Type = typeof(string) }, "ToString")
            {
                Modifier = Modifier.Public | Modifier.Override,
            };

            var sent = mtd.Statement;


            StringBuilder builder = new StringBuilder("\"{{");
            int index = 0;
            variables.ForEach(
                variable => builder.Append($"{variable}:{{{index++}}}"),
                variable => builder.Append(", ")
                );

            builder.AppendLine("}}\", ");

            variables.ForEach(
                variable => builder.Append($"this.{variable}"),
                variable => builder.AppendLine(", ")
                );

            sent.AppendFormat("return string.Format({0});", builder);

            clss.Add(mtd);
        }

        private void ToString_v2()
        {
            Method mtd = new Method(new TypeInfo { Type = typeof(string) }, "ToString")
            {
                Modifier = Modifier.Public | Modifier.Override,
            };

            var sent = mtd.Statement;
            sent.Append("return ");
            sent.Append("$\"");
            variables.ForEach(
                variable => sent.Append($"{variable}:{{{variable}}}"),
                variable => sent.Append(", ")
                );
            sent.Append("\";");

            clss.Add(mtd);
        }

        public void ToDictionary()
        {
            Method mtd = new Method("ToDictionary")
            {
                Modifier = Modifier.Public,
                Type = new TypeInfo { Type = typeof(IDictionary<string, object>) },
            };
            var sent = mtd.Statement;
            sent.AppendLine("return new Dictionary<string, object>() ");
            sent.Begin();

            foreach (var variable in variables)
            {
                var line = $"[\"{variable}\"] = this.{variable},";
                sent.AppendLine(line);
            }
            sent.End(";");

            clss.Add(mtd);
        }

        public void FromDictionary()
        {
            var type = new TypeInfo { Type = typeof(IDictionary<string, object>) };
            Method mtd = new Method("FromDictionary")
            {
                Modifier = Modifier.Public,
                Params = new Parameters(new Parameter[] { new Parameter(type, "dictionary") }),
            };

            var sent = mtd.Statement;
            foreach (var variable in variables)
            {
                TypeInfo typeInfo = variable.PropertyType;
                if (typeInfo.Type == typeof(System.Xml.Linq.XElement))
                    typeInfo.Type = typeof(string);

                var line = $"this.{variable} = ({typeInfo})dictionary[\"{variable.PropertyName}\"];";
                sent.AppendLine(line);
            }

            clss.Add(mtd);
        }

        public void ToJson(bool singleLine)
        {
            if (singleLine)
                ToJsonSingleLine();
            else
                ToMultipleJson();
        }
        

        private void ToJsonSingleLine()
        {
            Method mtd = new Method(new TypeInfo { Type = typeof(string) }, "ToJson")
            {
                Modifier = Modifier.Public,
            };

            var sent = mtd.Statement;
            sent.Append("return ");
            sent.Append("$\"{{");
            variables.ForEach(
                variable => sent.Append($"{SQM}{variable}{SQM}:{GetVariable(variable)}"),
                variable => sent.Append(", ")
                );
            sent.Append("}}\";");

            clss.Add(mtd);
        }

        private void ToMultipleJson()
        {
            Method mtd = new Method(new TypeInfo { Type = typeof(string) }, "ToJson")
            {
                Modifier = Modifier.Public,
            };

            var sent = mtd.Statement;
            sent.Append("return \"{\"");
            variables.ForEach(
                variable => sent.AppendLine($"+ $\"{SQM}{variable}{SQM}:{GetVariable(variable)}\""),
                variable => sent.AppendLine("+ \",\"")
                );
            sent.AppendLine("+ \"}\";");

            clss.Add(mtd);
        }

        private static string GetVariable(PropertyInfo variable)
        {
            var type = variable.PropertyType.Type;

            if (type == typeof(bool))
                return $"{LC}{variable}.ToString().ToLower(){RC}";

            //2012-04-23T18:25:43.511Z
            if (type == typeof(DateTime))
                return $"{SQM}{LC}{variable}.ToString({QM}yyyy-MM-ddTHH:mm:ss.fffZ{QM}){RC}{SQM}";

            if (type.IsPrimitive)
                return $"{LC}{variable}{RC}";
            else
                return $"{SQM}{LC}{variable}{RC}{SQM}";
        }
    }
}

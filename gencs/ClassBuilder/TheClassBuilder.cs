using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.IO;
using Sys;
using Sys.CodeBuilder;
using gencs.Models;

namespace gencs.ClassBuilder
{
    abstract class TheClassBuilder
    {
        protected CSharpBuilder builder;
        protected ClassInfo classInfo;

        public TheClassBuilder(ClassInfo classInfo)
        {
            this.classInfo = classInfo;
            builder = new CSharpBuilder();
        }

        protected abstract void CreateClass();

        protected string NamespaceName => classInfo.NameSpace;
        protected virtual string ClassName => classInfo.ClassName;
        protected string[] Usings => classInfo.Usings;


        public void AddOptionalUsing()
        {
            builder.AddUsingRange(classInfo.Usings);
        }

        public TypeInfo[] OptionalBaseType(params TypeInfo[] inherits)
        {
            List<TypeInfo> bases = new List<TypeInfo>(inherits);

            foreach (string item in classInfo.Bases)
            {
                string type = item.Replace("~", ClassName);
                bases.Add(new TypeInfo { UserType = type });
            }

            return bases.ToArray();
        }

        public void Output(string directory)
        {
            CreateClass();

            string cs = $"{classInfo.ClassName}.cs";
            string fileName = Path.Combine(directory, cs);
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            using (var writer = new StreamWriter(fileName))
            {
                string code = $"{builder}";
                writer.Write(code);
            }
        }

    }
}

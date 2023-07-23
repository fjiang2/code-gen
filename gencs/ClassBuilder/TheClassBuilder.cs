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
    internal abstract class TheClassBuilder
    {
        protected CSharpBuilder builder;
        protected ClassInfo classInfo;

        public TheClassBuilder(ClassInfo classInfo)
        {
            this.classInfo = classInfo;
            builder = new CSharpBuilder
            {
                Namespace = classInfo.NameSpace,
            };
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

        public string Output(string directory)
        {
            CreateClass();
            string fileName = builder.Output(directory, classInfo.ClassName);
            return fileName;
        }

        /// <summary>
        /// Get C# code
        /// </summary>
        /// <returns></returns>
        public string GetCode()
        {
            CreateClass();
            return builder.ToString();
        }
    }
}

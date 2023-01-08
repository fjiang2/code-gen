using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;

namespace Sys.CodeBuilder
{
    /// <summary>
    /// Create common methods from typeof(T)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PartialClass<T>
        : PartialClass
    {
        public PartialClass()
            : base(typeof(T))
        {
        }
    }


    /// <summary>
    /// Create common methods from Type
    /// </summary>
    public class PartialClass
    {
        private readonly Type type;
        private readonly PropertyInfo[] properties;
        private readonly Class clss;
        private readonly CSharpBuilder cs;

        public PartialClass(Type type)
        {
            this.type = type;
            this.clss = new Class(type.Name)
            {
                Modifier = Modifier.Partial | Modifier.Public
            };


            this.cs = new CSharpBuilder()
            {
                Namespace = type.Namespace,
            };

            cs.AddUsing("System");
            cs.AddClass(clss);

            this.properties = type.GetProperties()
                .Where(p => p.CanRead && p.CanWrite)
                .Select(p => new PropertyInfo(p.Name) { PropertyType = new TypeInfo(p.PropertyType) })
                .ToArray();
        }

        public Class Class => clss;
        public CSharpBuilder CSharp => cs;

        public ICommonMethod CommonMethod(bool isExtensionMethod = false)
        {
            cs.AddUsing("System.Collections.Generic");
            return clss.CommonMethod(clss.ClassName, properties, isExtensionMethod);
        }


        public void Output(string fileName)
        {
            string directory = Path.GetDirectoryName(fileName);
            cs.Output(directory, Path.GetFileName(fileName));
        }

        public override string ToString()
        {
            return clss.ToString();
        }
    }
}

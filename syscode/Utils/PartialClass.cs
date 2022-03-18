using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;

namespace Sys.CodeBuilder
{
    public class PartialClass
    {
        private readonly Type type;
        private readonly Class clss;
        private readonly PropertyInfo[] properties;

        public PartialClass(Type type)
        {
            this.type = type;
            this.clss = new Class(type.Name)
            {
                Modifier = Modifier.Partial | Modifier.Public
            };

            this.properties = type.GetProperties()
                .Select(p => new PropertyInfo(p.Name) { PropertyType = new TypeInfo(p.PropertyType) })
                .ToArray();
        }

        public void AddMethod(CommonMethodType methodType)
        {
            clss.AddMethod(properties, methodType);
        }


        public void Output(string fileName)
        {
            CSharpBuilder builder = new CSharpBuilder()
            {
                Namespace = type.Namespace,
            };

            builder.AddClass(clss);

            string directory = Path.GetDirectoryName(fileName);
            builder.Output(directory, fileName);
        }

        public override string ToString()
        {
            return clss.ToString();
        }
    }
}

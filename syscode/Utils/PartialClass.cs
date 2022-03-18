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
        private readonly PropertyInfo[] properties;
        private readonly Class clss;
        private readonly CSharpBuilder csbuilder;

        public PartialClass(Type type)
        {
            this.type = type;
            this.clss = new Class(type.Name)
            {
                Modifier = Modifier.Partial | Modifier.Public
            };


            this.csbuilder = new CSharpBuilder()
            {
                Namespace = type.Namespace,
            };

            csbuilder.AddUsing("System");
            csbuilder.AddClass(clss);

            this.properties = type.GetProperties()
                .Select(p => new PropertyInfo(p.Name) { PropertyType = new TypeInfo(p.PropertyType) })
                .ToArray();
        }

        public Class Class => clss;
        public CSharpBuilder CSharp => csbuilder;

        public void AddMethod(CommonMethodType methodType)
        {
            if (methodType == CommonMethodType.ThisFromDictionary || methodType == CommonMethodType.ThisToDictionary)
                csbuilder.AddUsing("System.Collections.Generic");

            clss.AddMethod(properties, methodType);
        }


        public void Output(string fileName)
        {
            string directory = Path.GetDirectoryName(fileName);
            csbuilder.Output(directory, fileName);
        }

        public override string ToString()
        {
            return clss.ToString();
        }
    }
}

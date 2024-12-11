using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using Sys.CodeBuilder;
using gencs.Models;
using System.Reflection.Emit;
using System.Xml.Linq;

namespace gencs.ClassBuilder
{
    public enum DtoType
    {
        /// <summary>
        /// Data contract
        /// </summary>
        DJ,

        /// <summary>
        /// NewtonSoft JSON
        /// </summary>
        NJ,

        /// <summary>
        /// System.Text.Json
        /// </summary>
        MJ,
    }

    class DtoClassBuilder : TheClassBuilder
    {
        private readonly IEnumerable<PropertyInfo> properties;
        private readonly DtoType dtoType;

        public DtoClassBuilder(ClassInfo classInfo, IEnumerable<PropertyInfo> properties, DtoType dtoType)
            : base(classInfo)
        {
            this.properties = properties;
            this.dtoType = dtoType;

            builder.AddUsing("System");
            switch (dtoType)
            {
                case DtoType.DJ:
                    builder.AddUsing("System.Runtime.Serialization");
                    break;

                case DtoType.NJ:
                    builder.AddUsing("Newtonsoft.Json");
                    break;

                case DtoType.MJ:
                    builder.AddUsing("System.Text.Json");
                    break;
            }

            AddOptionalUsing();
        }

        protected override void CreateClass()
        {
            TypeInfo[] _base = new TypeInfo[]
            {
            };

            _base = OptionalBaseType(_base);

            var clss = new Class(ClassName, _base)
            {
                Modifier = Modifier.Public | Modifier.Partial
            };
            clss.AddAttribute(new AttributeInfo("DataContract"));


            builder.AddClass(clss);

            foreach (var property in properties)
            {
                ForEachProperty(clss, property.PropertyType, property.PropertyName);
            }
        }

        private void ForEachProperty(Class clss, TypeInfo type, Identifier name)
        {
            string _name = name.ToString();
            Property property = new Property(type, name.ToString())
            {
                Modifier = Modifier.Public,
            };
            property.AddAttribute(new AttributeInfo("DataMember") { Args = new string[] { $"Name = \"{_name}\"", "EmitDefaultValue = false" } });

            clss.Add(property);
        }

    }
}

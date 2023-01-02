﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using Sys.CodeBuilder;
using gencs.Models;

namespace gencs.ClassBuilder
{

    class ViewModelClassBuilder : TheClassBuilder
    {

        IEnumerable<Models.PropertyInfo> fields;

        public ViewModelClassBuilder(ClassInfo classInfo, IEnumerable<Models.PropertyInfo> fields)
            : base(classInfo)
        {
            this.fields = fields;
            builder.AddUsing("System.ComponentModel");
            AddOptionalUsing();
            AddOptionalUsing();
        }

        protected override void CreateClass()
        {
            TypeInfo[] _base = new TypeInfo[]
            {
                new TypeInfo { UserType = $"INotifyPropertyChanged" }
            };

            _base = OptionalBaseType(_base);

            var clss = new Class(ClassName, _base)
            {
                Modifier = Modifier.Public | Modifier.Partial
            };
            builder.AddClass(clss);

            Constructor_Default(clss);


            foreach (var field in fields)
            {
                EachProperty(clss, field.Type, field.Name);
            }

            Method_OnPropertyChanged(clss);
        }

        private void Constructor_Default(Class clss)
        {
            Constructor constructor = new Constructor(clss.Name)
            {
                Modifier = Modifier.Public,
            };

            clss.Add(constructor);
        }

        private void Method_Create(Class clss)
        {
            Method constructor = new Method($"Create{clss.Name}")
            {
                Modifier = Modifier.Public | Modifier.Static,
                Params = new Parameters().Add(typeof(DataRow), "row")
            };

            clss.Add(constructor);
        }

        private void EachProperty(Class clss, TypeInfo type, string name)
        {
            Field field = new Field(type, $"_{name}")
            {
                Modifier = Modifier.Private,
            };
            clss.Add(field);


            Method mtdOnChanging = new Method($"On{name}Changing")
            {
                Modifier = Modifier.Partial,
                Params = new Parameters().Add(type, "value")
            };
            clss.Add(mtdOnChanging);

            Method mtdOnChanged = new Method($"On{name}Changed")
            {
                Modifier = Modifier.Partial,
            };
            clss.Add(mtdOnChanged);

            Property property = new Property(type, name)
            {
                Modifier = Modifier.Public,
            };
            clss.Add(property);

            property.Gets.Append($"return this._{name};");

            property.Sets.AppendLine($"this.On{name}Changing(value);");
            property.Sets.AppendLine($"this._{name} = value;");
            property.Sets.AppendLine($"this.On{name}Changed();");
            property.Sets.AppendLine($"this.OnPropertyChanged(nameof({name}));");

        }

        private void Method_OnPropertyChanged(Class clss)
        {
            Field field = new Field(new TypeInfo { UserType = "PropertyChangedEventHandler" }, "PropertyChanged")
            {
                Modifier = Modifier.Public | Modifier.Event
            };
            clss.Add(field);

            Method method = new Method("OnPropertyChanged")
            {
                Modifier = Modifier.Protected | Modifier.Virtual,
                Params = new Parameters().Add(typeof(string), "property")
            };
            clss.Add(method);
            var sent = method.Statement;
            sent.AppendLine("this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));");

        }

    }
}

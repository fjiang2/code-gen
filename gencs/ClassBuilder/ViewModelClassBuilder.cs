using gencs.Models;

using Sys.CodeBuilder;

namespace gencs.ClassBuilder
{

    class ViewModelClassBuilder : TheClassBuilder
    {
        IEnumerable<PropertyInfo> properties;

        public ViewModelClassBuilder(ClassInfo classInfo, IEnumerable<PropertyInfo> properties)
            : base(classInfo)
        {
            this.properties = properties;

            builder.AddUsing("System");
            builder.AddUsing("System.ComponentModel");
            AddOptionalUsing();
        }

        protected override void CreateClass()
        {
            TypeInfo[] _base = new TypeInfo[]
            {
                new TypeInfo { UserType = "INotifyPropertyChanged" }
            };

            _base = OptionalBaseType(_base);

            var clss = new Class(ClassName, _base)
            {
                Modifier = Modifier.Public | Modifier.Partial
            };
            builder.AddClass(clss);

            Constructor constructor = new Constructor(clss.Name)
            {
                Modifier = Modifier.Public,
            };
            clss.Add(constructor);

            foreach (var property in properties)
            {
                ForEachProperty(clss, property.PropertyType, property.PropertyName);
            }

            Method_OnPropertyChanged(clss);
        }

        private void ForEachProperty(Class clss, TypeInfo type, Identifier name)
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

            Property property = new Property(type, name.ToString())
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

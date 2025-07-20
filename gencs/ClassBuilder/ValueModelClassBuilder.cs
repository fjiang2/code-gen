using System.Collections;

using gencs.Models;

using Sys.CodeBuilder;

namespace gencs.ClassBuilder
{
    class ValueModelClassBuilder : TheClassBuilder
    {
        private object entity;

        public string FieldName { get; set; } = "obj";

        public ValueModelClassBuilder(ClassInfo classInfo, object entity)
            : base(classInfo)
        {
            builder.AddUsing("System");
            AddOptionalUsing();
            this.entity = entity;
        }

        protected override void CreateClass()
        {
            var clss = new Class(ClassName)
            {
                Modifier = Modifier.Public | Modifier.Partial
            };
            builder.AddClass(clss);

            CreateField(clss);
        }

        public Value CreateField()
        {
            return WriteCodeValue(entity);
        }

        private void CreateField(Class clss)
        {
            Value value = WriteCodeValue(entity);

            Field field = new Field(new TypeInfo(entity.GetType()), FieldName, value)
            {
                Modifier = Modifier.Public,
            };

            clss.Add(field);
        }

        private Value WriteCodeValue(object entity)
        {
            Type type = entity.GetType();
            builder.AddUsing(type.Namespace);

            if (type.IsValueType || type.IsPrimitive || type.IsEnum || entity is string)
            {
                return new Value(entity);
            }

            if (entity is IDictionary)
            {

            }

            if (entity is IEnumerable)
            {
                List<object> list = new List<object>();
                foreach (var item in (IEnumerable)entity)
                {
                    list.Add(WriteCodeValue(item!));
                }

                return new Value(list.ToArray())
                {
                    Type = new TypeInfo(type),
                    ArrayColumnNumber = 1,
                };
            }

            New newObject = new New(new TypeInfo(type))
            {
                Format = ValueOutputFormat.MultipleLine,
            };
            foreach (var propertyInfo in type.GetProperties())
            {
                object? value = propertyInfo.GetValue(entity);
                newObject.AddProperty(propertyInfo.Name, WriteCodeValue(value!));
            }

            return new Value(newObject);
        }
    }
}

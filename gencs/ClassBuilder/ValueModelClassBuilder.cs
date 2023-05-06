using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sys.CodeBuilder;
using gencs.Models;

namespace gencs.ClassBuilder
{
    class ValueModelClassBuilder : TheClassBuilder
    {
        private object node;

        public ValueModelClassBuilder(ClassInfo classInfo, object node)
            : base(classInfo)
        {
            //builder.AddUsing("System.Text.Json.Nodes");
            AddOptionalUsing();
            this.node = node;
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
            return WriteCodeValue(node, "");
        }

        private void CreateField(Class clss)
        {
            Value value = WriteCodeValue(node, "");

            Field field = new Field(new TypeInfo(node.GetType()), "obj", value)
            {
                Modifier = Modifier.Public,
            };

            clss.Add(field);
        }

        private Value WriteCodeValue(object node, string propertyName)
        {
            Type type = node.GetType();

            if (node is string stringValue)
            {
                return new Value(stringValue);
            }

            if (type.IsEnum)
            {
                return new Value(new CodeString($"{type.Name}.{node}"));
            }

            if (type.IsPrimitive)
            {
                return new Value(node);
            }

            if (type.IsArray)
            {
                List<object> list = new List<object>();
                foreach (var item in (Array)node)
                {
                    list.Add(WriteCodeValue(item!, propertyName));
                }
                return new Value(list.ToArray())
                {
                    Type = new TypeInfo(type),
                    ArrayColumnNumber = 1,
                };
            }

            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>))
            {
                New newObject = new New(new TypeInfo(type));
                builder.AddUsing(type.Namespace);

                List<object> list = new List<object>();
                foreach (var item in (IList)node)
                {
                    list.Add(WriteCodeValue(item!, propertyName));
                }
                return new Value(list.ToArray())
                {
                    Type = new TypeInfo(type),
                    ArrayColumnNumber = 1,
                };
            }
            else
            {
                New newObject = new New(new TypeInfo(type))
                {
                    Format = ValueOutputFormat.MultipleLine,
                };
                builder.AddUsing(type.Namespace);

                Dictionary<object, object> dict = new Dictionary<object, object>();
                foreach (var propertyInfo in type.GetProperties())
                {
                    object? value = propertyInfo.GetValue(node);
                    newObject.AddProperty(propertyInfo.Name, WriteCodeValue(value!, propertyInfo.Name));
                }

                return new Value(newObject);
            }
        }

    }
}

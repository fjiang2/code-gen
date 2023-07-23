using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using Sys.CodeBuilder;
using gencs.Models;
using System.Text.Json.Nodes;
using System.Xml.Linq;

namespace gencs.ClassBuilder
{
    class JsonNodeClassBuilder : TheClassBuilder
    {
        private JsonNode node;
        public string FieldName { get; set; } = "jsonNode";

        public JsonNodeClassBuilder(ClassInfo classInfo, string json)
            : base(classInfo)
        {
            builder.AddUsing("System.Text.Json.Nodes");
            AddOptionalUsing();

            this.node = JsonNode.Parse(json)!;
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

            Field field = new Field(new TypeInfo(typeof(JsonNode)), FieldName, value)
            {
                Modifier = Modifier.Public,
            };

            clss.Add(field);
        }

        private static Value WriteCodeValue(JsonNode node, string propertyName)
        {
            if (node is JsonObject jsonObject)
            {
                Dictionary<object, object> dict = new Dictionary<object, object>();
                foreach (var field in jsonObject)
                {
                    dict.Add(field.Key, WriteCodeValue(field.Value!, field.Key));
                }
                return new Value(dict) { Type = new TypeInfo(typeof(JsonObject)) };
            }

            if (node is JsonArray jsonArray)
            {
                List<object> list = new List<object>();
                foreach (var item in jsonArray)
                {
                    list.Add(WriteCodeValue(item!, propertyName));
                }
                return new Value(list.ToArray())
                {
                    Type = new TypeInfo(typeof(JsonArray)),
                    ArrayColumnNumber = 1,
                };
            }

            if (node is JsonValue jsonValue)
            {
                if (jsonValue.TryGetValue<string>(out var stringValue))
                {
                    return new Value(stringValue);
                }
                else
                {
                    return new Value(new CodeString(jsonValue.ToString()));
                }
            }

            throw new NotSupportedException();
        }

    }
}

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

        public JsonNodeClassBuilder(ClassInfo classInfo, string file)
            : base(classInfo)
        {
            builder.AddUsing("System.Text.Json.Nodes");
            AddOptionalUsing();

            string json = File.ReadAllText(file);
            this.node = JsonNode.Parse(json)!;
        }

        protected override void CreateClass()
        {
            var clss = new Class(ClassName)
            {
                Modifier = Modifier.Public | Modifier.Partial
            };
            builder.AddClass(clss);

            using (MemoryStream memoryStream = new MemoryStream(capacity: 1024 * 1024))
            using (var writer = new StreamWriter(memoryStream))
            {
                WriteCode(writer, 0, node, "");
                string code = Encoding.UTF8.GetString(memoryStream.ToArray());

                Field field = new Field(new TypeInfo("JsonNode"), $"jsonNode", new Value(new CodeString(code)))
                {
                    Modifier = Modifier.Public,
                };

                clss.Add(field);
            }
        }

        private static void WriteLine(TextWriter writer, int tab, string text)
        {
            Write(writer, tab, text);
            writer.WriteLine();
        }

        private static void Write(TextWriter writer, int tab, string text)
        {
            for (int t = 0; t < tab; t++)
            {
                writer.Write("\t");
            }
            writer.Write(text);
        }

        private static void WriteCode(TextWriter writer, int tab, JsonNode node, string propertyName)
        {
            if (node is JsonObject jsonObject)
            {
                WriteLine(writer, tab, "new JsonObject");
                WriteLine(writer, tab, "{");
                tab++;
                foreach (var field in jsonObject)
                {
                    Write(writer, tab, $"[\"{field.Key}\"] = ");
                    WriteCode(writer, tab, field.Value!, field.Key);
                    writer.WriteLine(",");
                }
                tab--;
                Write(writer, tab, "}");
                return;
            }

            if (node is JsonArray jsonArray)
            {
                writer.WriteLine("new JsonArray");
                WriteLine(writer, tab, "{");
                tab++;
                foreach (var item in jsonArray)
                {
                    WriteCode(writer, tab, item!, propertyName);
                    writer.WriteLine(",");
                }
                tab--;
                Write(writer, tab, "}");
                return;
            }

            if (node is JsonValue jsonValue)
            {
                if (jsonValue.TryGetValue<string>(out var stringValue))
                {
                    writer.Write($"\"{stringValue}\"");
                }
                else
                {
                    writer.Write($"{jsonValue}");
                }
                return;
            }

            throw new NotSupportedException();
        }
    }
}

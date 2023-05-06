using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace UnitTestProject
{
    public static class Json
    {
        public static string Prettify(this string json)
        {
            using (JsonDocument doc = JsonDocument.Parse(json))
            {
                return JsonSerializer.Serialize(doc, new JsonSerializerOptions { WriteIndented = true });
            }
        }

        public static string Serialize(object value)
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true,
                AllowTrailingCommas = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
                //ReadCommentHandling = JsonCommentHandling.Allow,
            };
            options.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));

            return JsonSerializer.Serialize(value, options);
        }

        public static T Deserialize<T>(string json)
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                AllowTrailingCommas = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
                //ReadCommentHandling = JsonCommentHandling.Allow,
            };
            options.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));

            var obj = JsonSerializer.Deserialize<T>(json, options);
            return obj;
        }


        public static T Deserialize<T>(JsonNode jsonNode)
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                AllowTrailingCommas = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
                //ReadCommentHandling = JsonCommentHandling.Allow,
            };
            options.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));

            var obj = JsonSerializer.Deserialize<T>(jsonNode.ToJsonString(), options);
            return obj;
        }
    }
}

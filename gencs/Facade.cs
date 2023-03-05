using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gencs.ClassBuilder;
using gencs.Models;
using Sys.CodeBuilder;

namespace gencs
{
    /// <summary>
    /// Call (gencs.dll)
    /// </summary>
    public class Facade
    {
        /// <summary>
        /// Create JsonNode data code from json string
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static string CreateJsonNode(string json)
        {
            ClassInfo classInfo = new ClassInfo();
            var cs = new JsonNodeClassBuilder(classInfo, json);
            Value value = cs.CreateField();
            return value.ToString();
        }

        public static string CreateViewModel(ClassInfo classInfo, IEnumerable<string> properties)
        {
            var fields=  Shell.CreateFields(properties);
            var cs = new ViewModelClassBuilder(classInfo, fields);
            return cs.GetCode();
        }
    }
}

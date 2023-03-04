using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gencs.ClassBuilder;
using gencs.Models;

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
            return JsonNodeClassBuilder.CreateJsonCode(json);
        }

        public static string CreateViewModel(ClassInfo classInfo, IEnumerable<string> properties)
        {
            var fields=  Shell.CreateFields(properties);
            var cs = new ViewModelClassBuilder(classInfo, fields);
            return cs.GetCode();
        }
    }
}

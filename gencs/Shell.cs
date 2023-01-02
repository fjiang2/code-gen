using System;
using System.Collections.Generic;
using System.CommandLine;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sys.CodeBuilder;
using gencs.ClassBuilder;
using gencs.Models;

namespace gencs
{
    internal class Shell
    {
        public Task GenerateViewModel(ClassInfo classInfo, IEnumerable<string> properties, string output)
        {
            if (properties.Count() == 0)
            {
                Console.WriteLine($"Properties are not defined.");
                return Task.CompletedTask;
            }

            try
            {
                List<PropertyInfo> _fields = CreateFields(properties);

                var cs = new ViewModelClassBuilder(classInfo, _fields);
                string fileName = cs.Output(output);
                Console.WriteLine($"Code generated: \"{fileName}\"");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return Task.CompletedTask;
        }


        private static List<PropertyInfo> CreateFields(IEnumerable<string> properties)
        {
            List<PropertyInfo> _properties = new List<PropertyInfo>();
            foreach (string property in properties)
            {
                string[] items = property.Split('+');
                if (items.Length != 2)
                {
                    throw new ArgumentException($"Invalid property: {property}");
                }

                _properties.Add(new PropertyInfo
                {
                    PropertyType = new TypeInfo(items[0]),
                    PropertyName = items[1],
                });
            }

            return _properties;
        }
    }
}

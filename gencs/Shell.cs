using gencs.ClassBuilder;
using gencs.ClassBuilder.Mvvm;
using gencs.Models;

using Sys.CodeBuilder;

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


        internal static List<PropertyInfo> CreateFields(IEnumerable<string> properties)
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


        public Task GenerateJsonNode(ClassInfo classInfo, string file, string output)
        {
            if (!File.Exists(file))
            {
                Console.WriteLine($"Json files are not found.");
                return Task.CompletedTask;
            }

            try
            {
                string json = File.ReadAllText(file);
                var cs = new JsonNodeClassBuilder(classInfo, json);
                string fileName = cs.Output(output);
                Console.WriteLine($"Code generated: \"{fileName}\"");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return Task.CompletedTask;
        }

        public Task GenerateDtoClass(ClassInfo classInfo, IEnumerable<string> properties, string dtoType, string output)
        {
            if (properties.Count() == 0)
            {
                Console.WriteLine($"Properties are not defined.");
                return Task.CompletedTask;
            }

            try
            {
                List<PropertyInfo> _fields = CreateFields(properties);
                if (Enum.TryParse<DtoType>(dtoType, ignoreCase: true, out var _dtoType))
                {
                    var cs = new DtoClassBuilder(classInfo, _fields, _dtoType);
                    string fileName = cs.Output(output);
                    Console.WriteLine($"Code generated: \"{fileName}\"");
                }
                else
                {
                    Console.Error.WriteLine($"Invalid dto type: \"{dtoType}\"");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return Task.CompletedTask;
        }

        public Task GenerateMvvmTemplate(ClassInfo classInfo, string modelName, string viewName, string output)
        {
            try
            {
                string project = output;
                var name = new MvvmName(modelName, viewName);
                MvvmClassBuilder gen = new MvvmClassBuilder(classInfo, project);
                gen.Generate(name);

                Console.WriteLine("OK");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return Task.CompletedTask;
        }
    }
}

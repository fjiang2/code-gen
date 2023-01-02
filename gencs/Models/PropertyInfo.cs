using Sys.CodeBuilder;

namespace gencs.Models
{
    class PropertyInfo
    {
        public TypeInfo Type { get; set; } = typeof(string);
        public string Name { get; set; } = string.Empty;
    }
}

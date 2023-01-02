using Sys.CodeBuilder;

namespace gencs.Models
{
    class FieldInfo
    {
        public TypeInfo Type { get; set; } = typeof(string);
        public string Name { get; set; } = string.Empty;
    }
}

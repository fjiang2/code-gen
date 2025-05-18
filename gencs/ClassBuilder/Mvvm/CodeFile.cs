namespace gencs.ClassBuilder.Mvvm
{
    public class CodeFile
    {
        private readonly CodePath path;
        private readonly MvvmType type;

        private readonly string directory;
        private readonly string name;

        private string ClassName;
        private string TemplateClass;

        public CodeFile(CodePath path, MvvmType type, string name)
        {
            this.path = path;
            this.type = type;

            directory = path.GetDirectory(type);
            this.name = name;

            ClassName = $"{name}{type}";
            TemplateClass = $"Template{type}";
        }

        public string ReadCode() => Read($"{TemplateClass}.cs");
        public void WriteCode(string code) => Write($"{ClassName}.cs", code);

        public string ReadXaml() => Read($"{TemplateClass}.xaml");
        public void WriteXaml(string code) => Write($"{ClassName}.xaml", code);

        public string ReadXamlCode() => Read($"{TemplateClass}.xaml.cs");
        public void WriteXamlCode(string code) => Write($"{ClassName}.xaml.cs", code);

        private string Read(string fileName)
        {
            string? path = System.Reflection.Assembly.GetEntryAssembly()?.Location;
            string directory = Path.Combine(Path.GetDirectoryName(path) ?? ".", "templates");
            string fullPath = Path.Combine(directory, fileName + ".txt");
            return File.ReadAllText(fullPath);
        }

        private void Write(string fileName, string code)
        {
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            string fullPath = Path.Combine(directory, fileName);
            File.WriteAllText(fullPath, code);
            Console.WriteLine($"Generated {fullPath}");
        }

        public string ReplaceModel(string code)
        {
            code = code.Replace(TemplateClass, ClassName);
            return code;
        }

        public string ReplaceViewModel(string code, string modelName)
        {
            code = code.Replace(TemplateClass, ClassName);
            code = code.Replace($"TemplateView", $"{name}View");
            code = code.Replace($"TemplateModel", $"{modelName}Model");
            return code;
        }

        public string ReplaceXamlCode(string code, string modelName)
        {
            code = code.Replace($"TemplateViewModel", $"{name}ViewModel");
            code = code.Replace(TemplateClass, ClassName);
            code = code.Replace($"template", $"{modelName}");
            return code;
        }

        public string ReplaceXaml(string xaml)
        {
            xaml = xaml.Replace(TemplateClass, ClassName);
            return xaml;
        }
    }
}

using gencs.Models;

namespace gencs.ClassBuilder.Mvvm
{
    class MvvmClassBuilder
    {
        private readonly ClassInfo classInfo;
        private readonly CodePath path;

        private readonly string nameSpace;
        public MvvmClassBuilder(ClassInfo classInfo, string projectDirectory)
        {
            this.classInfo = classInfo;
            this.path = new CodePath(projectDirectory);

            this.nameSpace = classInfo.NameSpace;
            if (this.nameSpace == "Gencs")
            {
                this.nameSpace = Path.GetFileName(projectDirectory);
            }
        }

        public void Generate(MvvmName name)
        {
            string viewName = name.ViewName;
            string modelName = name.ModelName;
            GenerateModel(modelName);
            GenerateViewModel(viewName, modelName);
            GenerateView(viewName, modelName);
        }

        private string Update(string code)
        {
            code = code.Replace("$NS", $"{classInfo.NameSpace}");
            return code;
        }

        private string UpdateXaml(string xaml)
        {
            xaml = xaml.Replace("$NS", $"{classInfo.NameSpace}");
            return xaml;
        }

        public void GenerateModel(string name)
        {
            CodeFile file = new CodeFile(path, MvvmType.Model, name);
            string code = file.ReadCode();
            code = Update(code);
            code = file.ReplaceModel(code);
            file.WriteCode(code);
        }

        public void GenerateViewModel(string viewName, string modelName)
        {
            CodeFile file = new CodeFile(path, MvvmType.ViewModel, viewName);
            string code = file.ReadCode();
            code = Update(code);
            code = file.ReplaceViewModel(code, modelName);
            file.WriteCode(code);
        }

        public void GenerateView(string name, string modelName)
        {
            CodeFile file = new CodeFile(path, MvvmType.View, name);
            string code = file.ReadXamlCode();
            string xaml = file.ReadXaml();

            code = Update(code);
            code = file.ReplaceXamlCode(code, modelName);

            xaml = UpdateXaml(xaml);
            xaml = file.ReplaceXaml(xaml);

            file.WriteXamlCode(code);
            file.WriteXaml(xaml);
        }
    }
}

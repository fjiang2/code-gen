namespace gencs.ClassBuilder.Mvvm
{
    public class CodePath
    {
        private readonly string project;

        public CodePath(string project)
        {
            this.project = project;
        }

        public string GetDirectory(MvvmType type)
        {
            switch (type)
            {
                case MvvmType.Model:
                    return Path.Combine(project, "Models");

                case MvvmType.ViewModel:
                    return Path.Combine(project, "ViewModels");

                case MvvmType.View:
                    return Path.Combine(project, "Views");
            }

            throw new NotImplementedException();
        }
    }
}

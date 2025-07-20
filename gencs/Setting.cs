using Microsoft.Extensions.Configuration;

namespace gencs
{
    internal class Setting
    {
        public string NameSpace { get; }
        public string ClassName { get; }
        public string[] Usings { get; }
        public string[] Bases { get; }
        public string[] Fields { get; }
        public string Output { get; }

        /// <summary>
        ///  dj:DataContract-Json, nj:NewtonSoft-Json, mj:Microsoft-Json
        /// </summary>
        public string DtoType { get; }

        public string ModelPrefix { get; }
        public string ViewPrefix { get; }

        public Setting(IConfiguration configuration)
        {
            this.NameSpace = Environment.GetEnvironmentVariable("GENCS_NAMESPACE") ?? "Gencs";
            this.ClassName = Environment.GetEnvironmentVariable("GENCS_CLASS_NAME") ?? "Class1";

            this.Usings = new string[]
            {
                "System",
            };

            this.Bases = new string[] { };
            this.Fields = new string[]
            {
                "string+Name",
                "int?+Age",
            };

            this.Output = Environment.GetEnvironmentVariable("GENCS_OUTPUT") ?? Directory.GetCurrentDirectory();

            this.DtoType = "dj";

            this.ModelPrefix = "Mvvm";
            this.ViewPrefix = "Mvvm";

        }
    }
}

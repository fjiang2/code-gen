using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public Setting(IConfiguration configuration)
        {
            this.NameSpace = Environment.GetEnvironmentVariable("GENCS_NAMESPACE") ?? "gencs.models";
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
        }
    }
}

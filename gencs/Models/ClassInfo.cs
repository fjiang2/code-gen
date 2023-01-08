using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gencs.Models
{
    public class ClassInfo
    {
        public string[] Usings { get; set; } = new string[0];
        public string NameSpace { get; set; } = string.Empty;
        public string ClassName { get; set; } = string.Empty;
        public string[] Bases { get; set; } = new string[0];
    }
}

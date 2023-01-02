using System;
using System.Collections.Generic;
using System.CommandLine;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gencs.ClassBuilder;
using gencs.Models;

namespace gencs
{
    internal class Shell
    {
        public Task GenerateViewModel(ClassInfo classInfo, IEnumerable<string> fields, string output)
        {
            List<FieldInfo> _fields = new List<FieldInfo>();
            foreach(string field in fields)
            {
                string[] items = field.Split('+');
                _fields.Add(new FieldInfo
                {
                    Type = new Sys.CodeBuilder.TypeInfo(items[0]),
                    Name = items[1],
                });
            }
            
            var cs = new ViewModelClassBuilder(classInfo, _fields);
            cs.Output(output);
            return Task.CompletedTask;
        }
    }
}

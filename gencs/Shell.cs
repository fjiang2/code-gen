using System;
using System.Collections.Generic;
using System.CommandLine;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gencs
{
    internal class Shell
    {
        public Task GenerateViewModel(IEnumerable<string> usings, string nameSpace, string className, IEnumerable<string> bases, IEnumerable<string> fields, string output)
        {
            return Task.CompletedTask;
        }
    }
}

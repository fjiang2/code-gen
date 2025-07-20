using System.Collections.Generic;
using System.Linq;

namespace Sys.CodeBuilder
{
    public class Usings : Buildable
    {
        private readonly List<string> usings = new List<string>();
        private readonly Option option;

        public Usings(Option option)
        {
            this.option = option;
        }

        public void AddUsing(string name)
        {
            if (usings.IndexOf(name) < 0)
                this.usings.Add(name);
        }

        private static string[] SortUsings(IEnumerable<string> usings, Option option)
        {
            List<string> _usings = new List<string>();

            var sorted = usings
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Distinct()
                .OrderBy(x => x);

            var groups = sorted.GroupBy(x => x.Split('.')[0]);

            if (option.UsingSystemFirst)
            {
                foreach (var group in groups)
                {
                    if (group.Key == nameof(System))
                    {
                        _usings.InsertRange(0, group.ToList());
                    }
                    else
                    {
                        if (option.SeparateUsingGroups)
                            _usings.Add(string.Empty);

                        _usings.AddRange(group.ToList());
                    }
                }

                // if there is no using System.xxxx;
                if (_usings.Any() && _usings[0] == string.Empty)
                {
                    _usings.RemoveAt(0);
                }
            }
            else
            {
                foreach (var group in groups)
                {
                    _usings.AddRange(group.ToList());

                    if (option.SeparateUsingGroups)
                        _usings.Add(string.Empty);
                }

                if (_usings.Any() && _usings.Last() == string.Empty)
                {
                    _usings.RemoveAt(_usings.Count - 1);
                }
            }

            return _usings.ToArray();
        }


        protected override void BuildBlock(CodeBlock block)
        {
            var _usings = SortUsings(usings, option);

            foreach (var name in _usings)
            {
                if (string.IsNullOrEmpty(name))
                {
                    block.AppendLine();
                }
                else
                {
                    block.AppendFormat("using {0};", name);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Data.Coding
{
    public class ColumnName
    {
        private readonly string parent;
        private readonly string name;

        public ColumnName(string name)
        {
            this.name = name;
        }

        public ColumnName(string parent, string name)
        {
            this.parent = parent;
            this.name = name;
        }

        public override string ToString()
        {
            StringBuilder text = new StringBuilder();
            if (parent != null)
                text.Append(parent).Append(".");

            if (name == "*" || string.IsNullOrEmpty(name))
                text.Append("*");
            else
                text.Append($"[{name}]");

            return text.ToString();
        }
    }
}

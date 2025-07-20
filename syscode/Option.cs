using System;

namespace Sys.CodeBuilder
{
    public class Option
    {
        public int TabSize { get; set; } = 4;

        public int IndentSize { get; set; } = 4;

        public TabType TabType { get; set; } = TabType.KeepTabs;

        internal string Tab(int n)
        {
            if (n <= 0)
                return string.Empty;

            if (TabType == TabType.InsertSpaces)
                return new string(' ', TabSize * n);
            else
                return new string('\t', n);
        }

        internal string Indent(int n)
        {
            if (n <= 0)
                return string.Empty;

            if (TabType == TabType.InsertSpaces)
                return new string(' ', IndentSize * n);
            else
                return new string('\t', n);
        }
    }

    public enum TabType
    {
        KeepTabs,
        InsertSpaces
    }
}

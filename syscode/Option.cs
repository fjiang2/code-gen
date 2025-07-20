namespace Sys.CodeBuilder
{
    public class Option
    {
        public int TabSize { get; set; } = 4;

        public int IndentSize { get; set; } = 4;

        public TabType TabType { get; set; } = TabType.KeepTabs;

        /// <summary>
        /// Place 'System' directive first when sorting lazyUsings
        /// </summary>
        public bool UsingSystemFirst { get; set; } = true;

        /// <summary>
        /// Separate lazyUsings directive groups
        /// </summary>
        public bool SeparateUsingGroups { get; set; } = true;

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

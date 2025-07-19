using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.CodeBuilder
{
    public class Option
    {
        public int TabSize { get; set; } = 4;

        public int IndentSize { get; set; } = 4;

        public TabType TabType { get; set; } = TabType.KeepTabs;

    }

    public enum TabType
    {
        KeepTabs,
        InsertSpaces
    }
}

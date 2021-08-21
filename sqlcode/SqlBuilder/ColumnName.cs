using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Data.Coding
{
	public class ColumnName
	{
		private readonly string name;

		public ColumnName(string name)
		{
			this.name = name;
		}

		public override string ToString()
		{
			return $"[{name}]";
		}
	}
}

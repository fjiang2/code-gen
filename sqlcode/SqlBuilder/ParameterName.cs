using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Data.Coding
{
	public class ParameterName
	{
		private readonly string name;

		public ParameterName(string name)
		{
			this.name = name;
		}

		public override string ToString()
		{
			return "@" + name;
		}
	}
}

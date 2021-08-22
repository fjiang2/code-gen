using System;

namespace Sys.Data.Coding
{
    public class Parameter
    {
		public ParameterName Name { get; set; }
		public Type ParameterType { get; set; }

		public override string ToString()
		{
			return $"{Name} {ParameterType.ToSqlType()}";
		}
	}
}

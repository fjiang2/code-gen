using System;

namespace UnitTestProject
{
	[System.AttributeUsage(System.AttributeTargets.Property)]
	public class ColumnAttribute : Attribute
	{
		private string columnName;

		public Type Type { get; set; }
		public object DefaultValue { get; set; }
		public bool Primary { get; set; } = false;
		public bool Identity { get; set; } = false;
		public bool Computed { get; set; } = false;
		public short Length { get; set; } = 0;
		public bool Nullable { get; set; } = false;
		public byte Precision { get; set; } = 0;
		public byte Scale { get; set; } = 0;
		public string Caption { get; set; }

		public ColumnAttribute(string columnName)
		{
			this.columnName = columnName;
		}
	}
}
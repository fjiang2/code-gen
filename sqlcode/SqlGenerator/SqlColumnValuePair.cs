﻿namespace Sys.Data.Coding
{
    public class SqlColumnValuePair
    {
        public SqlColumn Field { get; }
        public SqlValue Value { get; set; }


        public SqlColumnValuePair(string columnName, object value)
        {
            this.Field = new SqlColumn(columnName, value?.GetType());
            this.Value = new SqlValue(value);
        }

        public string ColumnName => Field.Name;

        public string ColumnFormalName => FormalName(ColumnName);

        public override string ToString()
        {
            return string.Format("[{0}] = {1}", ColumnName, Value);
        }

        internal static string FormalName(string name)
        {
            if (name.StartsWith("[") && name.EndsWith("]"))
                return name;

            return $"[{name}]";
        }

    }
}

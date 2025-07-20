using System;

namespace UnitTestProject
{
    [System.AttributeUsage(System.AttributeTargets.Class)]
    public class TableAttribute : Attribute
    {
        private readonly string tableName;
        public int TableId { get; set; }
        public TableAttribute(string tableName)
        {
            this.tableName = tableName;
        }
    }
}
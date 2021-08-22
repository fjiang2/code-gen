using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Data.Coding
{
	public class Statement 
	{
		private readonly List<string> lines = new List<string>();
		protected bool compound = false;

		public Statement()
		{
		}

		private Statement AppendLine(string line)
		{
			lines.Add(line);
			return this;
		}

		public Statement Compound(params Statement[] statements)
		{
			AppendLine("BEGIN");

			foreach (var statement in statements)
			{
				AppendLine(new string(' ', 2) + statement.ToString());
			}

			AppendLine("END");

			compound = true;

			return this;
		}

		public Statement IF(Expression condition, Statement then)
		{
			AppendLine($"IF {condition} {then}");
			return this;
		}

		public Statement IF(Expression condition, Statement then, Statement _else)
		{
			AppendLine($"IF {condition} {then} ELSE {_else}");
			return this;
		}

		public Statement WHILE(Expression condition, Statement loop)
		{
			AppendLine($"WHILE {condition} {loop}");
			return this;
		}

		public static implicit operator Statement(SqlBuilder sql)
		{
			return new Statement().AppendLine(sql.Query);
		}

		public override string ToString()
		{
			StringBuilder builder = new StringBuilder();
			foreach (string line in lines)
				builder.Append(line);

			return builder.ToString().Trim();
		}
	}
}

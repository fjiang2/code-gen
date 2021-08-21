using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Data.Coding
{
	public class Statement : SqlBuilder
	{

		public Statement()
		{
		}

		public SqlBuilder Compound(params Statement[] statements)
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

		public SqlBuilder IF(Expression condition, SqlBuilder then)
		{
			Append($"IF {condition} {then}");
			return this;
		}

		public SqlBuilder IF(Expression condition, SqlBuilder then, SqlBuilder _else)
		{
			Append($"IF {condition} {then} ELSE {_else}");
			return this;
		}

		public SqlBuilder WHILE(Expression condition, SqlBuilder loop)
		{
			Append($"WHILE {condition} {loop}");
			return this;
		}
	}
}

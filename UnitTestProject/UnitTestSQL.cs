using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sys.Data.Coding;

namespace UnitTestProject
{
	[TestClass]
	public class UnitTestSQL
	{
		[TestMethod]
		public void TestSelect()
		{

			var CategoryID = "CategoryID".ColumnName();

			string SQL = new SqlBuilder()
				.SELECT().TOP(10).COLUMNS().FROM("dbo.Categories").WHERE(CategoryID >= 10)
				.ToString();

			Debug.Assert(SQL == "SELECT TOP 10 * FROM dbo.Categories WHERE [CategoryID] >= 10");

			SQL = new SqlBuilder()
				.SELECT().DISTINCT().COLUMNS(CategoryID).FROM("dbo.[Products]").WHERE(CategoryID >= 2)
				.ToString();

			Debug.Assert(SQL == "SELECT DISTINCT [CategoryID] FROM dbo.[Products] WHERE [CategoryID] >= 2");
		}

		[TestMethod]
		public void TestJoin1()
		{
			string SQL = new SqlBuilder()
				.SELECT().COLUMNS("CategoryName".ColumnName("C"), "*".ColumnName("P"))
				.FROM("Products", "P")
				.INNER().JOIN("Categories","C").ON("CategoryID".ColumnName("C") == "CategoryID".ColumnName("P"))
				.WHERE("CategoryName".ColumnName("C") == "Dairy Products")
				.ToString();

			Debug.Assert(SQL == "SELECT C.[CategoryName], P.* FROM Products P INNER JOIN Categories C ON C.[CategoryID] = P.[CategoryID] WHERE C.[CategoryName] = N'Dairy Products'");

		}

		[TestMethod]
		public void TestJoin2()
		{
			string SQL = new SqlBuilder()
				.SELECT().COLUMNS("CategoryName".ColumnName("C"), "*".ColumnName("P"))
				.FROM("Products", "P")
				.INNER().JOIN("Categories", "C").ON("CategoryID".ColumnName("C") == "CategoryID".ColumnName("P"))
				.WHERE("CategoryName".ColumnName("C") == "Dairy Products")
				.ToString();

			Debug.Assert(SQL == "SELECT C.[CategoryName], P.* FROM Products P INNER JOIN Categories C ON C.[CategoryID] = P.[CategoryID] WHERE C.[CategoryName] = N'Dairy Products'");

		}
	}
}

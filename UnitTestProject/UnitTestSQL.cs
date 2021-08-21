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

			Debug.Assert(SQL == "SELECT TOP 10 * FROM [Categories] WHERE [CategoryID] >= 10");

			SQL = new SqlBuilder()
				.SELECT().DISTINCT().COLUMNS(CategoryID).FROM("dbo.[Products]").WHERE(CategoryID >= 2)
				.ToString();

			Debug.Assert(SQL == "SELECT DISTINCT [CategoryID] FROM [Products] WHERE [CategoryID] >= 2");
		}

		[TestMethod]
		public void TestJoin()
		{
			string SQL = new SqlBuilder()
				.SELECT().COLUMNS("CategoryName".ColumnName("C"), "*".ColumnName("P"))
				.FROM("Products", "P")
				.INNER().JOIN("Categories", "C").ON("CategoryID".ColumnName("C") == "CategoryID".ColumnName("P"))
				.WHERE("CategoryName".ColumnName("C") == "Dairy Products")
				.ToString();

			Debug.Assert(SQL == "SELECT C.[CategoryName], P.* FROM [Products] P INNER JOIN [Categories] C ON C.[CategoryID] = P.[CategoryID] WHERE C.[CategoryName] = N'Dairy Products'");

		}

		[TestMethod]
		public void TestColumnAsName()
		{
			string SQL = new SqlBuilder()
				.SELECT().COLUMNS("ProductID".ColumnName().AS("Id"), "ProductName".ColumnName().AS("Name"))
				.FROM("Products")
				.ToString();

			Debug.Assert(SQL == "SELECT [ProductID] AS Id, [ProductName] AS Name FROM [Products]");

			SQL = new SqlBuilder()
				.SELECT().COLUMNS("ProductID".AS("Id"), "ProductName".AS("Name"))
				.FROM("Products")
				.ToString();

			Debug.Assert(SQL == "SELECT [ProductID] AS Id, [ProductName] AS Name FROM [Products]");
		}

		[TestMethod]
		public void TestBetweenAndIn()
		{
			var ProductID = "ProductID".ColumnName();
			string SQL = new SqlBuilder()
				.SELECT().COLUMNS()
				.FROM("Products")
				.WHERE("ProductID".ColumnName().IN(1, 2, 3, 4).OR("ProductID".ColumnName().BETWEEN(1, 4)))
				.ToString();

			Debug.Assert(SQL == "SELECT * FROM [Products] WHERE [ProductID] IN (1, 2, 3, 4) OR [ProductID] BETWEEN 1 AND 4");
		}
	}
}

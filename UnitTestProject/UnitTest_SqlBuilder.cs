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
    public class UnitTest_SqlBuilder
    {
        [TestMethod]
        public void Test_SELECT()
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
        public void Test_JOIN()
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
        public void Test_Column_AS_Name()
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
        public void Test_BETWEEN_IN()
        {
            var ProductID = "ProductID".ColumnName();
            string SQL = new SqlBuilder()
                .SELECT()
                .COLUMNS()
                .FROM("Products")
                .WHERE(ProductID.IN(1, 2, 3, 4).OR(ProductID.BETWEEN(1, 4)))
                .ToString();

            Debug.Assert(SQL == "SELECT * FROM [Products] WHERE [ProductID] IN (1, 2, 3, 4) OR [ProductID] BETWEEN 1 AND 4");
        }

        [TestMethod]
        public void Test_INSERT()
        {
            string SQL = new SqlBuilder()
                .INSERT_INTO("Categories", new string[] { "CategoryName", "Description", "Picture" })
                .VALUES("Seafood", "Seaweed and fish", new byte[] { 0x15, 0xC2 })
                .ToString();

            Debug.Assert(SQL == "INSERT INTO [Categories] ([CategoryName],[Description],[Picture]) VALUES (N'Seafood',N'Seaweed and fish',0x15C2)");
        }

        [TestMethod]
        public void Test_UPDATE()
        {
            string SQL = new SqlBuilder()
                .UPDATE("Categories")
                .SET(
                    "CategoryName".Assign("Seafood"),
                    "Description".Assign("Seaweed and fish"),
                    "Picture".Assign(new byte[] { 0x15, 0xC2 })
                    )
                .WHERE("CategoryID".ColumnName() == 8)
                .ToString();

            Debug.Assert(SQL == "UPDATE [Categories] SET [CategoryName] = N'Seafood', [Description] = N'Seaweed and fish', [Picture] = 0x15C2 WHERE [CategoryID] = 8");
        }

        [TestMethod]
        public void Test_DELETE()
        {
            string SQL = new SqlBuilder()
                .DELETE_FROM("Categories")
                .WHERE("CategoryID".ColumnName() == 8)
                .ToString();

            Debug.Assert(SQL == "DELETE FROM [Categories] WHERE [CategoryID] = 8");
        }

        [TestMethod]
        public void Test_IS_NOT_EXISTS()
        {
            string Categories = "Categories";

            var select = new SqlBuilder()
                .SELECT()
                .COLUMNS()
                .FROM(Categories)
                .WHERE("CategoryID".ColumnName() == 8);

            var insert = new SqlBuilder()
                .INSERT_INTO(Categories, new string[] { "CategoryName", "Description", "Picture" })
                .VALUES("Seafood", "Seaweed and fish", new byte[] { 0x15, 0xC2 });

            var update = new SqlBuilder()
                .UPDATE(Categories)
                .SET(
                    "CategoryName".Assign("Seafood"),
                    "Description".Assign("Seaweed and fish"),
                    "Picture".Assign(new byte[] { 0x15, 0xC2 })
                    )
                .WHERE("CategoryID".ColumnName() == 8);

            string SQL = new Statement()
                .IF(select.EXISTS().NOT(), insert, update)
                .ToString();

            Debug.Assert(SQL == "IF NOT EXISTS (SELECT * FROM [Categories] WHERE [CategoryID] = 8) INSERT INTO [Categories] ([CategoryName],[Description],[Picture]) VALUES (N'Seafood',N'Seaweed and fish',0x15C2) ELSE UPDATE [Categories] SET [CategoryName] = N'Seafood', [Description] = N'Seaweed and fish', [Picture] = 0x15C2 WHERE [CategoryID] = 8");

            SQL = new Statement()
                .IF(select.EXISTS(), insert, update)
                .ToString();

            Debug.Assert(SQL == "IF EXISTS (SELECT * FROM [Categories] WHERE [CategoryID] = 8) INSERT INTO [Categories] ([CategoryName],[Description],[Picture]) VALUES (N'Seafood',N'Seaweed and fish',0x15C2) ELSE UPDATE [Categories] SET [CategoryName] = N'Seafood', [Description] = N'Seaweed and fish', [Picture] = 0x15C2 WHERE [CategoryID] = 8");

        }

        [TestMethod]
        public void Test_GROUP_BY()
        {
            var SQL = new SqlBuilder()
                .SELECT()
                .COLUMNS("CategoryID".ColumnName(), Expression.COUNT)
                .FROM("Products")
                .GROUP_BY("CategoryID")
                .HAVING(Expression.COUNT > 10)
                .ToString();

            Debug.Assert(SQL == "SELECT [CategoryID], COUNT(*) FROM [Products] GROUP BY [CategoryID] HAVING COUNT(*) > 10");
        }

        [TestMethod]
        public void Test_ORDER_BY()
        {
            var SQL = new SqlBuilder()
                .SELECT()
                .COLUMNS()
                .FROM("Products")
                .WHERE("UnitPrice".ColumnName() > 50.0)
                .ORDER_BY("ProductName").DESC()
                .ToString();

            Debug.Assert(SQL == "SELECT * FROM [Products] WHERE [UnitPrice] > 50 ORDER BY [ProductName] DESC");
        }

        [TestMethod]
        public void Test_CASE_WHEN()
        {
            var case_when = Expression.CASE(
                "CategoryID".ColumnName(),
                new Expression[]
                {
                    Expression.WHEN(1, "Road"),
                    Expression.WHEN(2, "Mountain"),
                    Expression.WHEN(3, "Touring"),
                    Expression.WHEN(4, "Other sale items"),
                },
                "Not for sale");

            var SQL = new SqlBuilder()
                .SELECT().TOP(10)
                .COLUMNS("ProductID".ColumnName(), "Category".Assign(case_when), "ProductName".ColumnName())
                .FROM("Products")
                .ORDER_BY("ProductID")
                .ToString();

            Debug.Assert(SQL == "SELECT TOP 10 [ProductID], [Category] = CASE [CategoryID] WHEN 1 THEN N'Road' WHEN 2 THEN N'Mountain' WHEN 3 THEN N'Touring' WHEN 4 THEN N'Other sale items' ELSE N'Not for sale' END, [ProductName] FROM [Products] ORDER BY [ProductID]");

            SQL = new SqlBuilder()
                .SELECT().TOP(10)
                .COLUMNS("ProductID".ColumnName(),
                    "Category".ColumnName()
                        .Assign()
                        .CASE("CategoryID".ColumnName())
                        .WHEN(1).THEN("Road")
                        .WHEN(2).THEN("Mountain")
                        .WHEN(3).THEN("Touring")
                        .WHEN(4).THEN("Other sale items")
                        .ELSE("Not for sale")
                        .END()
                    ,
                    "ProductName".ColumnName())
                .FROM("Products")
                .ORDER_BY("ProductID")
                .ToString();

            Debug.Assert(SQL == "SELECT TOP 10 [ProductID], [Category] = CASE [CategoryID] WHEN 1 THEN N'Road' WHEN 2 THEN N'Mountain' WHEN 3 THEN N'Touring' WHEN 4 THEN N'Other sale items' ELSE N'Not for sale' END, [ProductName] FROM [Products] ORDER BY [ProductID]");
        }
    }
}

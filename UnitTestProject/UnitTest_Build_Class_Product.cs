using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Data;
using System.IO;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sys.CodeBuilder;

namespace UnitTestProject
{
	[TestClass]
	public class UnitTest_Build_Class_Product
	{
		private CSharpBuilder cs;
		private Class clss;
		private string className = "Product";

		private DataTable dt;
		public const string _PRODUCTID = "ProductID";
		public const string _PRODUCTNAME = "ProductName";
		public const string _SUPPLIERID = "SupplierID";
		public const string _CATEGORYID = "CategoryID";
		public const string _QUANTITYPERUNIT = "QuantityPerUnit";
		public const string _UNITPRICE = "UnitPrice";
		public const string _UNITSINSTOCK = "UnitsInStock";
		public const string _UNITSONORDER = "UnitsOnOrder";
		public const string _REORDERLEVEL = "ReorderLevel";
		public const string _DISCONTINUED = "Discontinued";

		public UnitTest_Build_Class_Product()
		{
			this.cs = new CSharpBuilder
			{
				Namespace = "UnitTestProject",
			};

			this.cs.AddUsing("System");
			this.cs.AddUsing("System.Data");

			this.clss = new Class(className)
			{
				Modifier = Modifier.Public
			};


			AttributeInfo attr = new AttributeInfo("Table", Primitive.ToPrimitive("Product"), new { TableId = 1 });

			clss.AddAttribute(attr);

			cs.AddClass(clss);

			this.dt = new DataTable();
			DataColumn pk;
			dt.Columns.Add(pk = new DataColumn(_PRODUCTID, typeof(int)) { Unique = true });
			dt.Columns.Add(new DataColumn(_PRODUCTNAME, typeof(string)) { MaxLength = 40, Unique = true });
			dt.Columns.Add(new DataColumn(_SUPPLIERID, typeof(int)));
			dt.Columns.Add(new DataColumn(_CATEGORYID, typeof(int)));
			dt.Columns.Add(new DataColumn(_QUANTITYPERUNIT, typeof(string)) { MaxLength = 20 });
			dt.Columns.Add(new DataColumn(_UNITPRICE, typeof(decimal)));
			dt.Columns.Add(new DataColumn(_UNITSINSTOCK, typeof(short)));
			dt.Columns.Add(new DataColumn(_UNITSONORDER, typeof(short)));
			dt.Columns.Add(new DataColumn(_REORDERLEVEL, typeof(short)));
			dt.Columns.Add(new DataColumn(_DISCONTINUED, typeof(bool)) { Unique = true });

			dt.PrimaryKey = new DataColumn[] { pk };
		}

		[TestMethod]
		public void Test_All()
		{
			Test_Property();
			Test_Constructor();
			Method_FillObject();
			Test_Const_Field();

			string directory = Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\Sample");
			cs.Output(directory);
			string code = File.ReadAllText(Path.Combine(directory, $"{className}.cs"));
			//Assert.AreEqual(code, cs.ToString());
		}


		[TestMethod]
		public void Test_Constructor()
		{
			Constructor constructor = new Constructor(className)
			{
				Modifier = Modifier.Public,
				Params = new Parameters().Add(typeof(DataRow), "row")
			};

			clss.Add(constructor);

			var sent = constructor.Body;
			sent.AppendLine("FillObject(row);");

			string code = constructor.ToString();
			Assert.AreEqual(code, "public Product(DataRow row)\r\n{\r\n\tFillObject(row);\r\n}");
		}

		[TestMethod]
		public void Test_Property()
		{
			foreach (DataColumn column in dt.Columns)
			{
				var property = new Property(new TypeInfo(column.DataType), column.ColumnName)
				{
					Modifier = Modifier.Public
				};

				List<object> args = new List<object>();
				args.Add(column.ColumnName.ToUpper());
				if (dt.PrimaryKey.Contains(column))
				{
					var primary = new AttributeInfoArg("Primary", Primitive.ToPrimitive(true));
					args.Add(primary);
				}

				if (column.MaxLength > 0)
				{
					var length = new AttributeInfoArg("Length", Primitive.ToPrimitive(column.MaxLength));
					args.Add(length);
				}

				if (!column.Unique)
				{
					var NULL = new AttributeInfoArg("Nullable", Primitive.ToPrimitive(!column.Unique));
					args.Add(NULL);
				}

				AttributeInfo attr = new AttributeInfo("Column", args.ToArray());

				property.AddAttribute(attr);
				if (column.Unique)
					property.Comment = new Comment("default column: NOT NULL");

				clss.Add(property);
			}
		}


		[TestMethod]
		public void Test_Const_Field()
		{
			//Const Field
			foreach (DataColumn column in dt.Columns)
			{
				Field field = new Field(new TypeInfo { Type = typeof(string) }, column.ColumnName.ToUpper(), new Value(column.ColumnName))
				{
					Modifier = Modifier.Public | Modifier.Const
				};

				clss.Add(field);
			}
		}

		[TestMethod]
		public void Method_FillObject()
		{
			Method mtdFillObject = new Method("FillObject")
			{
				Modifier = Modifier.Public,
				Params = new Parameters().Add(typeof(DataRow), "row")
			};
			clss.Add(mtdFillObject);
			var sent = mtdFillObject.Body;

			foreach (DataColumn column in dt.Columns)
			{
				var type = new TypeInfo(column.DataType);
				var NAME = column.ColumnName.ToUpper();
				var name = column.ColumnName;

				var line = $"this.{name} = row.Field<{type}>({NAME});";
				sent.AppendLine(line);
			}
		}
	}
}


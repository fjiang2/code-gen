using System;
using System.Data;

namespace UnitTestProject
{
	[Table("Product", TableId = 1)]
	public class Product
	{
		[Column(PRODUCTID, Primary = true)]
		//default column: NOT NULL
		public int ProductID { get; set; }
		
		[Column(PRODUCTNAME, Length = 40)]
		//default column: NOT NULL
		public string ProductName { get; set; }
		
		[Column(SUPPLIERID, Nullable = true)]
		public int SupplierID { get; set; }
		
		[Column(CATEGORYID, Nullable = true)]
		public int CategoryID { get; set; }
		
		[Column(QUANTITYPERUNIT, Length = 20, Nullable = true)]
		public string QuantityPerUnit { get; set; }
		
		[Column(UNITPRICE, Nullable = true)]
		public decimal UnitPrice { get; set; }
		
		[Column(UNITSINSTOCK, Nullable = true)]
		public short UnitsInStock { get; set; }
		
		[Column(UNITSONORDER, Nullable = true)]
		public short UnitsOnOrder { get; set; }
		
		[Column(REORDERLEVEL, Nullable = true)]
		public short ReorderLevel { get; set; }
		
		[Column(DISCONTINUED)]
		//default column: NOT NULL
		public bool Discontinued { get; set; }
		
		public Product(DataRow row)
		{
			FillObject(row);
		}
		
		public void FillObject(DataRow row)
		{
			this.ProductID = row.Field<int>(PRODUCTID);
			this.ProductName = row.Field<string>(PRODUCTNAME);
			this.SupplierID = row.Field<int>(SUPPLIERID);
			this.CategoryID = row.Field<int>(CATEGORYID);
			this.QuantityPerUnit = row.Field<string>(QUANTITYPERUNIT);
			this.UnitPrice = row.Field<decimal>(UNITPRICE);
			this.UnitsInStock = row.Field<short>(UNITSINSTOCK);
			this.UnitsOnOrder = row.Field<short>(UNITSONORDER);
			this.ReorderLevel = row.Field<short>(REORDERLEVEL);
			this.Discontinued = row.Field<bool>(DISCONTINUED);
		}
		public const string PRODUCTID = "ProductID";
		public const string PRODUCTNAME = "ProductName";
		public const string SUPPLIERID = "SupplierID";
		public const string CATEGORYID = "CategoryID";
		public const string QUANTITYPERUNIT = "QuantityPerUnit";
		public const string UNITPRICE = "UnitPrice";
		public const string UNITSINSTOCK = "UnitsInStock";
		public const string UNITSONORDER = "UnitsOnOrder";
		public const string REORDERLEVEL = "ReorderLevel";
		public const string DISCONTINUED = "Discontinued";
	}
}
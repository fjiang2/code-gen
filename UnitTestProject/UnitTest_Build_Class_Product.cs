using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Sys.CodeBuilder;

namespace UnitTestProject
{
    /// <summary>
    /// 
    /// Run Run_All() to create class Product which is located on the directory .\Sample\Product.cs
    /// 
    /// </summary>
    [TestClass]
    public class UnitTest_Build_Class_Product
    {
        private CSharpBuilder cs;
        private Class clss;

        private DataTable dt;

        public UnitTest_Build_Class_Product()
        {
            //Define DataTable Product
            this.dt = new DataTable()
            {
                TableName = "Product"
            };
            DataColumn pk;
            dt.Columns.Add(pk = new DataColumn("ProductID", typeof(int)) { Unique = true, AutoIncrement = true });
            dt.Columns.Add(new DataColumn("ProductName", typeof(string)) { MaxLength = 40, Unique = true });
            dt.Columns.Add(new DataColumn("SupplierID", typeof(int)));
            dt.Columns.Add(new DataColumn("CategoryID", typeof(int)));
            dt.Columns.Add(new DataColumn("QuantityPerUnit", typeof(string)) { MaxLength = 20 });
            dt.Columns.Add(new DataColumn("UnitPrice", typeof(decimal)));
            dt.Columns.Add(new DataColumn("UnitsInStock", typeof(short)));
            dt.Columns.Add(new DataColumn("UnitsOnOrder", typeof(short)));
            dt.Columns.Add(new DataColumn("ReorderLevel", typeof(short)));
            dt.Columns.Add(new DataColumn("Discontinued", typeof(bool)) { Unique = true });
            dt.PrimaryKey = new DataColumn[] { pk };


            this.cs = new CSharpBuilder
            {
                Namespace = "UnitTestProject",
            };

            this.cs.AddUsing("System");
            this.cs.AddUsing("System.Data");

            this.clss = new Class(dt.TableName)
            {
                Modifier = Modifier.Public
            };
            cs.AddClass(clss);

            AttributeInfo attr = new AttributeInfo("Table", Primitive.ToPrimitive(dt.TableName), new { TableId = 1 });
            clss.AddAttribute(attr);

        }

        [TestMethod]
        public void Run_All()
        {
            Test_Property();
            Test_Constructor();
            Test_Method_FillObject();
            Test_Method_CopyTo();
            Test_Const_Field();

            string directory = Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\Sample");
            cs.Output(directory);
            string code = File.ReadAllText(Path.Combine(directory, $"{clss.Name}.cs"));
            //Assert.AreEqual(code, cs.ToString());
        }


        [TestMethod]
        public void Test_Constructor()
        {

            clss.Add(new Constructor(clss.Name));

            Constructor constructor = new Constructor(clss.Name)
            {
                Modifier = Modifier.Public,
                Params = new Parameters().Add(typeof(DataRow), "row")
            };

            clss.Add(constructor);

            var sent = constructor.Statement;
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

                if (column.AutoIncrement)
                {
                    var NULL = new AttributeInfoArg("Identity", Primitive.ToPrimitive(true));
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
        public void Test_Method_FillObject()
        {
            Method method = new Method("FillObject")
            {
                Modifier = Modifier.Public,
                Params = new Parameters().Add(typeof(DataRow), "row")
            };
            clss.Add(method);
            var sent = method.Statement;

            foreach (DataColumn column in dt.Columns)
            {
                var type = new TypeInfo(column.DataType);
                var NAME = column.ColumnName.ToUpper();
                var name = column.ColumnName;

                var line = $"this.{name} = row.Field<{type}>({NAME});";
                sent.AppendLine(line);
            }
        }

        [TestMethod]
        public void Test_Method_CopyTo()
        {
            Method method = new Method("CopyTo")
            {
                Modifier = Modifier.Public,
                Params = new Parameters().Add(clss.Name, "obj")
            };

            clss.Add(method);
            var sent = method.Statement;

            foreach (DataColumn column in dt.Columns)
            {
                var name = column.ColumnName;
                var line = $"obj.{name} = this.{name};";
                sent.AppendLine(line);
            }
        }
    }
}


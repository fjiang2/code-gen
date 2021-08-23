﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace UnitTestProject
{
    public class SqlCmd
    {
        private SqlCommand cmd;
        private SqlConnection conn;

        public SqlCmd(SqlConnectionStringBuilder connectionString, string sql, object parameters)
        {
            this.cmd = new SqlCommand(sql);
            this.conn = new SqlConnection(connectionString.ConnectionString);
            this.cmd.Connection = conn;

            if (parameters == null)
                return;

            if (parameters is IDictionary<string, object>)
                DecodeDictionary(parameters);
            else
                DecodeObject(parameters);
        }


        private void DecodeObject(object args)
        {
            foreach (var propertyInfo in args.GetType().GetProperties())
            {
                object value = propertyInfo.GetValue(args) ?? DBNull.Value;
                SqlParameter parameter = NewParameter("@" + propertyInfo.Name, value);
                cmd.Parameters.Add(parameter);
            }
        }

        private void DecodeDictionary(object args)
        {
            Dictionary<string, object> list = args as Dictionary<string, object>;
            foreach (KeyValuePair<string, object> item in list)
            {
                object value = item.Value ?? DBNull.Value;
                SqlParameter parameter = NewParameter("@" + item.Key, value);
                cmd.Parameters.Add(parameter);
            }
        }

        private SqlParameter NewParameter(string parameterName, object value)
        {
            SqlDbType dbType = SqlDbType.NVarChar;
            if (value is Int32)
                dbType = SqlDbType.Int;
            else if (value is Int16)
                dbType = SqlDbType.SmallInt;
            else if (value is long)
                dbType = SqlDbType.BigInt;
            else if (value is DateTime)
                dbType = SqlDbType.DateTime;
            else if (value is Double)
                dbType = SqlDbType.Float;
            else if (value is Single)
                dbType = SqlDbType.Float;
            else if (value is Decimal)
                dbType = SqlDbType.Decimal;
            else if (value is Boolean)
                dbType = SqlDbType.Bit;
            else if (value is string && ((string)value).Length > 4000)
                dbType = SqlDbType.NText;
            else if (value is string)
                dbType = SqlDbType.NVarChar;
            else if (value is byte[])
                dbType = SqlDbType.Binary;
            else if (value is Guid)
                dbType = SqlDbType.UniqueIdentifier;

            SqlParameter param = new SqlParameter(parameterName, dbType)
            {
                Value = value,
                Direction = ParameterDirection.Input,
            };
            return param;

        }

        public object FillObject()
        {
            DataRow row = FillDataRow();
            if (row != null && row.Table.Columns.Count > 0)
                return row[0];
            else
                return null;
        }

        public DataRow FillDataRow(int row = 0)
        {
            DataTable table = FillDataTable();
            if (table != null && row < table.Rows.Count)
                return table.Rows[row];
            else
                return null;
        }

        public DataTable FillDataTable()
        {
            DataSet ds = FillDataSet();
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            else
                return null;
        }

        public DataSet FillDataSet()
        {
            try
            {
                conn.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                return ds;
            }
            finally
            {
                conn.Close();
            }
        }

        public int ExecuteNonQuery()
        {
            try
            {
                conn.Open();
                int n = cmd.ExecuteNonQuery();
                return n;
            }
            finally
            {
                conn.Close();
            }
        }

        public object ExecuteScalar()
        {
            try
            {
                conn.Open();
                return cmd.ExecuteScalar();
            }
            finally
            {
                conn.Close();
            }
        }

    }
}
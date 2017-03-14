using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DynamicColumnsRdlcDemo
{
    public class DAO
    {
        public DataTable GetTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("ProductName", typeof(string));
            table.Columns.Add("Qty", typeof(int));
            table.Columns.Add("Date", typeof(DateTime));

            table.Rows.Add("ProductA", 1, DateTime.Parse("2016-01-01"));
            table.Rows.Add("ProductA", 2, DateTime.Parse("2016-01-15"));
            table.Rows.Add("ProductA", 3, DateTime.Parse("2016-01-31"));
            table.Rows.Add("ProductA", 1, DateTime.Parse("2016-02-01"));
            table.Rows.Add("ProductA", 2, DateTime.Parse("2017-01-01"));
            table.Rows.Add("ProductA", 3, DateTime.Parse("2017-01-15"));
            table.Rows.Add("ProductA", 1, DateTime.Parse("2017-01-31"));
            table.Rows.Add("ProductA", 2, DateTime.Parse("2017-02-01"));
            table.Rows.Add("ProductA", 3, DateTime.Parse("2017-02-15"));
            table.Rows.Add("ProductA", 1, DateTime.Parse("2017-02-28"));
            table.Rows.Add("ProductB", 2, DateTime.Parse("2016-01-01"));
            table.Rows.Add("ProductB", 3, DateTime.Parse("2016-01-15"));
            table.Rows.Add("ProductB", 1, DateTime.Parse("2016-01-30"));
            table.Rows.Add("ProductB", 2, DateTime.Parse("2016-02-01"));
            table.Rows.Add("ProductB", 3, DateTime.Parse("2017-01-01"));
            return table;
        }

        public List<Purchase> GetPurchases()
        {
            var table = GetTable();
            var purchases = table.AsEnumerable().Select(m => new Purchase
            {
                ProductName = m.Field<string>("ProductName"),
                Qty = m.Field<int>("Qty"),
                Date = m.Field<DateTime>("Date"),
            }).ToList();

            return purchases;
        }

        public List<ReportCell> GetReportCells(DataTable table)
        {
            return ReportCell.ConvertTableToCells(table);
        }
    }
}
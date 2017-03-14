using Microsoft.Reporting.WebForms;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DynamicColumnsRdlcDemo.Extension;
using System.Globalization;

namespace DynamicColumnsRdlcDemo
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            DAO dao = new DAO();
            var purchases = dao.GetTable().AsEnumerable().Select(m => new
            {
                ProductName = m.Field<string>("ProductName"),
                Qty = m.Field<int>("Qty"),
                Date = m.Field<DateTime>("Date"),
                Year = m.Field<DateTime>("Date").Year,
                Month = m.Field<DateTime>("Date").Month
            });

            var groupByYear = purchases.GroupBy(p => new { p.ProductName, p.Year })
                .Select(g => new
                {
                    ProductName = g.Key.ProductName,
                    Year = g.Key.Year,
                    Total = g.Sum(x => x.Qty)
                });

            var tableGroupByYear = groupByYear.ToDataTable();
            tableGroupByYear = tableGroupByYear.PivotDataTable("Year", "ProductName", "Total", "-", true);

            var groupByMonth = purchases.GroupBy(p => new { p.ProductName, p.Month })
                .Select(g => new
                {
                    ProductName = g.Key.ProductName,
                    Month = DateTimeFormatInfo.InvariantInfo.GetAbbreviatedMonthName(g.Key.Month),
                    Total = g.Sum(x => x.Qty)
                });
            var tableGroupByMonth = groupByMonth.ToDataTable();
            tableGroupByMonth = tableGroupByMonth.PivotDataTable("Month", "ProductName", "Total", "-", true);

            ReportViewer_main.LocalReport.ReportPath = Server.MapPath("~/RDLC/Report_main.rdlc");
            ReportViewer_main.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dao.GetReportCells(tableGroupByMonth)));
            ReportViewer_main.LocalReport.Refresh();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MVC.UI.Report
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataSet ds = new DataSet();
                
                //customers = _context.Customers.Where(t => t.FirstName.Contains(searchText) || t.LastName.Contains(searchText)).OrderBy(a => a.CustomerID).ToList();
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/Report1.rdlc");
                ds = GetData();
                ReportDataSource rdc = new ReportDataSource("DataSet1", ds.Tables[0]);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(rdc);
                //ReportViewer1.LocalReport.DataSources.Add(rdc);
                //ReportViewer1.LocalReport.Refresh();
                //ReportViewer1.DataBind();
                // dsCustomers = GetData("select top 20 * from customers");
                //ReportDataSource datasource = new ReportDataSource("Customers", dsCustomers.Tables[0]);
                //ReportViewer1.LocalReport.DataSources.Clear();
                //ReportViewer1.LocalReport.DataSources.Add(datasource);

            }
        }
        private DataSet GetData()
        {

            string qry = "select * from t_POS_detail";
            string conString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(qry,con);
            da.Fill(ds);
            //cmd.Connection = con;
            //da.SelectCommand = cmd;
            //da.Fill(ds);
            return ds;
        }


    }
}
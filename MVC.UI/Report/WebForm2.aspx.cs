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
                if (ds.Tables[0].Rows.Count > 0) {
                    ReportDataSource rdc = new ReportDataSource("DataSet_POS", ds.Tables[0]);
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportViewer1.LocalReport.DataSources.Add(rdc);
                    ReportViewer1.ZoomMode = Microsoft.Reporting.WebForms.ZoomMode.PageWidth;
                }


            }
        }
        private DataSet GetData()
        {

            string conString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            DataSet ds = new DataSet();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            cmd.Connection = con;
            cmd = new SqlCommand("[sp_Report_GetPOSbyID]", cmd.Connection);
            cmd.Parameters.Add(new SqlParameter("@transaction_id", "TR-20230208104546"));
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(ds);
            con.Close();
            return ds;
        }


    }
}
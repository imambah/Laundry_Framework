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
using System.Web.Mvc;
using ReportViewerForMvc;
using Web.Dta;
using Web.Dto;
using System.Windows;
using Microsoft.Win32;
using System.IO;


namespace MVC.UI.Report
{
    public partial class ReportViewer_Kartu_Piutang : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         
           string logo = Request.QueryString["logo"].ToString();

            if (!Page.IsPostBack)
            {
                DataSet ds = new DataSet();
                DataSet dsBANK = new DataSet();
                DataSet dsCatatan = new DataSet();

                //customers = _context.Customers.Where(t => t.FirstName.Contains(searchText) || t.LastName.Contains(searchText)).OrderBy(a => a.CustomerID).ToList();
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/Rpt_Kartu_Piutang.rdlc");

                //ReportParameter lim = new ReportParameter("image", @logo, true);
                ReportViewer1.LocalReport.EnableExternalImages = true;

                ds = GetData();
                Company_ProfileDbo CP = Master_CompanyItem.GetCompanyProfile();
                ReportParameter[] parameters = new ReportParameter[3];
                parameters[0] = new ReportParameter("logo", "file:///" + logo);
                parameters[1] = new ReportParameter("company_name",CP.company_name );
                parameters[2] = new ReportParameter("address", CP.city);

                ReportViewer1.LocalReport.SetParameters(parameters);

                if (ds.Tables[0].Rows.Count > 0) {
                    ReportDataSource rdc = new ReportDataSource("DS_KARTU_PIUTANG", ds.Tables[0]);
                    //ReportViewer1.LocalReport.SetParameters(parameters);
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
            cmd = new SqlCommand("[sp_Report_Kartu_Piutang]", cmd.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(ds);
            con.Close();
            return ds;
        }


    }
}
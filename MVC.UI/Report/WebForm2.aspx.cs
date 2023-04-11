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

namespace MVC.UI.Report
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           string strID = Request.QueryString["id"].ToString();
           string logo = Request.QueryString["logo"].ToString();

            if (!Page.IsPostBack)
            {
                DataSet ds = new DataSet();

                Company_ProfileDbo dsCompany = Master_CompanyItem.GetCompanyProfile();
                
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/Rpt_Tanda_Terima.rdlc");
                ReportViewer1.LocalReport.EnableExternalImages = true;
                ds = GetData(strID);


                string strKetentuan = Report_PosItem.GetKetentuan();
                string strWorkshop = Report_PosItem.Get_workshop();
                string branch_name = Session["Branch_NAME"].ToString();
                Company_ProfileDbo CP = Master_CompanyItem.GetCompanyProfile();
                ReportParameter[] parameters = new ReportParameter[6];
                parameters[0] = new ReportParameter("counter_name", branch_name); 
                parameters[1] = new ReportParameter("ketentuan", strKetentuan);
                parameters[2] = new ReportParameter("workshop", strWorkshop);
                parameters[3] = new ReportParameter("logo", "file:///" + logo);
                parameters[4] = new ReportParameter("company_name", CP.company_name);
                parameters[5] = new ReportParameter("address", CP.city);
                ReportViewer1.LocalReport.SetParameters(parameters);


                if (ds.Tables[0].Rows.Count > 0) {
                    ReportDataSource rdc = new ReportDataSource("DataSet_POS", ds.Tables[0]);
                    ReportViewer1.LocalReport.SetParameters(parameters);
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportViewer1.LocalReport.DataSources.Add(rdc);
                    ReportViewer1.ZoomMode = Microsoft.Reporting.WebForms.ZoomMode.PageWidth;
                }

            }
        }
        private DataSet GetData(string id)
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
            cmd.Parameters.Add(new SqlParameter("@id", id));
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(ds);
            con.Close();
            return ds;
        }

        
    }
}
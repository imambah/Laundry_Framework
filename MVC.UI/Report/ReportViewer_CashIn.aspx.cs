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
    public partial class ReportViewer_CashIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           string voucher_id = Request.QueryString["voucher_id"].ToString();
           string logo = Request.QueryString["logo"].ToString();

            if (!Page.IsPostBack)
            {
                DataSet ds = new DataSet();
                DataSet dsBANK = new DataSet();
                DataSet dsCatatan = new DataSet();

            
               

                ds = GetData(voucher_id);
                Company_ProfileDbo CP = Master_CompanyItem.GetCompanyProfile();
               


                string voucher_Type = ds.Tables[0].Rows[0]["Voucher_Type"].ToString();
                if (voucher_Type.ToUpper() == "CO") {
                    ReportParameter[] parameters = new ReportParameter[5];
                    parameters[0] = new ReportParameter("logo", "file:///" + logo);
                    parameters[1] = new ReportParameter("company_name", CP.company_name);
                    parameters[2] = new ReportParameter("address", CP.company_address);
                    parameters[3] = new ReportParameter("acc_no", CP.account_no);
                    parameters[4] = new ReportParameter("bank_name", CP.bank);
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/V_Cash_Out.rdlc");
                    ReportViewer1.LocalReport.EnableExternalImages = true;
                    ReportViewer1.LocalReport.SetParameters(parameters);
                }
                    
                else {
                    ReportParameter[] parameters = new ReportParameter[6];
                    parameters[0] = new ReportParameter("logo", "file:///" + logo);
                    parameters[1] = new ReportParameter("company_name", CP.company_name);
                    parameters[2] = new ReportParameter("address", CP.company_address);
                    parameters[3] = new ReportParameter("acc_no", CP.account_no);
                    parameters[4] = new ReportParameter("bank_name", CP.bank);
                    parameters[5] = new ReportParameter("terbilang", ds.Tables[0].Rows[0]["terbilang"].ToString());
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/V_Cash_In.rdlc");
                    ReportViewer1.LocalReport.EnableExternalImages = true;
                    ReportViewer1.LocalReport.SetParameters(parameters);
                }
                   
              

                if (ds.Tables[0].Rows.Count > 0) {

                    ReportDataSource rdc = new ReportDataSource("DS_CashIn", ds.Tables[0]);
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportViewer1.LocalReport.DataSources.Add(rdc);
                    ReportViewer1.ZoomMode = Microsoft.Reporting.WebForms.ZoomMode.PageWidth;
                }

            }
        }
        private DataSet GetData(string voucher_id)
        {

            string conString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            DataSet ds = new DataSet();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            cmd.Connection = con;
            cmd = new SqlCommand("[sp_Report_Cash_In]", cmd.Connection);
            cmd.Parameters.Add(new SqlParameter("@Voucher_ID", voucher_id));
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(ds);
            con.Close();
            return ds;
        }

        private DataSet GetBankInfo() {
            string conString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            DataSet ds = new DataSet();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            cmd.Connection = con;
            cmd = new SqlCommand("[sp_GETBANK_INFO]", cmd.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(ds);
            con.Close();
            return ds;
        }

    }
}
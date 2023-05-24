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
    public partial class ReportViewer_Invoice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           string invoice_no = Request.QueryString["invoice_no"].ToString();
           string logo = Request.QueryString["logo"].ToString();

            if (!Page.IsPostBack)
            {
                DataSet ds = new DataSet();
                DataSet dsBANK = new DataSet();
                DataSet dsCatatan = new DataSet();

                //customers = _context.Customers.Where(t => t.FirstName.Contains(searchText) || t.LastName.Contains(searchText)).OrderBy(a => a.CustomerID).ToList();
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/Invoice.rdlc");

                //ReportParameter lim = new ReportParameter("image", @logo, true);
                ReportViewer1.LocalReport.EnableExternalImages = true;

                ds = GetData(invoice_no);
                //dsBANK = GetBankInfo();
                dsCatatan = GetCatatan();
                Company_ProfileDbo CP = Master_CompanyItem.GetCompanyProfile();
                ReportParameter[] parameters = new ReportParameter[10];
                parameters[0] = new ReportParameter("username", CP.finance);
                parameters[1] = new ReportParameter("logo", "file:///" + logo);
                //parameters[2] = new ReportParameter("acc_no", dsBANK.Tables[0].Rows[0][0].ToString());
                //parameters[3] = new ReportParameter("bank_name", dsBANK.Tables[0].Rows[0][1].ToString());
                //parameters[4] = new ReportParameter("branch_name", dsBANK.Tables[0].Rows[0][2].ToString());
                parameters[2] = new ReportParameter("acc_no", CP.account_no);
                parameters[3] = new ReportParameter("bank_name", CP.bank);
                parameters[4] = new ReportParameter("branch_name", CP.bank_branch);
                parameters[5] = new ReportParameter("company_name",CP.company_name );
                parameters[6] = new ReportParameter("account_name", CP.account_name);
                parameters[7] = new ReportParameter("address", CP.city);
                //parameters[8] = new ReportParameter("catatan", dsCatatan.Tables[0].Rows[0][2].ToString());
                parameters[8] = new ReportParameter("catatan", "tes catatan ");
                parameters[9] = new ReportParameter("terbilang", ds.Tables[0].Rows[0][14].ToString());

                ReportViewer1.LocalReport.SetParameters(parameters);

                if (ds.Tables[0].Rows.Count > 0) {
                    ReportDataSource rdc = new ReportDataSource("DS_INVOICE", ds.Tables[0]);
                    //ReportViewer1.LocalReport.SetParameters(parameters);
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportViewer1.LocalReport.DataSources.Add(rdc);
                    ReportViewer1.ZoomMode = Microsoft.Reporting.WebForms.ZoomMode.PageWidth;
                }

            }
        }
        private DataSet GetData(string invoice_no)
        {

            string conString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            DataSet ds = new DataSet();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            cmd.Connection = con;
            cmd = new SqlCommand("[sp_Report_InvoicePeriode]", cmd.Connection);
            cmd.Parameters.Add(new SqlParameter("@invoice_no", invoice_no));
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

        private DataSet GetCatatan()
        {
            string conString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            DataSet ds = new DataSet();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            cmd.Connection = con;
            cmd = new SqlCommand("[sp_parameter_Catatan]", cmd.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(ds);
            con.Close();
            return ds;
        }

        //private void btnOpenFiles_Click(object sender, RoutedEventArgs e)
        //{
        //    OpenFileDialog openFileDialog = new OpenFileDialog();
        //    openFileDialog.Multiselect = true;
        //    openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
        //    openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        //    if (openFileDialog.ShowDialog() == true)
        //    {
        //        foreach (string filename in openFileDialog.FileNames)
        //            lbFiles.Items.Add(Path.GetFileName(filename));
        //    }
        //}
    }
}
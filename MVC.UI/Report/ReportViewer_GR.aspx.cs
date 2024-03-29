﻿using Microsoft.Reporting.WebForms;
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
    public partial class ReportViewer_GR : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           string gr_no = Request.QueryString["gr_no"].ToString();
           string logo = Request.QueryString["logo"].ToString();

            if (!Page.IsPostBack)
            {
                DataSet ds = new DataSet();
                DataSet dsBANK = new DataSet();
                DataSet dsCatatan = new DataSet();

                //customers = _context.Customers.Where(t => t.FirstName.Contains(searchText) || t.LastName.Contains(searchText)).OrderBy(a => a.CustomerID).ToList();
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/Report_GR.rdlc");

                //ReportParameter lim = new ReportParameter("image", @logo, true);
                ReportViewer1.LocalReport.EnableExternalImages = true;

                ds = GetData(gr_no);
                dsCatatan = GetCatatan();
                Company_ProfileDbo CP = Master_CompanyItem.GetCompanyProfile();
                ReportParameter[] parameters = new ReportParameter[3];
                parameters[0] = new ReportParameter("logo", "file:///" + logo);
                parameters[1] = new ReportParameter("companyname", CP.company_name);
                parameters[2] = new ReportParameter("companyaddress", CP.company_address);

                ReportViewer1.LocalReport.SetParameters(parameters);

                if (ds.Tables[0].Rows.Count > 0) {
                    ReportDataSource rdc = new ReportDataSource("ds_GR", ds.Tables[0]);
                    //ReportViewer1.LocalReport.SetParameters(parameters);
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportViewer1.LocalReport.DataSources.Add(rdc);
                    ReportViewer1.ZoomMode = Microsoft.Reporting.WebForms.ZoomMode.PageWidth;
                }

            }
        }
        private DataSet GetData(string gr_no)
        {

            string conString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            DataSet ds = new DataSet();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            cmd.Connection = con;
            cmd = new SqlCommand("[sp_Report_GR]", cmd.Connection);
            cmd.Parameters.Add(new SqlParameter("@gr_no", gr_no));
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

    }
}
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

namespace MVC.UI.Report
{
    public partial class WebForm_ARDetail1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           string strID = Request.QueryString["id"].ToString();

            if (!Page.IsPostBack)
            {
                DataSet ds = new DataSet();
                
                //customers = _context.Customers.Where(t => t.FirstName.Contains(searchText) || t.LastName.Contains(searchText)).OrderBy(a => a.CustomerID).ToList();
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/Rpt_ARDetail1.rdlc");
                ds = GetData(strID);
                string strKetentuan = Report_PosItem.GetKetentuan();
                string strWorkshop = Report_PosItem.Get_workshop();
                ReportParameter[] parameters = new ReportParameter[3];
                parameters[0] = new ReportParameter("counter_name", "PT IKAN BANDENG SEJAHTERA ");
                parameters[1] = new ReportParameter("ketentuan", strKetentuan);
                parameters[2] = new ReportParameter("workshop", strWorkshop);
                ReportViewer1.LocalReport.SetParameters(parameters);



                if (ds.Tables[0].Rows.Count > 0) {
                    ReportDataSource rdc = new ReportDataSource("DataSet_ARDetail1", ds.Tables[0]);
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
            cmd = new SqlCommand("[sp_report_AR_Detail]", cmd.Connection);
            cmd.Parameters.Add(new SqlParameter("@param", id));
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(ds);
            con.Close();
            return ds;
        }

        
    }
}
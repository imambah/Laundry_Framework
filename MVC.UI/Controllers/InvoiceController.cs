using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MVC.UI.Models;
using Web.Dta;
using Web.Dto;
using Web.Logic;

namespace MVC.UI.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: Parameter
        public ActionResult Index()
        {
            string strBranch_id = Session["Branch_ID"].ToString();           
            ViewBag.UserGroupList = new SelectList(UserGroupList(), "nama_pendek", "nama_pendek");
            return View();
        }

        public ActionResult filterPerusahaan(string Username) {
            ViewBag.UserGroupList = new SelectList(UserGroupList(), "nama_pendek", "nama_pendek");
            return View();
        }

        public List<CompanyDbo> UserGroupList()
        {
            List<CompanyDbo> ListBranch = Master_CompanyItem.GetUserGroup();
            return ListBranch;
        }

        public JsonResult GetInvoice(string CustomerType, string CustomerID, string Start_Date, string End_Date)
        {
            string[] date_start = Start_Date.Trim().Split('/');
            string date = date_start[0].Trim();
            string month = date_start[1].Trim();
            string year = date_start[2].Trim();
            
            string start_dt = month + '/' + date + '/' + year;

            string[] date_end = End_Date.Trim().Split('/');
            string dt_end = date_end[0].Trim();
            string mt_end = date_end[1].Trim();
            string yr_end = date_end[2].Trim();
           
            string end_dt = mt_end + '/' + dt_end+ '/' + yr_end;

            List<InvoiceDbo> listInvoice = InvoiceItem.GetItemByParam(CustomerType, CustomerID, start_dt,end_dt);
            return Json(listInvoice);
        }

        public ActionResult create_invoice(List<string> rows)
        {
            try
            {
                string strInvoice_No = tbl_parameterItem.getInvoce_Nomer("invoice");
                string strCustomer_Id = "";
                string strCustomer_Name = "";
                string strCust_Type= "";
                string strPeriode = "";
                int iterasi = 0;
                rows.ForEach(x =>
                {
                    var row = x.Split('|');
                    var id = row[0];    
                    var transaction_id = row[1];
                    strCustomer_Id = row[2];
                    strCustomer_Name = row[3];
                    strCust_Type = row[4];
                    strPeriode = row[5];
                    if (iterasi == 0) {
                        InvoiceItem.create_invoice_header(strInvoice_No, strCustomer_Id, strCustomer_Name,strPeriode);
                    }
                    iterasi = iterasi + 1;
                    InvoiceItem.create_invoice_detail(strInvoice_No, transaction_id, strCustomer_Id, strCust_Type);
                });

                InvoiceItem.createAR(strInvoice_No, Utilities.Username);
                return RedirectToAction("Index", "Invoice");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult list_invoice()
        {
            List<InvoiceDbo> list = InvoiceItem.GetAll();
            return View(list);
        }

        public ActionResult Print(string invoice_no)
        {
            var paramDbo = new ReportParamDbo();
            paramDbo.param1 = invoice_no;
            return View(paramDbo);
        }
        public ActionResult PrintOut(ReportParamDbo Model)
        {
            string str = Model.param1;
            Company_ProfileDbo objCompanyProfile = Master_CompanyItem.GetAll();
            string imgLogo = AppDomain.CurrentDomain.BaseDirectory + @"UploadFiles\" + objCompanyProfile.logo;
            return Redirect("~/Report/ReportViewer_Invoice.aspx?invoice_no=" + str + "&logo=" + imgLogo);
            //return View();
        }

        public ActionResult PrintLampiran(string invoice_no)
        {
            var paramDbo = new ReportParamDbo();
            paramDbo.param1 = invoice_no;
            return View(paramDbo);
        }
        public ActionResult PrintOut_Lampiran(ReportParamDbo Model)
        {
            string str = Model.param1;
            Company_ProfileDbo objCompanyProfile = Master_CompanyItem.GetAll();
            string imgLogo = AppDomain.CurrentDomain.BaseDirectory + @"UploadFiles\" + objCompanyProfile.logo;
            return Redirect("~/Report/ReportViewer_Invoice_Lampiran.aspx?invoice_no=" + str + "&logo=" + imgLogo);
            //return View();
        }
    }
}



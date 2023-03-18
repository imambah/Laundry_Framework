﻿using System;
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
            
            //List<POSDbo> list = Master_POSItem.GetAll_ByBranchID(strBranch_id);
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

        public JsonResult GetInvoice(string CustomerType, string CustomerID, string Periode)
        {
            List<InvoiceDbo> listInvoice = InvoiceItem.GetItemByParam(CustomerType, CustomerID, Periode);
            return Json(listInvoice);
        }

        public ActionResult create_invoice(List<string> rows)
        {
            try
            {

                string strInvoice_No = tbl_parameterItem.getInvoce_Nomer("invoice");
                string strCustomer_Id = "";
                string strCustomer_Name = "";
                //string strBranch_Id = "";
                int iterasi = 0;
                rows.ForEach(x =>
                {
                    var row = x.Split('|');
                    var id = row[0];    
                    var transaction_id = row[1];
                    strCustomer_Id = row[2];
                    strCustomer_Name = row[3];
                    if (iterasi == 0) {
                        InvoiceItem.create_invoice_header(strInvoice_No, strCustomer_Id, strCustomer_Name);
                    }
                    iterasi = iterasi + 1;
                    InvoiceItem.create_invoice_detail(strInvoice_No, transaction_id, strCustomer_Id);
                });


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
            return Redirect("~/Report/ReportViewer_Invoice.aspx?invoice_no=" + str);
            //return View();
        }
    }
}


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

               
                //InvoiceItem.create_invoice_header(strInvoice_No);
                //PosDetailPriceDbo detail_price = Master_POSItem.GetPriceDetail(transactionid);
                return RedirectToAction("index", "Invoice");
            }
            catch
            {
                return View();
            }
        }

        //public string getInvoce_Nomer(string strJenis, string initial) {
        //    string InvoiceNo = "";
        //    NomorDbo nomer = tbl_parameterItem.getNomer(strJenis);
        //    string strTahun = nomer.tahun.ToString();
        //    string strBulan = nomer.bulan.ToString();
        //    string strNo = nomer.nomer.ToString();

        //    if (strNo.Length == 1)
        //    {
        //        strNo = "00" + strNo;
        //    }
        //    else if (strNo.Length == 2)
        //    {
        //        strNo = "0" + strNo;
        //    }

        //    if (strBulan == "1")
        //        strBulan = "I";
        //    else if (strBulan == "2")
        //        strBulan = "II";
        //    else if (strBulan == "3")
        //        strBulan = "III";
        //    else if (strBulan == "4")
        //        strBulan = "IV";
        //    else if (strBulan == "5")
        //        strBulan = "V";
        //    else if (strBulan == "6")
        //        strBulan = "VI";
        //    else if (strBulan == "7")
        //        strBulan = "VII";
        //    else if (strBulan == "8")
        //        strBulan = "VIII";
        //    else if (strBulan == "9")
        //        strBulan = "XI";
        //    else if (strBulan == "10")
        //        strBulan = "X";
        //    else if (strBulan == "11")
        //        strBulan = "XI";
        //    else if (strBulan == "12")
        //        strBulan = "XII";

        //    InvoiceNo = strNo + "/" + "BiW-" + initial + "/" + strBulan + "/" + strTahun;
        //    return InvoiceNo;
        //}

    }
}



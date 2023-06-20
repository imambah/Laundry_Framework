using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.UI.Models;
using Web.Dta;
using Web.Dto;
using Web.Logic;

namespace MVC.UI.Controllers
{
    public class APController : Controller
    {
        // GET: AP
        public ActionResult Index()
        {
            List<APDbo> List = APItem.GetAll(); 
            return View(List);
        }

        public ActionResult Details(string supplier_id)
        { 
            List<AP_DetailDbo> list_det =APItem.GetDetailByID(supplier_id);
            ViewBag.ID = supplier_id;
            return View(list_det);
        }


        public ActionResult Bayar(decimal nilaiPiutang, string gr_no)
        {
            AP_BayarDbo APDbo = new AP_BayarDbo();
            APDbo.GR_No = gr_no;
            APDbo.NilaiHutang = nilaiPiutang;
            return View(APDbo);
        }

        [HttpPost]
        public ActionResult Bayar(AP_BayarDbo item)
        {
            try
            {
                if (item.SisaHutang < 0)
                {
                    ViewBag.ErrorMessage = "Nilai tidak boleh kurang dari Nol";
                    return RedirectToAction("Bayar", new { nilaiPiutang = item.NilaiHutang, invoice_no = item.GR_No });
                }
                else
                {
                    item.Create_By = Utilities.Username;
                    APItem.Insert(item);
                    return RedirectToAction("Index");
                }

            }
            catch
            {
                return View();
            }
        }

        public ActionResult Print(string id)
        {
            var paramDbo = new ReportParamDbo();
            paramDbo.param1 = id;
            return View(paramDbo);
        }
        public ActionResult PrintOut(ReportParamDbo Model)
        {
            string str = Model.param1;
            Company_ProfileDbo objCompanyProfile = Master_CompanyItem.GetAll();
            string imgLogo = AppDomain.CurrentDomain.BaseDirectory + @"UploadFiles\" + objCompanyProfile.logo;
            return Redirect("~/Report/ReportViewer_APDetail.aspx?supplier_id=" + str + "&logo=" + imgLogo);
            //return View();
        }
    }
}
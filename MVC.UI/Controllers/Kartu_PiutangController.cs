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
    public class Kartu_PiutangController : Controller
    {
        // GET: Kartu_Piutang
        public ActionResult Print()
        {
            var paramDbo = new ReportParamDbo();
            paramDbo.param1 = "";
            return View(paramDbo);
        }
        public ActionResult PrintOut(ReportParamDbo Model)
        {
            string str = Model.param1;
            Company_ProfileDbo objCompanyProfile = Master_CompanyItem.GetAll();
            string imgLogo = AppDomain.CurrentDomain.BaseDirectory + @"UploadFiles\" + objCompanyProfile.logo;
            return Redirect("~/Report/ReportViewer_Kartu_Piutang.aspx?logo=" + imgLogo);
            //return View();
        }
    }
}
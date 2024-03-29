﻿using System;
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
    public class APAgingController : Controller
    {
        // GET: APAging
        public ActionResult Index()
        {
            List<AP_AgingDbo> list = APItem.Get_AP_Aging();
            return View(list);
        }

        public ActionResult Details(string id)
        {
            List<Report_AP_Aging_Dbo> list_det = APItem.GetDetail(id);
            return View(list_det);
        }

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
            return Redirect("~/Report/ReportViewer_AP_Aging.aspx?logo=" + imgLogo );
            //return View();
        }
    }
}
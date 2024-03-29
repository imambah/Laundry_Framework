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
    public class ARAgingController : Controller
    {
        // GET: Parameter
        public ActionResult Index()
        {
            List<Report_AR_Aging_Dbo> list = Report_AR_Aging_Item.GetAll();
            return View(list);
        }
        public ActionResult Details(string id)
        {
            List<Report_AR_Aging_Dbo> list_det = Report_AR_Aging_Item.GetDetail(id);
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
            return Redirect("~/Report/ReportViewer_AR_Aging.aspx?logo=" + imgLogo);
            //return View();
        }
    }
}



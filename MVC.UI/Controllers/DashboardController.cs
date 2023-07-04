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
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetARByBranch(string bulan, string tahun)
        {
            
            List<DashboardDbo> ObjList = Dashboard_Item.GetARByBranch(bulan, tahun);
                  return Json(ObjList, JsonRequestBehavior.AllowGet);
        } 
        
        public JsonResult GetAPByBranch(string bulan , string tahun)
        {
            
            List<DashboardDbo> ObjList = Dashboard_Item.GetAPByBranch(bulan,tahun);
                  return Json(ObjList, JsonRequestBehavior.AllowGet);
        }
    }
}
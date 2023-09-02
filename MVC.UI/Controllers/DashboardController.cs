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
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            //DateTime now = DateTime.Now;
            //int year = now.Year;
            //ViewBag.tahun_skr = year;
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
        public JsonResult GetSALESByBranch(string bulan , string tahun)
        {
            
            List<DashboardDbo> ObjList = Dashboard_Item.GetSALESByBranch(bulan,tahun);
                  return Json(ObjList, JsonRequestBehavior.AllowGet);
        } 
        public JsonResult GetSALESByService(string bulan , string tahun)
        {
            
            List<DashboardDbo> ObjList = Dashboard_Item.GetSALESByService(bulan,tahun);
                  return Json(ObjList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetStock(string bulan, string tahun)
        {

            List<DashboardDbo> ObjList = Dashboard_Item.GetStock(bulan, tahun);
            return Json(ObjList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetStockByGroup(string bulan, string tahun)
        {

            List<DashboardDbo> ObjList = Dashboard_Item.GetStockByGroup(bulan, tahun);
            return Json(ObjList, JsonRequestBehavior.AllowGet);
        }
    }
}
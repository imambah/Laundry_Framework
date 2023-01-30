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
    public class PosController : Controller
    {
        // GET: Pos
        public ActionResult Index()
        {
            List<POSDbo> list = Master_POSItem.GetAll();
            return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }

        public JsonResult GetItemByType(string strType)
        {
            List<Master_PricelistDbo> listItem = Master_PricelistItem.GetItemByType(strType);
            return Json(listItem);
        }

        [HttpPost]
        public JsonResult getName(string Prefix)
        {
            var strValue = Prefix.ToUpper();
            List<Master_Klien> ObjList = Master_KlienItem.GetAll();
            var Name = (from N in ObjList
                        where N.nama_klien.ToUpper().Contains(strValue)
                        select new { N.nama_klien,N.alamat });
            return Json(Name, JsonRequestBehavior.AllowGet);
        }
    }
}
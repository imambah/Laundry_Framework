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
    public class ContractController : Controller
    {
        // GET: Contract
        public ActionResult Index()
        {
            List<Master_ContractDbo> list = Master_ContractItem.GetAll();
            return View(list);
        }


        public ActionResult Create()
        {
           List<Master_PricelistDbo> ListLayanan = Master_PricelistItem.GetAll();
            return View(ListLayanan);
        }

        // POST: Parameter/Create
        [HttpPost]
        public ActionResult Create(List<string> rows)
        {
            try
            {
                if (rows == null)
                {
                    return RedirectToAction("Index", "Contract");
                }
                else
                {
                    rows.ForEach(x =>
                    {
                        var row = x.Split('|');
                        var _kode_klien = row[0];
                        var _kode_layanan = row[1];
                        var _harga = row[2];

                        Master_ContractDbo ObjPoDetail = new Master_ContractDbo();
                        ObjPoDetail.Kode_Klien = _kode_klien;
                        ObjPoDetail.Kode_layanan = _kode_layanan;
                        ObjPoDetail.Harga = _harga;
                        ObjPoDetail.create_by = Utilities.Username;
                        Master_ContractItem.Insert(ObjPoDetail);

                    });

                    return RedirectToAction("Index", "Contract");
                }
                
            }
            catch
            {
                return View();
            }
        }

        //getName
        [HttpPost]
        public JsonResult getName(string Prefix)
        {
            var strValue = Prefix.ToUpper();
            List<Master_Klien> ObjList = Master_KlienItem.GetAll();
            var Name = (from N in ObjList
                        where N.nama_klien.ToUpper().Contains(strValue)
                        select new { N.nama_klien, N.alamat, N.kode_klien });
            return Json(Name, JsonRequestBehavior.AllowGet);
        }
    }

}
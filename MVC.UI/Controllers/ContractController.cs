using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.UI.Models;
using Newtonsoft.Json;
using Web.Dta;
using Web.Dto;
using Web.Logic;
//using System.Text.Json;


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

        public ActionResult Edit(string kode_klien, int kode_layanan)
        {
            Master_ContractDbo existing = Master_ContractItem.GetById(kode_klien, kode_layanan);
            return View(existing);
            //return View();
        }

        // POST: Client/Edit/5
        [HttpPost]
        public ActionResult Edit(Master_ContractDbo coll)
        {
            try
            {
                coll.update_by = Utilities.Username;
                Master_ContractItem.Update(coll, "0");
                return RedirectToAction("Index");
            }
            catch
            {
                return View(coll);
            }
        }

    
        public JsonResult ValidateItem(string kode_layanan, string kode_klien)
        {
            string strValue = "";
            
            List<Master_ContractDbo> ObjList = Master_ContractItem.GetItemByParam(kode_layanan, kode_klien);
            
            if (ObjList.Count > 0) {
                strValue = "1";              
            }
            else {
               strValue = "0";
            }

            var myData = new
            {
                Value = strValue
            };
         
            return Json(myData, JsonRequestBehavior.AllowGet); 
        }


        // GET: Client/Delete
        public ActionResult Delete(string kode_klien, int kode_layanan)
        {
            Master_ContractDbo existing = Master_ContractItem.GetById(kode_klien,kode_layanan);
            existing.update_by = Utilities.Username;
            Master_ContractItem.Update(existing, "1");
            return RedirectToAction("Index");
        }


        public ActionResult Active(string kode_klien, int kode_layanan)
        {
            Master_ContractDbo existing = Master_ContractItem.GetById(kode_klien, kode_layanan);
            existing.update_by = Utilities.Username;
            Master_ContractItem.Update(existing, "0");
            return RedirectToAction("Index");

        }

    }

}
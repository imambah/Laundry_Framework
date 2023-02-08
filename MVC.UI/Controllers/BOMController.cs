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
    public class BOMController : Controller
    {
        // GET: BOM
        public ActionResult Index()
        {
            List<BOMDbo> list = BOMItem.GetAll();
            return View(list);
        }

        // GET: BOM/Details/5
        public ActionResult Details(int id)
        {
            BOMDbo existing = BOMItem.GetById(id);
            return View(existing);
        }

        // GET: BOM/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BOM/Create
        [HttpPost]
        public ActionResult Create(BOMDbo  collection)
        {
            try
            {
                // TODO: Add insert logic here
                collection.create_by = Utilities.Username;
                BOMItem.Insert(collection);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BOM/Edit/5
        public ActionResult Edit(int id)
        {
            BOMDbo existing = BOMItem.GetById(id);
            return View(existing);
        }

        // POST: BOM/Edit/5
        [HttpPost]
        public ActionResult Edit(BOMDbo collection)
        {
            try
            {
                // TODO: Add update logic here
                collection.update_by = Utilities.Username;
                BOMItem.Update(collection);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BOM/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BOM/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Viewdetail(string kode_BOM)
        {
            var existing = BOMItem.GetMasterDetailByCode(kode_BOM);
            return View(existing);
        }

        public ActionResult CreateDetail(string kode_bom)
        {
            List<Master_BarangDbo> MasterBarang = Master_BarangItem.GetAll();
            List<SelectListItem> ListItemBarang = new List<SelectListItem>();
            MasterBarang.ForEach(t =>
            {
                ListItemBarang.Add(new SelectListItem() { Value = t.ItemCode, Text = t.ItemCode +"-"+ t.ItemDesc});
            });
            ViewBag.BarangList = new SelectList(ListItemBarang, "Value", "Text");

            BOMDetailDbo bomdetail = new BOMDetailDbo();
            bomdetail.kode_BOM = kode_bom;
            return View(bomdetail);
        }

        [HttpPost]
        public ActionResult CreateDetail(BOMDetailDbo collection)
        {
            try
            {
                // TODO: Add insert logic here
                BOMItem.InsertDetail(collection);
                return RedirectToAction("Viewdetail", new { kode_BOM = collection.kode_BOM });
            }
            catch
            {
                return View();
            }
        }
        // POST: BOM/Create
        [HttpPost]
        public ActionResult Viewdetail(BOMDetailDbo collection)
        {
            try
            {
                return RedirectToAction("CreateDetail", new { kode_bom = collection.kode_BOM });
            }
            catch
            {
                return View();
            }
        }


        
    }
}

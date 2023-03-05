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
    public class CashController : Controller
    {
        // GET: Cash
        public ActionResult Index()
        {
            List<CashDbo> list = CashItem.GetAll();
            return View(list);
        }

        // GET: Cash/Details/5
        public ActionResult Details(int id)
        {
            CashDbo existing = CashItem.GetById(id);
            return View(existing);
        }

        // GET: Cash/Create
        public ActionResult Create(string scr)
        {
            //CashDbo existing = scr;
            return View();
        }

        // POST: Cash/Create
        [HttpPost]
        public ActionResult Create(CashDbo  collection)
        {
            try
            {
                // TODO: Add insert logic here
                collection.create_by = Utilities.Username;
                CashItem.Insert(collection);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cash/Edit/5
        public ActionResult Edit(int id)
        {
            CashDbo existing = CashItem.GetById(id);
            return View(existing);
        }

        // POST: Cash/Edit/5
        [HttpPost]
        public ActionResult Edit(CashDbo collection)
        {
            try
            {
                // TODO: Add update logic here
                collection.update_by = Utilities.Username;
                CashItem.Update(collection);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cash/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cash/Delete/5
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

        public ActionResult Viewdetail(string Voucher_ID)
        {
            var existing = CashItem.GetMasterDetailByCode(Voucher_ID);
            return View(existing);
        }

        public ActionResult CreateDetail(string Voucher_ID)
        {
            List<Master_BarangDbo> MasterBarang = Master_BarangItem.GetAll();
            List<SelectListItem> ListItemBarang = new List<SelectListItem>();
            MasterBarang.ForEach(t =>
            {
                ListItemBarang.Add(new SelectListItem() { Value = t.ItemCode, Text = t.ItemCode +"-"+ t.ItemDesc});
            });
            ViewBag.BarangList = new SelectList(ListItemBarang, "Value", "Text");

            CashDetailDbo Cashdetail = new CashDetailDbo();
            Cashdetail.Voucher_ID = Voucher_ID;
            return View(Cashdetail);
        }

        [HttpPost]
        public ActionResult CreateDetail(CashDetailDbo collection)
        {
            try
            {
                // TODO: Add insert logic here
                CashItem.InsertDetail(collection);
                return RedirectToAction("Viewdetail", new { Voucher_ID = collection.Voucher_ID });
            }
            catch
            {
                return View();
            }
        }
        // POST: Cash/Create
        [HttpPost]
        public ActionResult Viewdetail(CashDetailDbo collection)
        {
            try
            {
                return RedirectToAction("CreateDetail", new { Voucher_ID = collection.Voucher_ID });
            }
            catch
            {
                return View();
            }
        }


        
    }
}

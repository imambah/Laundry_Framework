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
    }
}

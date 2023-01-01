using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.UI.Controllers
{
    public class BOM_DetailController : Controller
    {
        // GET: BOM_Detail
        public ActionResult Index()
        {
            return View();
        }

        // GET: BOM_Detail/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BOM_Detail/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BOM_Detail/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BOM_Detail/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BOM_Detail/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BOM_Detail/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BOM_Detail/Delete/5
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

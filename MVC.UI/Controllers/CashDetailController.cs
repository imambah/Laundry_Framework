using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.UI.Controllers
{
    public class Cash_DetailController : Controller
    {
        // GET: Cash_Detail
        public ActionResult Index()
        {
            return View();
        }

        // GET: Cash_Detail/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cash_Detail/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cash_Detail/Create
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

        // GET: Cash_Detail/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cash_Detail/Edit/5
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

        // GET: Cash_Detail/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cash_Detail/Delete/5
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

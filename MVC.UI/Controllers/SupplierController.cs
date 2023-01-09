using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Dta;
using Web.Dto;
using Web.Logic;


namespace MVC.UI.Controllers
{
    public class SupplierController : Controller
    {
        // GET: Supplier
        public ActionResult Index()
        {
            List<Master_SupplierDbo> list = Master_SupplierItem.GetAll();
            return View(list);
        }

        // GET: Supplier/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: Supplier/Create
        public ActionResult Create()
        {
            List<Master_NegaraDbo> MN = Master_NegaraItem.GetNegara();
            List<SelectListItem> ListNegara = new List<SelectListItem>();
            MN.ForEach(t =>
            {
                ListNegara.Add(new SelectListItem() { Value = t.id.ToString(), Text = t.nation_name });
            });
            // Retrieve departments and build SelectList
            ViewBag.NegaraList = new SelectList(ListNegara, "Value", "Text");
            return View();
        }

        // POST: Client/Create
        [HttpPost]
        public ActionResult Create(Master_SupplierDbo Coll)
        {
            try
            {
                // TODO: Add insert logic here
                Master_SupplierItem.Insert(Coll);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //// GET: Supplier/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Supplier/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Supplier/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Supplier/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}

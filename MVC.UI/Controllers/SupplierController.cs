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
            ViewBag.TOPList = new SelectList(TOPList(), "nama", "nama");
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

        public ActionResult Edit(string supplier_code)
        {
            Master_SupplierDbo existing = Master_SupplierItem.GetBySupplier_Code(supplier_code);
            ViewBag.TOPList = new SelectList(TOPList(), "nama", "nama");
            return View(existing);
        }

        // POST: Client/Edit/5
        [HttpPost]
        public ActionResult Edit( Master_SupplierDbo coll)
        {
            try
            {
                Master_SupplierItem.Update(coll, "N");
                return RedirectToAction("Index");
            }
            catch
            {
                return View(coll);
            }
        }

        public ActionResult Delete(string supplier_code)
        {
            Master_SupplierDbo existing = Master_SupplierItem.GetBySupplier_Code(supplier_code);

            Master_SupplierItem.Update(existing, "Y");
            return RedirectToAction("Index");
            //return RedirectToAction("Index");

        }

        public ActionResult Active(string supplier_code)
        {
            Master_SupplierDbo existing = Master_SupplierItem.GetBySupplier_Code(supplier_code);

            Master_SupplierItem.Update(existing, "A");
            return RedirectToAction("Index");
        }
        public ActionResult Details(string supplier_code)
        {
            Master_SupplierDbo existing = Master_SupplierItem.GetBySupplier_Code(supplier_code);
            return View(existing);
        }

        public List<GroupDbo> TOPList()
        {
            List<GroupDbo> TOPList = Master_KlienItem.GetTOP();
            return TOPList;
        }
    }
}

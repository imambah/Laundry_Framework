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
    public class ClientController : Controller
    {
        // GET: Client
        public ActionResult Index()
        {
            List<Master_Klien> list = Master_KlienItem.GetAll();
            return View(list);
        }

        // GET: Client/Details/5
        public ActionResult Details(string client_code)
        {
            Master_Klien existing = Master_KlienItem.GetByClient_Code(client_code);
            return View(existing);
        }

        // GET: Client/Create
        public ActionResult Create()
        {
            ViewBag.TOPList = new SelectList(TOPList(), "nama", "nama");
            return View();
        }

        public List<GroupDbo> TOPList()
        {
            List<GroupDbo> TOPList = Master_KlienItem.GetTOP();
            return TOPList;
        }

        // POST: Client/Create
        [HttpPost]
        public ActionResult Create(Master_Klien Coll)
        {
            try
            {
                // TODO: Add insert logic here
                Master_KlienItem.Insert(Coll);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Client/Edit/5
        public ActionResult Edit(string client_code)
        {
            Master_Klien existing = Master_KlienItem.GetByClient_Code(client_code);
            ViewBag.TOPList = new SelectList(TOPList(), "nama", "nama");
            return View(existing);
        }

        // POST: Client/Edit/5
        [HttpPost]
        public ActionResult Edit(string client_code, Master_Klien coll)
        {
            try
            {
                Master_KlienItem.Update(coll, "N");
                return RedirectToAction("Index");
            }
            catch
            {
                return View(coll);
            }
        }

        // GET: Client/Delete/5
        public ActionResult Delete(string client_code)
        {

            Master_Klien existing = Master_KlienItem.GetByClient_Code(client_code);
            if (existing != null)
            {
                Master_KlienItem.Delete(client_code);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Active(string client_code)
        {
            Master_Klien existing = Master_KlienItem.GetByClient_Code(client_code);

            Master_KlienItem.Update(existing, "A");
            return RedirectToAction("Index");
        }
    }
}

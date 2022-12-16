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
            return View();
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
            return View(existing);
        }

        // POST: Client/Edit/5
        [HttpPost]
        public ActionResult Edit(string client_code, Master_Klien coll)
        {
            try
            {
                Master_Klien tblParam = new Master_Klien();
                tblParam.id = coll.id;
                tblParam.kode_klien = coll.kode_klien;
                tblParam.nama_klien= coll.nama_klien;
                tblParam.alamat = coll.alamat;
                tblParam.no_telp = coll.no_telp;
                tblParam.is_supplier = coll.is_supplier;
                tblParam.is_customer = coll.is_customer;

                Master_Klien result = Master_KlienItem.Update(tblParam);
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

        // POST: Client/Delete/5
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

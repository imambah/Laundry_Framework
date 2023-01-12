using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MVC.UI.Models;
using Web.Dta;
using Web.Dto;
using Web.Logic;

namespace MVC.UI.Controllers
{
    public class BarangController : Controller
    {
        // GET: Parameter
        public ActionResult Index()
        {
            List<Master_BarangDbo> list = Master_BarangItem.GetAll();
            return View(list);
        }

        // GET: Parameter/Details/5
        public ActionResult Details(int id)
        {
            List<ItemGroupDbo> MasterGroup = Master_ItemGroupItem.GetItemGroupALL();
            List<SelectListItem> ListItemGroup = new List<SelectListItem>();
            MasterGroup.ForEach(t =>
            {
                ListItemGroup.Add(new SelectListItem() { Value = t.kode_tabel, Text = t.nama_panjang });
            });
            ViewBag.GroupList = new SelectList(ListItemGroup, "Value", "Text");
            Master_BarangDbo existing = Master_BarangItem.GetById(id);
            return View(existing);
        }

        // GET: Parameter/Create
        public ActionResult Create()
        {

            List<ItemGroupDbo> MasterGroup = Master_ItemGroupItem.GetItemGroupALL();
            List<SelectListItem> ListItemGroup = new List<SelectListItem>();
            MasterGroup.ForEach(t =>
            {
                ListItemGroup.Add(new SelectListItem() { Value = t.kode_tabel, Text = t.nama_panjang });
            });
            ViewBag.GroupList = new SelectList(ListItemGroup, "Value", "Text");

            return View();
        }

        // POST: Parameter/Create
        [HttpPost]
        public ActionResult Create(Master_BarangDbo item)
        {
            try
            {
                // TODO: Add insert logic here
                Master_BarangItem.Insert(item);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Parameter/Edit/5
        public ActionResult Edit(int id)
        {
            List<ItemGroupDbo> MasterGroup = Master_ItemGroupItem.GetItemGroupALL();
            List<SelectListItem> ListItemGroup = new List<SelectListItem>();
            MasterGroup.ForEach(t =>
            {
                ListItemGroup.Add(new SelectListItem() { Value = t.kode_tabel, Text = t.nama_panjang });
            });
            ViewBag.GroupList = new SelectList(ListItemGroup, "Value", "Text");
            Master_BarangDbo existing = Master_BarangItem.GetById(id);
            return View(existing);
        }

        // POST: Parameter/Edit/5
        [HttpPost]
        public ActionResult Edit(Master_BarangDbo item)
        {
            try
            {
                Master_BarangItem.Update(item,"N");
                return RedirectToAction("Index");
            }
            catch
            {
                return View(item);
            }
        }

        public ActionResult Delete(int id)
        {
            Master_BarangDbo existing = Master_BarangItem.GetById(id);
            Master_BarangItem.Update(existing, "Y");
            return RedirectToAction("Index");

        }

        public ActionResult Active(int id)
        {
            Master_BarangDbo existing = Master_BarangItem.GetById(id);
            Master_BarangItem.Update(existing, "A");
            return RedirectToAction("Index");

        }

    }
}



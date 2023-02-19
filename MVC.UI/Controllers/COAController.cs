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
    public class COAController : Controller
    {

        // GET: Parameter
        public ActionResult Index()
        {
            List<Master_COADbo> list = Master_COAItem.GetAll();
            return View(list);
        }

        // GET: Parameter/Details/5
        public ActionResult Details(int id)
        {
            Master_COADbo existing = Master_COAItem.GetById(id);
            return View(existing);
        }

        // GET: Parameter/Create
        public ActionResult Create()
        {

            List<ItemGroupDbo> MasterGroup = Master_ItemGroupItem.GetItemParameterByTable("COA_GRP");
            List<SelectListItem> ListItemGroup = new List<SelectListItem>();
            MasterGroup.ForEach(t =>
            {
                ListItemGroup.Add(new SelectListItem() { Value = t.kode_tabel, Text = t.nama_panjang });
            });
            ViewBag.GroupList = new SelectList(ListItemGroup, "Value", "Text");

            List<ItemGroupDbo> MasterSubGroup = Master_ItemGroupItem.GetItemParameterByTable("Level_1_Neraca");
            List<SelectListItem> ListItemSubGroup = new List<SelectListItem>();
            MasterSubGroup.ForEach(t =>
            {
                ListItemSubGroup.Add(new SelectListItem() { Value = t.kode_tabel, Text = t.nama_panjang });
            });
            ViewBag.GroupSubList = new SelectList(ListItemSubGroup, "Value", "Text");

            List<ItemGroupDbo> MasterLevelGroup = Master_ItemGroupItem.GetItemParameterByTable("Level_2_Neraca");
            List<SelectListItem> ListItemLevelGroup = new List<SelectListItem>();
            MasterLevelGroup.ForEach(t =>
            {
                ListItemLevelGroup.Add(new SelectListItem() { Value = t.kode_tabel, Text = t.nama_panjang });
            });
            ViewBag.GroupLevelList = new SelectList(ListItemLevelGroup, "Value", "Text");

            return View();
        }

        // POST: Parameter/Create
        [HttpPost]
        public ActionResult Create(Master_COADbo item)
        {
            try
            {
                // TODO: Add insert logic here
                Master_COAItem.Insert(item);
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
            //Group COA
            List<ItemGroupDbo> MasterGroup = Master_ItemGroupItem.GetItemParameterByTable("COA_GRP");
            List<SelectListItem> ListItemGroup = new List<SelectListItem>();
            MasterGroup.ForEach(t =>
            {
                ListItemGroup.Add(new SelectListItem() { Value = t.kode_tabel, Text = t.nama_panjang });
            });
            ViewBag.GroupList = new SelectList(ListItemGroup, "Value", "Text");
            //Sub GL
            List<ItemGroupDbo> MasterSubGroup = Master_ItemGroupItem.GetItemParameterByTable("Level_1_Neraca");
            List<SelectListItem> ListItemSubGroup = new List<SelectListItem>();
            MasterSubGroup.ForEach(t =>
            {
                ListItemSubGroup.Add(new SelectListItem() { Value = t.kode_tabel, Text = t.nama_panjang });
            });
            ViewBag.GroupSubList = new SelectList(ListItemSubGroup, "Value", "Text");
            //Level COA
            List<ItemGroupDbo> MasterLevelGroup = Master_ItemGroupItem.GetItemParameterByTable("Level_2_Neraca");
            List<SelectListItem> ListItemLevelGroup = new List<SelectListItem>();
            MasterLevelGroup.ForEach(t =>
            {
                ListItemLevelGroup.Add(new SelectListItem() { Value = t.kode_tabel, Text = t.nama_panjang });
            });
            ViewBag.GroupLevelList = new SelectList(ListItemLevelGroup, "Value", "Text");

            Master_COADbo existing = Master_COAItem.GetById(id);
            return View(existing);
        }

        // POST: Parameter/Edit/5
        [HttpPost]
        public ActionResult Edit(Master_COADbo item)
        {
            try
            {
                Master_COAItem.Update(item, "N");
                return RedirectToAction("Index");
            }
            catch
            {
                return View(item);
            }
        }

        public ActionResult Delete(int id)
        {
            Master_COADbo existing = Master_COAItem.GetById(id);
            Master_COAItem.Update(existing, "Y");
            return RedirectToAction("Index");

        }

        public ActionResult Active(int id)
        {
            Master_COADbo existing = Master_COAItem.GetById(id);
            Master_COAItem.Update(existing, "A");
            return RedirectToAction("Index");

        }sss

    }
}

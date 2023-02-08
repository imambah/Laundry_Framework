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

    public class PricelistController : Controller
    {
        // GET: Parameter
        public ActionResult Index()
        {

            List<Master_PricelistDbo> list = Master_PricelistItem.GetAll();
            return View(list);
        }

        //// GET: Parameter/Details/5
        //public ActionResult Details(int id)
        //{
        //    Master_BankDbo existing = Master_BankItem.GetById(id);
        //    return View(existing);
        //}

        // GET: Parameter/Create
        public ActionResult Create()
        {
            List<tbl_parameter> tblParam= tbl_parameterItem.Pricelist_GetTypeAll();
            List<SelectListItem> ListParam = new List<SelectListItem>();
            tblParam.ForEach(t =>
            {
                ListParam.Add(new SelectListItem() { Value = t.kode_tabel, Text = t.kode_tabel });
            });
            ViewBag.PriceTypeList = new SelectList(ListParam, "Value", "Text");
            return View();
        }

        // POST: Parameter/Create
        [HttpPost]
        public ActionResult Create(Master_PricelistDbo item)
        {
            try
            {
                // TODO: Add insert logic here
                item.create_by = Utilities.Username;
                Master_PricelistItem.Insert(item);
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
            Master_PricelistDbo existing = Master_PricelistItem.GetById(id);
            return View(existing);
           
        }

        [HttpPost]
        public ActionResult Edit(Master_PricelistDbo coll)
        {
            try
            {
                Master_PricelistItem.Update(coll,"N");
                return RedirectToAction("Index");
            }
            catch
            {
                return View(coll);
            }
        }


        public ActionResult Details(int id)
        {
          
            Master_PricelistDbo existing = Master_PricelistItem.GetById(id);
            return View(existing);
        }

        public ActionResult Delete(int id)
        {
           Master_PricelistDbo existing = Master_PricelistItem.GetById(id);

            Master_PricelistItem.Update(existing, "Y");
            return RedirectToAction("Index");
        }
        public ActionResult Active(int id)
        {
            Master_PricelistDbo existing = Master_PricelistItem.GetById(id);
            Master_PricelistItem.Update(existing, "A");
            return RedirectToAction("Index");
        }


    }
}



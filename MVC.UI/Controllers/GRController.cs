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
    public class GRController : Controller
    {
        // GET: GR
        public ActionResult Index()
        {
            List<GRDbo> list = GRItem.GetAll(Utilities.BranchID);
            return View(list);
        }

        // GET: GR/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GR/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GR/Create
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

        // GET: GR/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

       

        

      
    }
}

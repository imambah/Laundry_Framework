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

        // GET: Parameter/Details/5
        public ActionResult Details(int id)
        {
            Master_BankDbo existing = Master_BankItem.GetById(id);
            return View(existing);
        }

        // GET: Parameter/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Parameter/Create
        [HttpPost]
        public ActionResult Create(Master_BankDbo item)
        {
            try
            {
                // TODO: Add insert logic here
                Master_BankItem.Insert(item);
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
            Master_BankDbo existing = Master_BankItem.GetById(id);
            return View(existing);
            //return View();
        }

    }
}



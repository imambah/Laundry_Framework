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
    public class ContractController : Controller
    {
        // GET: Contract
        public ActionResult Index()
        {
            List<Master_ContractDbo> list = Master_ContractItem.GetAll();
            return View(list);
        }


        public ActionResult Create()
        {
           List<Master_PricelistDbo> ListLayanan = Master_PricelistItem.GetAll();
            return View(ListLayanan);
        }

        // POST: Parameter/Create
        [HttpPost]
        public ActionResult Create(Master_ContractDbo item)
        {
            try
            {

                item.create_by = Utilities.Username;
                Master_ContractItem.Insert(item);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }

}
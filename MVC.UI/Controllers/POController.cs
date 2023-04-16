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
    public class POController : Controller
    {
        // GET: Client
        public ActionResult Index()
        {
            List<PODbo> list = POItem.GetAll();
            return View(list);
        }
        public ActionResult Create()
        {
            return View();
        }

    }
}

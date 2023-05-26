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
    public class APController : Controller
    {
        // GET: AP
        public ActionResult Index()
        {
            List<APDbo> List = APItem.GetAll(); 
            return View(List);
        }
    }
}
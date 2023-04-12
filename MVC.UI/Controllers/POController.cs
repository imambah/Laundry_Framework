﻿using System;
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
            List<Master_Klien> list = Master_KlienItem.GetAll();
            return View(list);
        }

       
    }
}
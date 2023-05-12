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
        public ActionResult Create(string po_no)
        {
            List<GR_TransDbo> listPO = GRItem.Get_GRTransaction(po_no);
            return View(listPO);
        }
    }
}

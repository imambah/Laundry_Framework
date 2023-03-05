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
    public class ARController : Controller
    {
        // GET: Parameter
        public ActionResult Index()
        {
            List<Report_ARDbo> list = Report_ARItem.GetAll();
            return View(list);
        }

        public ActionResult Details(string id)
        {
            List<Report_ARDbo> list_det = Report_ARItem.GetDetail(id);
            return View(list_det);
        }
        public ActionResult Print(string id)
        {
            var paramDbo = new ReportParamDbo();
            paramDbo.param1 = id;
            return View(paramDbo);
        }
        public ActionResult PrintOut(ReportParamDbo Model)
        {
            string str = Model.param1;
            return Redirect("~/Report/WebForm_ARDetail1.aspx?id=" + str);
            //return View();
        }

    }
}



using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MVC.UI.Models;
using Web.Dta;
using Web.Dto;
using Web.Logic;

namespace MVC.UI.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: Parameter
        public ActionResult Index()
        {
            string strBranch_id = Session["Branch_ID"].ToString();
            List<POSDbo> list = Master_POSItem.GetAll_ByBranchID(strBranch_id);
            return View(list);
        }

        public ActionResult filterPerusahaan(string Username) {
            ViewBag.UserGroupList = new SelectList(UserGroupList(), "nama_pendek", "nama_pendek");
            return View();
            //return View();
        }

        public List<CompanyDbo> UserGroupList()
        {
            List<CompanyDbo> ListBranch = Master_CompanyItem.GetUserGroup();
            return ListBranch;
        }
    }
}



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
    public class CompanyProfileController : Controller
    {
        // GET: CompanyProfile
        public ActionResult Index()
        {
            Company_ProfileDbo existing = Master_CompanyItem.GetAll();
            return View(existing);
        }
        [HttpPost]
        public ActionResult Index(Company_ProfileDbo Item)
        {
            try
            {
                // TODO: Add insert logic here
                //Master_CompanyItem.Insert(Item);
                //return RedirectToAction("Index");

                Company_ProfileDbo existing =  Master_CompanyItem.GetCompanyProfileByName(Item.company_name);
                
                if (existing != null)
                {
                   Master_CompanyItem.Update(Item);
                    ViewBag.Message = string.Format("Data Berhasil di Update ");
                }
                else
                {
                    ViewBag.Message = string.Format("Data Berhasil di Tambah ");
                    Master_CompanyItem.Insert(Item);

                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
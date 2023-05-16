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
using System.IO;
namespace MVC.UI.Controllers
{
    public class CompanyProfileController : Controller
    {
        // GET: CompanyProfile
        public ActionResult Index()
        {
            Company_ProfileDbo existing = Master_CompanyItem.GetAll();
           // existing.logo = Path.Combine(Server.MapPath("~/Images"), Path.GetFileName(existing.logo));
            return View(existing);
        }
        [HttpPost]
        public ActionResult Index(Company_ProfileDbo Item, HttpPostedFileBase logo )
            //, HttpPostedFileBase file
        {
            try
            {
                // TODO: Add insert logic here
                //Master_CompanyItem.Insert(Item);
                //return RedirectToAction("Index");
                //var fileName = Path.GetFileName(logo.FileName);

                Company_ProfileDbo existing =  Master_CompanyItem.GetCompanyProfileByName(Item.id);
                
                if (existing != null)
                {
                    if (logo != null)
                    {
                        string path = Path.Combine(Server.MapPath("~/UploadFiles"), Path.GetFileName(logo.FileName));
                        logo.SaveAs(path);
                        Item.logo = logo.FileName;
                    }
                    else {
                        Item.logo = existing.logo;
                    }
                   
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
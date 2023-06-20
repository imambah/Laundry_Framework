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
    public class VoucherController : Controller
    {
        // GET: Voucher
        public ActionResult Index()
        {
            List<VoucherDbo> listVoucher = VoucherItem.GetAll();
            return View(listVoucher);
        }


        // GET: Parameter/Create
        public ActionResult CreateDetail()
        {
           // ViewBag.voucher_code= tbl_parameterItem.getVoucher_Nomer("voucher");
            return View();
        }

        // POST: Parameter/Create
        [HttpPost]
        public ActionResult Create(VoucherDbo item)
        {
            try
            {

                item.create_by = Utilities.Username;
                string strKet = string.Empty;

                if (item.status == "OUT") 
                    strKet = "BK";
                else
                    strKet = "BM";


                item.voucher_code = tbl_parameterItem.getVoucher_Nomer(strKet);
                VoucherItem.Insert(item);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
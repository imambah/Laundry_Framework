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
    public class PosController : Controller
    {
        // GET: Pos
        public ActionResult Index()
        {
            List<POSDbo> list = Master_POSItem.GetAll();
            return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }

        public JsonResult GetItemByType(string strType)
        {
            List<Master_PricelistDbo> listItem = Master_PricelistItem.GetItemByType(strType);
            return Json(listItem);
        }

        [HttpPost]
        public JsonResult getName(string Prefix)
        {
            var strValue = Prefix.ToUpper();
            List<Master_Klien> ObjList = Master_KlienItem.GetAll();
            var Name = (from N in ObjList
                        where N.nama_klien.ToUpper().Contains(strValue)
                        select new { N.nama_klien, N.alamat, N.kode_klien, N.tipe_konsumen });
            return Json(Name, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ProccessHeader(string header)
        {
            string[] result = header.Split('|');
            //string dateWithFormat = DateTime.Now.ToString("ddMMyyyyHHmmss");
            //string GenNo = "TR-" + dateWithFormat;
            POSDbo ObjPosHeader = new POSDbo();
            ObjPosHeader.transaction_type = result[0].Trim();
            ObjPosHeader.transaction_id = result[1].Trim();
            ObjPosHeader.customer_name = result[2].Trim();
            ObjPosHeader.room = result[3].Trim();
            ObjPosHeader.customer_address = result[4].Trim();
            ObjPosHeader.customer_type = result[5].Trim();
            ObjPosHeader.customerid = result[6].Trim();

            try
            {
                Master_POSItem.Insert(ObjPosHeader);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            } //return Json(true);
        }
        public ActionResult ProccessDetail(List<string> rows, string transactionid)
        {
            try
            {
                rows.ForEach(x =>
                {
                    var row = x.Split('|');
                    var transaction_id = transactionid;
                    var id = row[0];
                    var name = row[1];
                    var qty = row[2];
                    var laundry = 0;
                    if (row[3] == "false")
                       laundry = 1;
                   
                    var drycleaning = 0;
                    if (row[4] == "false") 
                        drycleaning = 1;

                    Service_PriceDbo price = Master_POSItem.GetPrice(id);

                    var remark = row[5];
                    POS_DetailDbo ObjPosDetail = new POS_DetailDbo();
                    ObjPosDetail.transaction_id = transactionid;
                    ObjPosDetail.kode_item = id;
                    ObjPosDetail.nama_item = name;
                    ObjPosDetail.jumlah_item = Convert.ToInt32(qty);
                    ObjPosDetail.service_laundry = Convert.ToInt32(laundry);
                    ObjPosDetail.service_laundry_price = price.service_Laundry_price;
                    ObjPosDetail.service_drycleaning = Convert.ToInt32(drycleaning);
                    ObjPosDetail.service_drycleaning_price = price.service_DryCleaning_price;
                    ObjPosDetail.remarks = remark;
                    Master_POSItem.InsertDetail(ObjPosDetail);
                });
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            } 
        }
    }
}
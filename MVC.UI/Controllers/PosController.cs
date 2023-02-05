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
                    var qty_laundry = row[2];
                    //reader["Group_Code"] == DBNull.Value ? null : reader["Group_Code"].ToString();
                    var qty_drycleaning = row[3];
                    var remark = row[4];
                    
                    var _qty_laundry = qty_laundry == "" ? 0 : Convert.ToInt32(qty_laundry);
                    var _qty_drycleaning = qty_drycleaning == "" ? 0 : Convert.ToInt32(qty_drycleaning);

                    Service_PriceDbo price = Master_POSItem.GetPrice(id);
                    var _laundry_price = price.service_Laundry_price;
                    var _drycleaning_price = price.service_DryCleaning_price;

                    POS_DetailDbo ObjPosDetail = new POS_DetailDbo();
                    ObjPosDetail.transaction_id = transactionid;
                    ObjPosDetail.kode_item = id;
                    ObjPosDetail.nama_item = name;
                    ObjPosDetail.service_laundry_qty = _qty_laundry;
                    ObjPosDetail.service_laundry_price = _laundry_price;
                    ObjPosDetail.service_drycleaning_qty = _qty_drycleaning;
                    ObjPosDetail.service_drycleaning_price = _drycleaning_price;
                    ObjPosDetail.total_qty = _qty_laundry + _qty_drycleaning;
                    ObjPosDetail.total_harga = (_qty_laundry * _laundry_price) + (_qty_drycleaning * _drycleaning_price);
                    ObjPosDetail.remarks = remark;
                    Master_POSItem.InsertDetail(ObjPosDetail);
                });
                return RedirectToAction("index","POS");
            }
            catch
            {
                return View();
            } 
        }
    }
}
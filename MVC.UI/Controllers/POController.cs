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
    public class POController : Controller
    {
        // GET: Client
        public ActionResult Index()
        {
            List<PODbo> list = POItem.GetAll();
            return View(list);
        }
        public ActionResult Create()
        {
            List<Master_BarangDbo> ListBarang = Master_BarangItem.GetAll();
            ViewBag.PO_number = tbl_parameterItem.getPO_Nomer("po");
            return View(ListBarang);
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
        public ActionResult ProccessInputPO(List<string> rows, string header)
        {
            try
            {
                string[] result = header.Split('|');
                var _ponumber = result[0];
                var _podate = result[1];
                var _customer_id = result[2];
                var _customer_name = result[3];
                var _delivery_date_plane = result[4];
                var _tof = result[5];
                var _po_desc = result[6];

                rows.ForEach(x =>
                {
                    var _po_no = _ponumber;
                    var row = x.Split('|');
                    var _item_code = row[0];
                    var _nama_barang = row[1];
                    var _harga = row[2];
                    var _qty = row[3];
                    var _total = row[4];
                    

                    PO_DetailDbo ObjPoDetail = new PO_DetailDbo();
                    ObjPoDetail.PO_number = _po_no;
                    ObjPoDetail.PO_line = 0;
                    ObjPoDetail.ItemCode = _item_code;
                    ObjPoDetail.Price = Convert.ToInt32(_harga);
                    ObjPoDetail.UOM = 0;
                    ObjPoDetail.Qty = Convert.ToInt32(_qty);
                    ObjPoDetail.Qty_Outstanding= Convert.ToInt32(0);
                    ObjPoDetail.Total = Convert.ToInt32(_total);
                    POItem.Insert_Detail(ObjPoDetail);

                });

                string[] date_now = result[4].Trim().Split('/');

                string date = date_now[0].Trim();
                string month = date_now[1].Trim();
                string year = date_now[2].Trim();
                //convert date

                //string tgl_estimasi = month + '/' + date + '/' + year;
                string DeliveryDatePlan = year + '/' + month + '/' + date;

                PO_HeaderDbo ObjPoHeader = new PO_HeaderDbo();
                ObjPoHeader.PO_number = result[0].Trim();
               // ObjPosHeader.PO_date = result[1].Trim();
                ObjPoHeader.customerid = result[2].Trim();
                ObjPoHeader.customername = result[3].Trim();
                ObjPoHeader.DeliveryDatePlan = Convert.ToDateTime(DeliveryDatePlan);
                ObjPoHeader.Term_Of_Payment = result[5].Trim();
                ObjPoHeader.PO_Description = result[6].Trim();
                ObjPoHeader.BranchID = "usersystem";
                //ObjPosHeader.create_by = Utilities.Username;
                POItem.Insert_Header(ObjPoHeader);
                return RedirectToAction("Index", "PO");
                //return RedirectToAction("index", "POS");
            }
            catch
            {
                return View();
            }
        }

    }
}

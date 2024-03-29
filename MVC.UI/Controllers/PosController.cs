﻿using System;
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
            string strUsername = Utilities.Username;
            string strBranch_id = Master_POSItem.GetBranch_ByUsername(strUsername);
            List<POSDbo> list = Master_POSItem.GetAll_ByBranchID(strBranch_id, strUsername);
            return View(list);
        }

        public ActionResult Create()
        {
           
            return View();
        }

        public JsonResult GetItemByType(string strType, string kode_klien)
        {
            List<Master_PricelistDbo> listItem = Master_PricelistItem.GetItemByType(strType, kode_klien);
            return Json(listItem);
        }

        [HttpPost]
        public JsonResult getName(string Prefix)
        {
            var strValue = Prefix.ToUpper();
            List<Master_Klien> ObjList = Master_KlienItem.GetAll_Client();
            var Name = (from N in ObjList
                        where N.nama_klien.ToUpper().Contains(strValue)
                        select new { N.nama_klien, N.alamat, N.kode_klien, N.tipe_konsumen });
            return Json(Name, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        
        public ActionResult ProccessDetail(List<string> rows, string transactionid, string header)
        {
            try
            {

                var POSNUMBER = tbl_parameterItem.getPOS_Nomer("pos");
                rows.ForEach(x =>
                {
                    var row = x.Split('|');
                    var transaction_id = POSNUMBER;
                    var id = row[0];
                    var name = row[1];
                    var qty_laundry = row[2];
                    //reader["Group_Code"] == DBNull.Value ? null : reader["Group_Code"].ToString();
                    var qty_drycleaning = row[3];
                    var remark = row[4];
                    
                    var _qty_laundry = qty_laundry == "" ? 0 : Convert.ToInt32(qty_laundry);
                    var _qty_drycleaning = qty_drycleaning == "" ? 0 : Convert.ToInt32(qty_drycleaning);

                    //Service_PriceDbo price = Master_POSItem.GetPrice(id);
                    var _laundry_price = row[5] == "" ? 0 : Convert.ToDecimal(row[5]);  //price.service_Laundry_price;
                    var _drycleaning_price = row[6] == "" ? 0 : Convert.ToDecimal(row[6]); //price.service_DryCleaning_price;

                    POS_DetailDbo ObjPosDetail = new POS_DetailDbo();
                    ObjPosDetail.transaction_id = transaction_id;
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

                PosDetailPriceDbo detail_price = Master_POSItem.GetPriceDetail(POSNUMBER);

                string[] result = header.Split('|');

                string[] date_now = result[7].Trim().Split('/');

                string date = date_now[0].Trim();
                string month = date_now[1].Trim();
                string year = date_now[2].Trim();
                //convert date

                //string tgl_estimasi = month + '/' + date + '/' + year;
                string tgl_estimasi = year + '/' + month + '/' + date;

                POSDbo ObjPosHeader = new POSDbo();
                ObjPosHeader.transaction_type = result[0].Trim();
                ObjPosHeader.transaction_id = POSNUMBER;
                ObjPosHeader.customer_name = result[2].Trim();
                ObjPosHeader.room = result[3].Trim();
                ObjPosHeader.customer_address = result[4].Trim();
                ObjPosHeader.customer_type = result[5].Trim();
                ObjPosHeader.customerid = result[6].Trim();
                ObjPosHeader.estimasi_selesai = Convert.ToDateTime(tgl_estimasi);
                ObjPosHeader.jumlah_item = detail_price.jumlah_qty;
                ObjPosHeader.nilai = detail_price.jumlah_nilai;
                ObjPosHeader.disc = detail_price.disc / 100;
                ObjPosHeader.sub_total = detail_price.jumlah_nilai - (detail_price.jumlah_nilai * (detail_price.disc / 100));
                ObjPosHeader.branchid = Session["Branch_ID"].ToString();
                ObjPosHeader.create_by = Utilities.Username;
                Master_POSItem.Insert(ObjPosHeader);


                return RedirectToAction("index","POS");
            }
            catch
            {
                return View();
            } 
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
            Company_ProfileDbo objCompanyProfile = Master_CompanyItem.GetAll();
            string imgLogo = AppDomain.CurrentDomain.BaseDirectory + @"UploadFiles\" + objCompanyProfile.logo;
            //return Redirect("~/Report/WebForm2.aspx?id=" + str );
            return Redirect("~/Report/WebForm2.aspx?id=" + str + "&logo=" + imgLogo);
            //return View();
        }

        public ActionResult print_penyerahan(string tr_id) {
           
            var paramDbo = new ReportParamDbo();
            paramDbo.param1 = tr_id;
            return View(paramDbo);
        }
        public ActionResult PrintOut_Penyerahan(ReportParamDbo Model)
        {
            string str = Model.param1;
            Company_ProfileDbo objCompanyProfile = Master_CompanyItem.GetAll();
            string imgLogo =  AppDomain.CurrentDomain.BaseDirectory + @"UploadFiles\" + objCompanyProfile.logo; ;
            return Redirect("~/Report/ReportViewer_TandaPenyerahan.aspx?id=" + str + "&logo=" + imgLogo);
            //return View();
        }
        public ActionResult Selesai(string id)
        {
            List<ItemGroupDbo> MasterGroup = Master_ItemGroupItem.GetItemParameterByTable("CARA BAYAR");
            List<SelectListItem> ListCaraBayarGroup = new List<SelectListItem>();
            MasterGroup.ForEach(t =>
            {
                ListCaraBayarGroup.Add(new SelectListItem() { Value = t.kode_tabel, Text = t.nama_panjang });
            });
            ViewBag.CaraBayar = new SelectList(ListCaraBayarGroup, "Value", "Text");
            List<POS_TransactionDbo> listPOS = Master_POSItem.Get_POSTransaction_Selesai(id);
            ViewBag.idHeader = id;

           
            return View(listPOS);
        }
       
        [HttpPost]
        public ActionResult ProsesTransEdit(string transactionid, string disc, string ppn, string grandtotal)
        {
            try
            {
                Master_POSItem.Update(transactionid, Utilities.Username, disc, ppn, grandtotal);
                return RedirectToAction("index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Edit(string id)
        {
            List<POS_TransactionDbo> listPOS = Master_POSItem.Get_POSTransaction(id);
            return View(listPOS);
        }
        [HttpPost]
        public ActionResult EditItem(List<string> rows, string transactionid) {

            rows.ForEach(x =>
            {
                var row = x.Split('|');
                var transaction_id = transactionid;
                var id = row[0];
                var name = row[1];
                var qty_laundry = row[2];
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
                ObjPosDetail.service_laundry_qty = _qty_laundry;
                ObjPosDetail.service_laundry_price = _laundry_price;
                ObjPosDetail.service_drycleaning_qty = _qty_drycleaning;
                ObjPosDetail.service_drycleaning_price = _drycleaning_price;
                ObjPosDetail.total_qty = _qty_laundry + _qty_drycleaning;
                ObjPosDetail.total_harga = (_qty_laundry * _laundry_price) + (_qty_drycleaning * _drycleaning_price);
                ObjPosDetail.remarks = remark;
                Master_POSItem.UpdateItem(ObjPosDetail);


            });
            return RedirectToAction("Index", "POS");
        }

        [HttpPost]
        public JsonResult getName_Invoice(string Prefix, string strCustomer_type)
        {
            var strValue = Prefix.ToUpper();
            List<Master_Klien> ObjList = Master_KlienItem.GetAll_Invoice(strCustomer_type);
            var Name = (from N in ObjList
                        where N.nama_klien.ToUpper().Contains(strValue)
                        select new { N.nama_klien, N.alamat, N.kode_klien, N.tipe_konsumen });
            return Json(Name, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(string id)
        {
            POS_TransactionDbo existing = Master_POSItem.CancelByID(Int32.Parse(id));
            return RedirectToAction("Index");
        }

        //UpdateDetail
        [HttpPost]

        public ActionResult UpdateDetail(List<string> rows, string transactionid, string header)
        {
            try
            {
                var qty = 0;
                rows.ForEach(x =>
                {
                    var row = x.Split('|');
                    var transaction_id = transactionid;
                    var id = row[0];
                    var _harga_laundry = row[1] == "" ? 0 : Convert.ToDecimal(row[1]); 
                    var _qty_selesai_laundry = row[2] == "" ? 0 : Convert.ToInt32(row[2]); 
                    var _harga_dryclean = row[3] == "" ? 0 : Convert.ToDecimal(row[3]); 
                    var _qty_selesai_dryclean = row[4] == "" ? 0 : Convert.ToInt32(row[4]); 


                    POS_DetailDbo ObjPosDetail = new POS_DetailDbo();
                    ObjPosDetail.transaction_id = transactionid;
                    ObjPosDetail.id = Convert.ToInt32(id);

                    ObjPosDetail.service_laundry_price = _harga_laundry;
                    ObjPosDetail.service_laundry_qty = _qty_selesai_laundry;

                    ObjPosDetail.service_drycleaning_price = _harga_dryclean;
                    ObjPosDetail.service_drycleaning_qty = _qty_selesai_dryclean;

                    ObjPosDetail.total_qty = _qty_selesai_laundry + _qty_selesai_dryclean;
                    ObjPosDetail.total_harga = (_qty_selesai_laundry * _harga_laundry) + (_qty_selesai_dryclean * _harga_dryclean);

                    Master_POSItem.UpdateDetail(ObjPosDetail);
                    qty = qty + _qty_selesai_laundry + _qty_selesai_dryclean;

                });

                var result = header.Split('|');

                //_total + '|' + _disc + '|' + _ppn + '|' + _grand_total + '|; 
                POSDbo ObjPosHeader = new POSDbo();
                ObjPosHeader.transaction_id = transactionid;
                ObjPosHeader.jumlah_item = qty;
                ObjPosHeader.nilai = Convert.ToDecimal(result[0]);//total
                ObjPosHeader.disc = Convert.ToDecimal(result[1]);
                ObjPosHeader.ppn = Convert.ToDecimal(result[2]);
                ObjPosHeader.sub_total = Convert.ToDecimal(result[3]); //_grand_total
                ObjPosHeader.cara_bayar = result[4].ToString();
                ObjPosHeader.create_by = Utilities.Username;
                Master_POSItem.UpdateHeader(ObjPosHeader, Utilities.Username);

                return RedirectToAction("Selesai", new { id= 7165 });
            }
            catch
            {
                return View();
            }
        }

    }
}
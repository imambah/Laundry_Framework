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
            //List<GR_DetailDbo> listItem = GRItem.getItemBarang(po_no);
            return View(listPO);
        }

        [HttpPost]
        public ActionResult Create(List<string> rows, string header)
        {
            try
            {

                if (header == null)
                {
                    return RedirectToAction("Index", "GR");
                }
                else
                {
                    string[] result = header.Split('|');
                    var _ponumber = result[0];
                    var _podate = result[1];
                    var _supplier_id = result[2];
                    var _supplier_name = result[3];
                    var _rencana_kirim = result[4];
                    var _cara_bayar = result[5];
                    var _po_desc = result[6];
                    var gr_number = tbl_parameterItem.getPO_Nomer("gr");
                    rows.ForEach(x =>
                    {
                        var _gr_no = gr_number;
                        var row = x.Split('|');
                        var _item_code = row[0];
                        var _nama_barang = row[1];
                        var _price = row[2];
                        var _pesan = row[3];
                        var _sisa = row[4];
                        var _terima = row[5];
                        var _keterangan = row[6];



                        GR_DetailDbo ObjGRDetail = new GR_DetailDbo();
                        ObjGRDetail.GR_Number = _gr_no;
                        ObjGRDetail.GR_line = 0;
                        ObjGRDetail.Item_Code = _item_code;
                        ObjGRDetail.Price_Sales = Convert.ToDouble(_price);
                        ObjGRDetail.qty = Convert.ToInt32(_terima);
                        ObjGRDetail.keterangan = _keterangan;
                        GRItem.Insert_Detail(ObjGRDetail, _ponumber);

                    });

                    GR_HeaderDbo ObjGRHeader = new GR_HeaderDbo();
                    ObjGRHeader.GR_Number = gr_number;
                    ObjGRHeader.PO_Number = _ponumber;
                    ObjGRHeader.supplierid = _supplier_id;
                    ObjGRHeader.DO_date = Convert.ToDateTime(_rencana_kirim);
                    ObjGRHeader.PO_Description = _po_desc;
                    ObjGRHeader.BranchID = "";
                    GRItem.Insert_Header(ObjGRHeader);
                    return RedirectToAction("Index", "GR");
                }
            }
            catch
            {
                return View();
            }
        }

        public JsonResult GetItemByPoNo(string po_number)
        {
            List<GR_DetailDbo> listItem = GRItem.getItemBarang(po_number);
            return Json(listItem);
        }

        public ActionResult Print(string po_no)
        {
            var paramDbo = new ReportParamDbo();
            paramDbo.param1 = po_no;
            return View(paramDbo);
        }
        public ActionResult PrintOut(ReportParamDbo Model)
        {
            string str = Model.param1;
            Company_ProfileDbo objCompanyProfile = Master_CompanyItem.GetAll();
            string imgLogo = AppDomain.CurrentDomain.BaseDirectory + @"UploadFiles\" + objCompanyProfile.logo;
            return Redirect("~/Report/ReportViewer_GR.aspx?po_no=" + str + "&logo=" + imgLogo);
            //return View();
        }
    }
}

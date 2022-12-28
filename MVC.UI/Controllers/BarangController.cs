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
    public class BarangController : Controller
    {
        // GET: Parameter
        public ActionResult Index()
        {
            List<Master_BarangDbo> list = Master_BarangItem.GetAll();
            return View(list);
        }

        // GET: Parameter/Details/5
        public ActionResult Details(int id)
        {
            List<ItemGroupDbo> MasterGroup = Master_ItemGroupItem.GetItemGroupALL();
            List<SelectListItem> ListItemGroup = new List<SelectListItem>();
            MasterGroup.ForEach(t =>
            {
                ListItemGroup.Add(new SelectListItem() { Value = t.kode_tabel, Text = t.nama_panjang });
            });
            ViewBag.GroupList = new SelectList(ListItemGroup, "Value", "Text");
            Master_BarangDbo existing = Master_BarangItem.GetById(id);
            return View(existing);
        }

        // GET: Parameter/Create
        public ActionResult Create()
        {

            List<ItemGroupDbo> MasterGroup = Master_ItemGroupItem.GetItemGroupALL();
            List<SelectListItem> ListItemGroup = new List<SelectListItem>();
            MasterGroup.ForEach(t =>
            {
                ListItemGroup.Add(new SelectListItem() { Value = t.kode_tabel, Text = t.nama_panjang });
            });
            ViewBag.GroupList = new SelectList(ListItemGroup, "Value", "Text");

            return View();
        }

        // POST: Parameter/Create
        [HttpPost]
        public ActionResult Create(Master_BarangDbo item)
        {
            try
            {
                // TODO: Add insert logic here
                Master_BarangItem.Insert(item);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Parameter/Edit/5
        public ActionResult Edit(int id)
        {
            List<ItemGroupDbo> MasterGroup = Master_ItemGroupItem.GetItemGroupALL();
            List<SelectListItem> ListItemGroup = new List<SelectListItem>();
            MasterGroup.ForEach(t =>
            {
                ListItemGroup.Add(new SelectListItem() { Value = t.kode_tabel, Text = t.nama_panjang });
            });
            ViewBag.GroupList = new SelectList(ListItemGroup, "Value", "Text");
            Master_BarangDbo existing = Master_BarangItem.GetById(id);
            return View(existing);
        }

        // POST: Parameter/Edit/5
        [HttpPost]
        public ActionResult Edit(Master_BarangDbo item)
        {
            try
            {
                //Master_BarangDbo tblParam = new Master_BarangDbo();
                //tblParam.id = id;
                //tblParam.ItemCode = item.ItemCode.ToString();
                //tblParam.ItemDesc = item.ItemDesc.ToString();
                //tblParam.Barcode = item.Barcode.ToString();
                //tblParam.Group_Code = item.Group_Code.ToString();
                //tblParam.UoM = item.UoM.ToString();
                //tblParam.Price_Purchase = item.Price_Purchase;
                //tblParam.Price_Inventory = item.Price_Inventory;
                //tblParam.Stock = item.Stock;
                //tblParam.Buffer_Stock = item.Buffer_Stock;
                //tblParam.Company_Persentage = item.Company_Persentage;
                //tblParam.Vat_Flag = item.Vat_Flag;
                //tblParam.Conversion = item.Conversion;
                //tblParam.BatchNo = item.BatchNo;
                Master_BarangItem.Update(item);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(item);
            }
        }

        //// GET: Parameter/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Parameter/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}



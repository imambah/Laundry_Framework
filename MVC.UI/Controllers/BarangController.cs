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
            Master_BankDbo existing = Master_BankItem.GetById(id);
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
        public ActionResult Create(Master_BankDbo item)
        {
            try
            {
                // TODO: Add insert logic here
                Master_BankItem.Insert(item);
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
            Master_BankDbo existing = Master_BankItem.GetById(id);
            return View(existing);
            //return View();
        }

        //// POST: Parameter/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, tbl_parameter item)
        //{
        //    try
        //    {
        //        tbl_parameter tblParam = new tbl_parameter();
        //        tblParam.id = id;
        //        tblParam.nama_tabel = item.nama_tabel.ToString();
        //        tblParam.kode_tabel = item.kode_tabel.ToString();
        //        tblParam.nama_panjang = item.nama_panjang.ToString();
        //        tblParam.nama_pendek = item.nama_pendek;
        //        tblParam.nilai = item.nilai;
        //        tbl_parameter result = tbl_parameterItem.Update(tblParam);
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View(item);
        //    }
        //}

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



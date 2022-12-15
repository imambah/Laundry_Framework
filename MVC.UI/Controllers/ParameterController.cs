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
    public class ParameterController : Controller
    {
        // GET: Parameter
        public ActionResult Index()
        {
            List<tbl_parameter> list = tbl_parameterItem.GetAll();
            return View(list);
        }

        // GET: Parameter/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Parameter/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Parameter/Create
        [HttpPost]      
        public ActionResult Create(tbl_parameter item)
        {
            try
            {
                // TODO: Add insert logic here
                tbl_parameterItem.Insert(item);
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
            tbl_parameter existing = tbl_parameterItem.GetById(id);
            return View(existing);
            //return View();
        }

        // POST: Parameter/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, tbl_parameter item)
        {
            try
            {
                tbl_parameter tblParam = new tbl_parameter();
                tblParam.id = id;
                tblParam.nama_tabel = item.nama_tabel.ToString();
                tblParam.kode_tabel = item.kode_tabel.ToString();
                tblParam.nama_panjang = item.nama_panjang.ToString();
                tblParam.nama_pendek = item.nama_pendek;
                tblParam.nilai = item.nilai;
                tbl_parameter result = tbl_parameterItem.Update(tblParam);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(item);
            }
        }

        // GET: Parameter/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Parameter/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

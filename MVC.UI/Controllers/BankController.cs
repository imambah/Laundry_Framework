﻿using System;
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
    public class BankController : Controller
    {
        // GET: Parameter
        public ActionResult Index()
        {
            List<Master_BankDbo> list = Master_BankItem.GetAll();
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
            return View();
        }

        // POST: Parameter/Create
        [HttpPost]
        public ActionResult Create(Master_BankDbo item)
        {
            try
            {
                
               item.create_by = Utilities.Username;
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

        // POST: Client/Edit/5
        [HttpPost]
        public ActionResult Edit( Master_BankDbo coll)
        {
            try
            {
                coll.update_by = Utilities.Username;
                Master_BankItem.Update(coll, "N");
                return RedirectToAction("Index");
            }
            catch
            {
                return View(coll);
            }
        }

        // GET: Client/Delete/5
        public ActionResult Delete(int id)
        {
            
            Master_BankDbo existing = Master_BankItem.GetById(id);
            existing.update_by = Utilities.Username;
            Master_BankItem.Update(existing, "Y");
            return RedirectToAction("Index");

        }


        // POST: Parameter/Delete/5
        [HttpPost]
        public ActionResult Delete(Master_BankDbo coll)
        {
            try
            {
                Master_BankItem.Update(coll,"Y");
                return RedirectToAction("Index");
            }
            catch
            {
                return View(coll);
            }
        }


        public ActionResult Active(int id)
        {
            Master_BankDbo existing = Master_BankItem.GetById(id);
            Master_BankItem.Update(existing, "A");
            return RedirectToAction("Index");
            //return RedirectToAction("Index");

        }


    }
}



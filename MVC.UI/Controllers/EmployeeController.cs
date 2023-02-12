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
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            List<Master_Employee> list = Master_EmployeeItem.GetAll();
            return View(list);
        }

        // GET: Employee/Details/5
        public ActionResult Details(string EmployeeID)
        {
            Master_Employee existing = Master_EmployeeItem.GetByEmployeeID(EmployeeID);
            return View(existing);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            ViewBag.TOPList = new SelectList(TOPList(), "nama", "nama");
            return View();
        }

        public List<GroupDbo> TOPList()
        {
            List<GroupDbo> TOPList = Master_EmployeeItem.GetTOP();
            return TOPList;
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(Master_Employee Coll)
        {
            try
            {
                // TODO: Add insert logic here
                Coll.create_by = Utilities.Username;
                Master_EmployeeItem.Insert(Coll);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(string EmployeeID)
        {
            Master_Employee existing = Master_EmployeeItem.GetByEmployeeID(EmployeeID);
            ViewBag.TOPList = new SelectList(TOPList(), "nama", "nama");
            return View(existing);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(string EmployeeID, Master_Employee coll)
        {
            try
            {
                coll.update_by = Utilities.Username;
                Master_EmployeeItem.Update(coll, "N");
                return RedirectToAction("Index");
            }
            catch
            {
                return View(coll);
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(string EmployeeID)
        {

            Master_Employee existing = Master_EmployeeItem.GetByEmployeeID(EmployeeID);
            if (existing != null)
            {
                Master_EmployeeItem.Delete(EmployeeID);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Active(string EmployeeID)
        {
            Master_Employee existing = Master_EmployeeItem.GetByEmployeeID(EmployeeID);

            Master_EmployeeItem.Update(existing, "A");
            return RedirectToAction("Index");
        }
    }
}

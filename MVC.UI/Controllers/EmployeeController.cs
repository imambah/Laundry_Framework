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
            //Agama
            List<ItemGroupDbo> MasterGroup = Master_ItemGroupItem.GetItemParameterByTable("Agama");
            List<SelectListItem> ListReligionGroup = new List<SelectListItem>();
            MasterGroup.ForEach(t =>
            {
                ListReligionGroup.Add(new SelectListItem() { Value = t.kode_tabel, Text = t.nama_panjang });
            });
            ViewBag.ReligionList = new SelectList(ListReligionGroup, "Value", "Text");

            //Status Pajak
            List<ItemGroupDbo> MasterGroupStatus = Master_ItemGroupItem.GetItemParameterByTable("Status");
            List<SelectListItem> ListStatusGroup = new List<SelectListItem>();
            MasterGroupStatus.ForEach(t =>
            {
                ListStatusGroup.Add(new SelectListItem() { Value = t.kode_tabel, Text = t.nama_panjang });
            });
            ViewBag.StatusList = new SelectList(ListStatusGroup, "Value", "Text");

            //ID Card
            List<ItemGroupDbo> MasterGroupIDCard = Master_ItemGroupItem.GetItemParameterByTable("ID_Card");
            List<SelectListItem> ListIDCardGroup = new List<SelectListItem>();
            MasterGroupIDCard.ForEach(t =>
            {
                ListIDCardGroup.Add(new SelectListItem() { Value = t.kode_tabel, Text = t.nama_panjang });
            });
            ViewBag.ID_CardList = new SelectList(ListIDCardGroup, "Value", "Text");

            //Departemen
            List<ItemGroupDbo> MasterGroupDepartment = Master_ItemGroupItem.GetItemParameterByTable("Departemen");
            List<SelectListItem> ListDepartmentGroup = new List<SelectListItem>();
            MasterGroupDepartment.ForEach(t =>
            {
                ListDepartmentGroup.Add(new SelectListItem() { Value = t.kode_tabel, Text = t.nama_panjang });
            });
            ViewBag.DepartmentList = new SelectList(ListDepartmentGroup, "Value", "Text");

            //Jabatan
            List<ItemGroupDbo> MasterGroupJabatan = Master_ItemGroupItem.GetItemParameterByTable("Jabatan");
            List<SelectListItem> ListJabatanGroup = new List<SelectListItem>();
            MasterGroupJabatan.ForEach(t =>
            {
                ListJabatanGroup.Add(new SelectListItem() { Value = t.kode_tabel, Text = t.nama_panjang });
            });
            ViewBag.JabatanList = new SelectList(ListJabatanGroup, "Value", "Text");

            //ViewBag.TOPList = new SelectList(TOPList(), "nama", "nama");
            return View();
        }

        public List<ItemGroupDbo> TOPList()
        {
            List<ItemGroupDbo> TOPList = Master_ItemGroupItem.GetItemParameterByTable("TOP");
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

            //Agama
            List<ItemGroupDbo> MasterGroup = Master_ItemGroupItem.GetItemParameterByTable("Agama");
            List<SelectListItem> ListReligionGroup = new List<SelectListItem>();
            MasterGroup.ForEach(t =>
            {
                ListReligionGroup.Add(new SelectListItem() { Value = t.kode_tabel, Text = t.nama_panjang });
            });
            ViewBag.ReligionList = new SelectList(ListReligionGroup, "Value", "Text");

            //Status Pajak
            List<ItemGroupDbo> MasterGroupStatus = Master_ItemGroupItem.GetItemParameterByTable("Status");
            List<SelectListItem> ListStatusGroup = new List<SelectListItem>();
            MasterGroupStatus.ForEach(t =>
            {
                ListStatusGroup.Add(new SelectListItem() { Value = t.kode_tabel, Text = t.nama_panjang });
            });
            ViewBag.StatusList = new SelectList(ListStatusGroup, "Value", "Text");

            //ID Card
            List<ItemGroupDbo> MasterGroupIDCard = Master_ItemGroupItem.GetItemParameterByTable("ID_Card");
            List<SelectListItem> ListIDCardGroup = new List<SelectListItem>();
            MasterGroupIDCard.ForEach(t =>
            {
                ListIDCardGroup.Add(new SelectListItem() { Value = t.kode_tabel, Text = t.nama_panjang });
            });
            ViewBag.ID_CardList = new SelectList(ListIDCardGroup, "Value", "Text");

            //Departemen
            List<ItemGroupDbo> MasterGroupDepartment = Master_ItemGroupItem.GetItemParameterByTable("Departemen");
            List<SelectListItem> ListDepartmentGroup = new List<SelectListItem>();
            MasterGroupDepartment.ForEach(t =>
            {
                ListDepartmentGroup.Add(new SelectListItem() { Value = t.kode_tabel, Text = t.nama_panjang });
            });
            ViewBag.DepartmentList = new SelectList(ListDepartmentGroup, "Value", "Text");

            //Jabatan
            List<ItemGroupDbo> MasterGroupJabatan = Master_ItemGroupItem.GetItemParameterByTable("Jabatan");
            List<SelectListItem> ListJabatanGroup = new List<SelectListItem>();
            MasterGroupJabatan.ForEach(t =>
            {
                ListJabatanGroup.Add(new SelectListItem() { Value = t.kode_tabel, Text = t.nama_panjang });
            });
            ViewBag.JabatanList = new SelectList(ListJabatanGroup, "Value", "Text");

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


using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using Web.Dto;
using System.Data;
namespace Web.Dta
{
    /// <summary>
    /// Dta Class of TABLE [Master_Employee]
    /// </summary>    
    public partial class Master_EmployeeItem
    {
        public static List<Master_Employee> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "sp_master_employee_GetAll";
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper(context, new Master_Employee());
        }
        public static Master_Employee GetByEmployeeID(string EmployeeID)
        {

            IDBHelper context = new DBHelper();
            context.CommandType = CommandType.StoredProcedure;
            context.CommandText = "sp_master_employee_GetByEmployeeID";
            context.AddParameter("@EmployeeID", EmployeeID);
            return DBUtil.ExecuteMapper<Master_Employee>(context, new Master_Employee()).FirstOrDefault();
        }

        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [Master_Employee]
        /// </summary>        
        public static Master_Employee Insert(Master_Employee obj)
        {
            Random rdm = new Random();
            int NoRdm = rdm.Next(1, 1000);

            string EmployeeID = "C" + NoRdm;

            IDBHelper context = new DBHelper();
            string sqlQuery = "sp_master_employee_Insert";
            context.AddParameter("@EmployeeID", EmployeeID);
            context.AddParameter("@EmployeeName", obj.EmployeeName);
            context.AddParameter("@Address1", obj.Address1);
            context.AddParameter("@Address2", obj.Address2);
            context.AddParameter("@City", obj.City);
            context.AddParameter("@Area", obj.Area);
            context.AddParameter("@Country", obj.Country);
            context.AddParameter("@Zip", obj.Zip);
            context.AddParameter("@Phone", obj.Phone);
            context.AddParameter("@Email", obj.Email);
            context.AddParameter("@Gender", obj.Gender);
            context.AddParameter("@Religion", obj.Religion);
            context.AddParameter("@Status", obj.Status);
            context.AddParameter("@ID_Card", obj.ID_Card);
            context.AddParameter("@ID_Card_No", obj.ID_Card_No);
            context.AddParameter("@Salary", obj.Salary);
            context.AddParameter("@Transport_Allowance", obj.Transport_Allowance);
            context.AddParameter("@Meal_Allowance", obj.Meal_Allowance);
            context.AddParameter("@Position_Allowance", obj.Position_Allowance);
            context.AddParameter("@TAXID", obj.TAXID);
            context.AddParameter("@TAXName", obj.TAXName);
            context.AddParameter("@TaxAddress", obj.TaxAddress);
            context.AddParameter("@bank_account", obj.bank_account);
            context.AddParameter("@bank_name", obj.bank_name);
            context.AddParameter("@bank_branch", obj.bank_branch);
            context.AddParameter("@Start_Date", obj.Start_Date);
            context.AddParameter("@End_Date", obj.End_Date);
            context.AddParameter("@Department", obj.Department);
            context.AddParameter("@Position", obj.Position);
            context.AddParameter("@Placement", obj.Placement);

            context.AddParameter("@create_date", DateTime.Now);
            context.AddParameter("@create_by", obj.create_by);
            context.AddParameter("@update_date", "");
            context.AddParameter("@update_by", "");

            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper<Master_Employee>(context, new Master_Employee()).FirstOrDefault();
        }

        public static Master_Employee Update(Master_Employee obj,string isdelete)
        {

            IDBHelper context = new DBHelper();
            context.AddParameter("@EmployeeID", obj.EmployeeID);
            context.AddParameter("@EmployeeName", obj.EmployeeName);
            context.AddParameter("@Address1", obj.Address1);
            context.AddParameter("@Address2", obj.Address2);
            context.AddParameter("@City", obj.City);
            context.AddParameter("@Area", obj.Area);
            context.AddParameter("@Country", obj.Country);
            context.AddParameter("@Zip", obj.Zip);
            context.AddParameter("@Phone", obj.Phone);
            context.AddParameter("@Email", obj.Email);
            context.AddParameter("@Gender", obj.Gender);
            context.AddParameter("@Religion", obj.Religion);
            context.AddParameter("@Status", obj.Status);
            context.AddParameter("@ID_Card", obj.ID_Card);
            context.AddParameter("@ID_Card_No", obj.ID_Card_No);
            context.AddParameter("@Salary", obj.Salary);
            context.AddParameter("@Transport_Allowance", obj.Transport_Allowance);
            context.AddParameter("@Meal_Allowance", obj.Meal_Allowance);
            context.AddParameter("@Position_Allowance", obj.Position_Allowance);
            context.AddParameter("@TAXID", obj.TAXID);
            context.AddParameter("@TAXName", obj.TAXName);
            context.AddParameter("@TaxAddress", obj.TaxAddress);
            context.AddParameter("@bank_account", obj.bank_account);
            context.AddParameter("@bank_name", obj.bank_name);
            context.AddParameter("@bank_branch", obj.bank_branch);
            context.AddParameter("@Start_Date", obj.Start_Date);
            context.AddParameter("@End_Date", obj.End_Date);
            context.AddParameter("@Department", obj.Department);
            context.AddParameter("@Position", obj.Position);
            context.AddParameter("@Placement", obj.Placement);

            context.AddParameter("@isdelete", isdelete);
            context.AddParameter("@update_date", DateTime.Now);
            context.AddParameter("@update_by", obj.update_by);

            string sqlQuery = "sp_master_employee_Update";
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper<Master_Employee>(context, new Master_Employee()).FirstOrDefault();
        }

        public static Master_Employee Delete(string EmployeeID) {
            IDBHelper context = new DBHelper();
            context.AddParameter("@EmployeeID", EmployeeID);
            string sqlQuery = "sp_master_employee_Delete";
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            //return DBUtil.ExecuteNonQuery(context);
            return DBUtil.ExecuteMapper<Master_Employee>(context, new Master_Employee()).FirstOrDefault();
        }
        #endregion

    }
}
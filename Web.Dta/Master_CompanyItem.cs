
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using Web.Dto;
using System.Data;
namespace Web.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_log]
    /// </summary>    
    public partial class Master_CompanyItem
    {
        public static List<CompanyDbo> GetBranch()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "sp_GetCompany";
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper(context, new CompanyDbo());
        }


        public static Company_ProfileDbo GetCompanyProfile() {
            IDBHelper context = new DBHelper();
            string sqlQuery = "sp_GetCompany_Profile";
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper<Company_ProfileDbo>(context, new Company_ProfileDbo()).FirstOrDefault();
        }
        #region Data Access


        public static Company_ProfileDbo Insert(Company_ProfileDbo obj)
        {           
            IDBHelper context = new DBHelper();
            string sqlQuery = "sp_master_CompanyProfile_Insert";
            context.AddParameter("@CompanyName", obj.company_name);
            context.AddParameter("@CompanyAddress", obj.company_address);
            context.AddParameter("@TelpNo", obj.telp_no);
            context.AddParameter("@create_date", DateTime.Now);
            context.AddParameter("@create_by", "user_system_update");
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper<Company_ProfileDbo>(context, new Company_ProfileDbo()).FirstOrDefault();
        }


        //public static GetCompanyProfile
        public static Company_ProfileDbo GetCompanyProfileByName(string company_name)
        {
            IDBHelper context = new DBHelper();
            context.CommandType = CommandType.StoredProcedure;
            context.CommandText = "sp_master_CompanyProfile_GetByName";
            context.AddParameter("@company_name", company_name);
            return DBUtil.ExecuteMapper<Company_ProfileDbo>(context, new Company_ProfileDbo()).FirstOrDefault();
        }


        public static Company_ProfileDbo GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "sp_master_CompanyProfile_GetAll";
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper<Company_ProfileDbo>(context, new Company_ProfileDbo()).FirstOrDefault();
        }
        #endregion


        public static Company_ProfileDbo Update(Company_ProfileDbo obj)
        {
            IDBHelper context = new DBHelper();
            context.AddParameter("@CompanyName", obj.company_name);
            context.AddParameter("@CompanyAddress", obj.company_address);
            context.AddParameter("@TelpNo", obj.telp_no);
            context.AddParameter("@update_date", DateTime.Now);
            context.AddParameter("@update_by", "user_system_update");
            string sqlQuery = "sp_master_CompanyProfile_Update";
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper<Company_ProfileDbo>(context, new Company_ProfileDbo()).FirstOrDefault();
        }
    }
}
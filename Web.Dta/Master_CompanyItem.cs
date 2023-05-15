
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
        public static List<CompanyDbo> GetUserGroup()
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
        public static Company_ProfileDbo GetCompanyProfileByName(int id)
        {
            IDBHelper context = new DBHelper();
            context.CommandType = CommandType.StoredProcedure;
            context.CommandText = "[sp_master_CompanyProfile_GetByID]";
            context.AddParameter("@id", id);
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
            context.AddParameter("@id", obj.id);
            context.AddParameter("@CompanyName", obj.company_name);
            context.AddParameter("@CompanyAddress", obj.company_address);
            context.AddParameter("@CompanyAddress2", obj.company_address2);
            context.AddParameter("@TelpNo", obj.telp_no);
            context.AddParameter("@city", obj.city);
            context.AddParameter("@area", obj.area);
            context.AddParameter("@country", obj.country);
            context.AddParameter("@zip", obj.zip);
            context.AddParameter("@email", obj.email);
            context.AddParameter("@PIC", obj.PIC);
            context.AddParameter("@tax_id", obj.tax_id);
            context.AddParameter("@tax_name", obj.tax_name);
            context.AddParameter("@tax_address", obj.tax_address);
            context.AddParameter("@logo", obj.logo);
            context.AddParameter("@director", obj.director);
            context.AddParameter("@finance", obj.finance);
            context.AddParameter("@website_erp", obj.website_erp);
            context.AddParameter("@certificate_no", obj.certificate_no);
            context.AddParameter("@fbackground", obj.fbackground);
            context.AddParameter("@bank", obj.bank);
            context.AddParameter("@account_name", obj.account_name);
            context.AddParameter("@account_no", obj.account_no);
            context.AddParameter("@bank_branch", obj.bank_branch);
            context.AddParameter("@update_date", DateTime.Now);
            context.AddParameter("@update_by", "user_system_update");
            string sqlQuery = "sp_master_CompanyProfile_Update";
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper<Company_ProfileDbo>(context, new Company_ProfileDbo()).FirstOrDefault();
        }

        public static List<GroupDbo> GetCabang(string strGroup)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "[sp_lookup_group]";
            context.CommandText = sqlQuery;
            context.AddParameter("@group", strGroup);
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper(context, new GroupDbo());
        }

    }
}
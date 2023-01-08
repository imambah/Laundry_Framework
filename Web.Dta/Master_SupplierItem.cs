
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
    public partial class Master_SupplierItem
    {
        public static List<Master_SupplierDbo> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "sp_master_supplier_GetAll";
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper(context, new Master_SupplierDbo());
        }

        //public static Master_SupplierDbo GetByClient_Code(string client_code)
        //{

        //    IDBHelper context = new DBHelper();
        //    context.CommandType = CommandType.StoredProcedure;
        //    context.CommandText = "sp_master_supplier_GetByClientCode";
        //    context.AddParameter("@client_code", client_code);
        //    return DBUtil.ExecuteMapper<Master_SupplierDbo>(context, new Master_SupplierDbo()).FirstOrDefault();
        //}

        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_log]
        /// </summary>        
        //public static Master_SupplierDbo Insert(Master_SupplierDbo obj)
        //{
        //    Random rdm = new Random();
        //    int NoRdm = rdm.Next(1, 1000);

        //    string Client_id = "SU" + NoRdm;

        //    IDBHelper context = new DBHelper();
        //    string sqlQuery = "sp_master_supplier_Insert";
        //    context.AddParameter("@kode_klien", Client_id);
        //    context.AddParameter("@nama_klien", obj.nama_klien);
        //    context.AddParameter("@alamat", obj.alamat);
        //    context.AddParameter("@alamat2", obj.alamat2);
        //    context.AddParameter("@kota", obj.kota);
        //    context.AddParameter("@area", obj.area);
        //    context.AddParameter("@negara", obj.negara);
        //    context.AddParameter("@kodepos", obj.kodepos);
        //    context.AddParameter("@no_telp", obj.no_telp);
        //    context.AddParameter("@email", obj.email);
        //    context.AddParameter("@PIC", obj.PIC);
        //    context.AddParameter("@tax_id", obj.tax_id);
        //    context.AddParameter("@tax_name", obj.tax_name);
        //    context.AddParameter("@tax_address", obj.tax_address);
        //    context.AddParameter("@bank_account", obj.bank_account);
        //    context.AddParameter("@bank_name", obj.bank_name);
        //    context.AddParameter("@bank_branch", obj.bank_branch);
        //    context.AddParameter("@credit_limit", obj.credit_limit);
        //    context.AddParameter("@status", obj.status);
        //    context.AddParameter("@COA", obj.COA);
        //    context.AddParameter("@TOP", obj.TOP);
        //    context.AddParameter("@profit_share", obj.profit_share);
        //    //context.AddParameter("@is_supplier", obj.is_supplier);
        //    //context.AddParameter("@is_customer", obj.is_customer);
        //    context.AddParameter("@create_date", DateTime.Now);
        //    context.AddParameter("@create_by", "user_system");
        //    context.AddParameter("@update_date", DateTime.Now);
        //    context.AddParameter("@update_by", "user_system");
        //    context.CommandText = sqlQuery;
        //    context.CommandType = CommandType.StoredProcedure;
        //    return DBUtil.ExecuteMapper<Master_SupplierDbo>(context, new Master_SupplierDbo()).FirstOrDefault();
        //}

        //public static Master_Klien Update(Master_Klien obj)
        //{

        //    IDBHelper context = new DBHelper();
        //    context.AddParameter("@kode_klien", obj.kode_klien);
        //    context.AddParameter("@nama_klien", obj.nama_klien);
        //    context.AddParameter("@alamat", obj.alamat);
        //    context.AddParameter("@alamat2", obj.alamat2);
        //    context.AddParameter("@kota", obj.kota);
        //    context.AddParameter("@area", obj.area);
        //    context.AddParameter("@negara", obj.negara);
        //    context.AddParameter("@kodepos", obj.kodepos);
        //    context.AddParameter("@no_telp", obj.no_telp);
        //    context.AddParameter("@email", obj.email);
        //    context.AddParameter("@PIC", obj.PIC);
        //    context.AddParameter("@tax_id", obj.tax_id);
        //    context.AddParameter("@tax_name", obj.tax_name);
        //    context.AddParameter("@tax_address", obj.tax_address);
        //    context.AddParameter("@bank_account", obj.bank_account);
        //    context.AddParameter("@bank_name", obj.bank_name);
        //    context.AddParameter("@bank_branch", obj.bank_branch);
        //    context.AddParameter("@credit_limit", obj.credit_limit);
        //    context.AddParameter("@status", obj.status);
        //    context.AddParameter("@COA", obj.COA);
        //    context.AddParameter("@TOP", obj.TOP);
        //    context.AddParameter("@profit_share", obj.profit_share);
        //    //context.AddParameter("@is_supplier", obj.is_supplier);
        //    //context.AddParameter("@is_customer", obj.is_customer);
        //    context.AddParameter("@update_date", DateTime.Now);
        //    context.AddParameter("@update_by", "user_system_update");
        //    string sqlQuery = "sp_master_client_Update";
        //    context.CommandText = sqlQuery;
        //    context.CommandType = CommandType.StoredProcedure;
        //    return DBUtil.ExecuteMapper<Master_Klien>(context, new Master_Klien()).FirstOrDefault();
        //}

        //public static Master_Klien Delete(string client_code) {
        //    IDBHelper context = new DBHelper();
        //    context.AddParameter("@kode_klien", client_code);
        //    string sqlQuery = "sp_master_client_Delete";
        //    context.CommandText = sqlQuery;
        //    context.CommandType = CommandType.StoredProcedure;
        //    //return DBUtil.ExecuteNonQuery(context);
        //    return DBUtil.ExecuteMapper<Master_Klien>(context, new Master_Klien()).FirstOrDefault();
        //}
        #endregion

    }
}
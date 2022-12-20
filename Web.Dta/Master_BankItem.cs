
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
    public partial class Master_BankItem
    {
        public static List<Master_BankDbo> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "sp_master_bank_GetAll";
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper(context, new Master_BankDbo());
        }

        public static Master_BankDbo GetById(int id)
        {

            IDBHelper context = new DBHelper();
            context.CommandType = CommandType.StoredProcedure;
            context.CommandText = "sp_master_bank_GetById";
            context.AddParameter("@id", id);
            return DBUtil.ExecuteMapper<Master_BankDbo>(context, new Master_BankDbo()).FirstOrDefault();
        }

        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_log]
        /// </summary>        
        public static Master_BankDbo Insert(Master_BankDbo obj)
        {
            Random rdm = new Random();
            int NoRdm = rdm.Next(1, 1000);

            string Bank_id = "B" + NoRdm;

            IDBHelper context = new DBHelper();
            string sqlQuery = "sp_master_bank_Insert";
            context.AddParameter("@BankID", Bank_id);
            context.AddParameter("@Description", obj.Description);
            context.AddParameter("@Area", obj.Area);
            context.AddParameter("@Account", obj.Account);
            context.AddParameter("@Balance", obj.Balance);     
            context.AddParameter("@create_date", DateTime.Now);
            context.AddParameter("@create_by", "user_system");
            context.AddParameter("@update_date", DateTime.Now);
            context.AddParameter("@update_by", "user_system");
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper<Master_BankDbo>(context, new Master_BankDbo()).FirstOrDefault();
        }

        //public static Master_BankDbo Update(Master_BankDbo obj)
        //{

        //    IDBHelper context = new DBHelper(); 
        //    //context.AddParameter("@kode_klien", obj.kode_klien);
        //    //context.AddParameter("@nama_klien", obj.nama_klien);
        //    //context.AddParameter("@alamat", obj.alamat);
        //    //context.AddParameter("@no_telp", obj.no_telp);
        //    //context.AddParameter("@is_supplier", obj.is_supplier);
        //    //context.AddParameter("@is_customer", obj.is_customer);
        //    //context.AddParameter("@update_date", DateTime.Now);
        //    context.AddParameter("@update_by", "user_system_update");
        //    string sqlQuery = "sp_master_client_Update";
        //    context.CommandText = sqlQuery;
        //    context.CommandType = CommandType.StoredProcedure;
        //    return DBUtil.ExecuteMapper<Master_BankDbo>(context, new Master_BankDbo()).FirstOrDefault();
        //}

        //public static Master_BankDbo Delete(string client_code) {
        //    IDBHelper context = new DBHelper();
        //    context.AddParameter("@kode_klien", client_code);
        //    string sqlQuery = "sp_master_client_Delete";
        //    context.CommandText = sqlQuery;
        //    context.CommandType = CommandType.StoredProcedure;
        //    //return DBUtil.ExecuteNonQuery(context);
        //    return DBUtil.ExecuteMapper<Master_BankDbo>(context, new Master_BankDbo()).FirstOrDefault();
        //}
        #endregion

    }
}

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
    public partial class Master_ContractItem
    {
        public static List<Master_ContractDbo> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "sp_master_Contract_GetAll";
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper(context, new Master_ContractDbo());
        }

        public static Master_ContractDbo Insert(Master_ContractDbo obj)
        {


            IDBHelper context = new DBHelper();
            string sqlQuery = "sp_master_Contract_Insert";
            context.AddParameter("@kode_klien", obj.Kode_Klien);
            context.AddParameter("@kode_layanan", obj.Kode_layanan);
            context.AddParameter("@harga", obj.Harga);
            context.AddParameter("@create_by", obj.create_by);
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper<Master_ContractDbo>(context, new Master_ContractDbo()).FirstOrDefault();
        }

        public static Master_ContractDbo Update(Master_ContractDbo obj, string isdelete)
        {

            IDBHelper context = new DBHelper();
            context.AddParameter("@kode_klien", obj.Kode_Klien.Trim());
            context.AddParameter("@kode_layanan", obj.Kode_layanan);
            context.AddParameter("@harga", obj.Harga);
            context.AddParameter("@update_by", obj.update_by);
            context.AddParameter("@is_delete", obj.is_delete);
            string sqlQuery = "[sp_master_Contract_Update]";
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper<Master_ContractDbo>(context, new Master_ContractDbo()).FirstOrDefault();
        }


        //GetById GetById
        public static Master_ContractDbo GetById(string kode_klien, int kode_layanan)
        {

            IDBHelper context = new DBHelper();
            context.CommandType = CommandType.StoredProcedure;
            context.CommandText = "sp_master_Contract_GetByID";
            context.AddParameter("@kode_klien", kode_klien);
            context.AddParameter("@kode_layanan", kode_layanan);
            return DBUtil.ExecuteMapper<Master_ContractDbo>(context, new Master_ContractDbo()).FirstOrDefault();
        }

        public static Master_ContractDbo Delete(string kode_klien, int kode_layanan)
        {

            IDBHelper context = new DBHelper();
            context.AddParameter("@kode_klien", kode_klien.Trim());
            context.AddParameter("@kode_layanan", kode_layanan);
            string sqlQuery = "[sp_master_Contract_Delete]";
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper<Master_ContractDbo>(context, new Master_ContractDbo()).FirstOrDefault();
        }

        #region Data Access



        #endregion

    }
}
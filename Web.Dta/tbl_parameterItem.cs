
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
    public partial class tbl_parameterItem
    {
        public static List<tbl_parameter> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "sp_parameter_GetAll";
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper(context, new tbl_parameter());
        }

        public static tbl_parameter GetById(int id)
        {
            
            IDBHelper context = new DBHelper();
            context.CommandType = CommandType.StoredProcedure;
            context.CommandText = "sp_parameter_GetById";
            context.AddParameter("@id", id);
            return DBUtil.ExecuteMapper<tbl_parameter>(context, new tbl_parameter()).FirstOrDefault();
        }

        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_log]
        /// </summary>        
        public static tbl_parameter Insert(tbl_parameter obj)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "sp_parameter_Insert";
            context.AddParameter("@nama_tabel", obj.nama_tabel);
            context.AddParameter("@kode_tabel", obj.kode_tabel);
            context.AddParameter("@nama_panjang", obj.nama_panjang);
            context.AddParameter("@nama_pendek", obj.nama_pendek);
            context.AddParameter("@nilai", obj.nilai);
            context.AddParameter("@create_date", DateTime.Now);
            context.AddParameter("@create_by", "user_system");
            context.AddParameter("@update_date", DateTime.Now);
            context.AddParameter("@update_by", "user_system");
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
           return DBUtil.ExecuteMapper<tbl_parameter>(context, new tbl_parameter()).FirstOrDefault();
        }

        public static tbl_parameter Update(tbl_parameter obj) {

            IDBHelper context = new DBHelper();
            context.AddParameter("@id", obj.id);
            context.AddParameter("@nama_tabel", obj.nama_tabel);
            context.AddParameter("@kode_tabel", obj.kode_tabel);
            context.AddParameter("@nama_panjang", obj.nama_panjang);
            context.AddParameter("@nama_pendek", obj.nama_pendek);
            context.AddParameter("@nilai", obj.nilai);
            context.AddParameter("@update_date", DateTime.Now);
            context.AddParameter("@update_by", "user_system_update"); ;
            string sqlQuery = "sp_parameter_Update";
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper<tbl_parameter>(context, new tbl_parameter()).FirstOrDefault();
        }

      
        #endregion

    }
}
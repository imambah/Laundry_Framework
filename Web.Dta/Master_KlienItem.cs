
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
    public partial class Master_KlienItem
    {
        public static List<Master_Klien> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "sp_Klien_GetAll";
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper(context, new Master_Klien());
        }

        //public static Master_Klien GetById(int id)
        //{

        //    IDBHelper context = new DBHelper();
        //    context.CommandType = CommandType.StoredProcedure;
        //    context.CommandText = "sp_parameter_GetById";
        //    context.AddParameter("@id", id);
        //    return DBUtil.ExecuteMapper<tbl_parameter>(context, new Master_Klien()).FirstOrDefault();
        //}

        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_log]
        /// </summary>        
        public static Master_Klien Insert(Master_Klien obj)
        {
            Random rdm = new Random();
            int NoRdm = rdm.Next(1, 1000);

            string Client_id = "C" + NoRdm;

            IDBHelper context = new DBHelper();
            string sqlQuery = "sp_master_client_Insert";
            context.AddParameter("@kode_klien", Client_id);
            context.AddParameter("@nama_klien", obj.nama_klien);
            context.AddParameter("@alamat", obj.alamat);
            context.AddParameter("@no_telp", obj.no_telp);
            context.AddParameter("@is_supplier", obj.is_supplier);
            context.AddParameter("@is_customer", obj.is_customer);
            context.AddParameter("@create_date", DateTime.Now);
            context.AddParameter("@create_by", "user_system");
            context.AddParameter("@update_date", DateTime.Now);
            context.AddParameter("@update_by", "user_system");
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper<Master_Klien>(context, new Master_Klien()).FirstOrDefault();
        }

        public static Master_Klien Update(Master_Klien obj)
        {

            IDBHelper context = new DBHelper(); 
            context.AddParameter("@kode_klien", obj.kode_klien);
            context.AddParameter("@nama_klien", obj.nama_klien);
            context.AddParameter("@alamat", obj.alamat);
            context.AddParameter("@no_telp", obj.no_telp);
            context.AddParameter("@is_supplier", obj.is_supplier);
            context.AddParameter("@is_customer", obj.is_customer);
            context.AddParameter("@update_date", DateTime.Now);
            context.AddParameter("@update_by", "user_system_update"); ;
            string sqlQuery = "sp_master_client_Update";
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper<Master_Klien>(context, new Master_Klien()).FirstOrDefault();
        }


        #endregion

    }
}
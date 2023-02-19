
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
    public partial class Master_COAItem
    {

        public static List<Master_COADbo> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "sp_master_COA_GetAll";
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper(context, new Master_COADbo());
        }

        public static Master_COADbo GetById(int id)
        {

            IDBHelper context = new DBHelper();
            context.CommandType = CommandType.StoredProcedure;
            context.CommandText = "sp_master_COA_GetById";
            context.AddParameter("@id", id);
            return DBUtil.ExecuteMapper<Master_COADbo>(context, new Master_COADbo()).FirstOrDefault();
        }

        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [Master_COA]
        /// </summary>        
        public static Master_COADbo Insert(Master_COADbo obj)
        {
            Random rdm = new Random();
            int NoRdm = rdm.Next(1, 100000);

            string ItemCode = "I" + NoRdm;

            IDBHelper context = new DBHelper();
            string sqlQuery = "sp_master_COA_Insert";
            context.AddParameter("@kode_COA", obj.kode_COA);
            context.AddParameter("@nama_COA", obj.nama_COA);
            context.AddParameter("@DRCR", obj.DRCR);
            context.AddParameter("@kelompok_COA", obj.kelompok_COA.ToString().Replace(",", "."));
            context.AddParameter("@sub_gl", obj.sub_gl.ToString().Replace(",", "."));
            context.AddParameter("@level_COA", obj.level_COA.ToString().Replace(",","."));
            context.AddParameter("@create_date", DateTime.Now);
            context.AddParameter("@create_by", "user_system");
            context.AddParameter("@update_date", DateTime.Now);
            context.AddParameter("@update_by", "user_system");
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper<Master_COADbo>(context, new Master_COADbo()).FirstOrDefault();
        }

        public static Master_BankDbo Update(Master_COADbo obj, string is_delete)
        {
            IDBHelper context = new DBHelper();
            context.AddParameter("@id", obj.id);
            context.AddParameter("@nama_COA", obj.nama_COA);
            context.AddParameter("@DRCR", obj.DRCR);
            context.AddParameter("@kelompok_COA", obj.kelompok_COA.ToString().Replace(",", "."));
            context.AddParameter("@sub_gl", obj.sub_gl.ToString().Replace(",", "."));
            context.AddParameter("@level_COA", obj.level_COA.ToString().Replace(",", "."));
            context.AddParameter("@update_date", DateTime.Now);
            context.AddParameter("@update_by", "user_system_update");
            context.AddParameter("@isdelete", is_delete);
            string sqlQuery = "sp_master_COA_Update";
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper<Master_BankDbo>(context, new Master_BankDbo()).FirstOrDefault();
        }

        #endregion

    }
}

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
    public partial class Master_POSItem
    {
        public static List<POSDbo> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "sp_POS_GetAll";
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper(context, new POSDbo());
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
            context.AddParameter("@account_name", obj.Account_Name);
            context.AddParameter("@COA", obj.COA);
            context.AddParameter("@create_date", DateTime.Now);
            context.AddParameter("@create_by", "user_system");
            context.AddParameter("@update_date", DateTime.Now);
            context.AddParameter("@update_by", "user_system");
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper<Master_BankDbo>(context, new Master_BankDbo()).FirstOrDefault();
        }

        public static Master_BankDbo Update(Master_BankDbo obj,string isdelete)
        {

            IDBHelper context = new DBHelper();
            context.AddParameter("@id", obj.id);
            context.AddParameter("@BankID", obj.BankID);
            context.AddParameter("@Description", obj.Description);
            context.AddParameter("@Area", obj.Area);
            context.AddParameter("@Account", obj.Account);
            context.AddParameter("@Balance", obj.Balance);
            context.AddParameter("@account_name", obj.Account_Name);
            context.AddParameter("@COA", obj.COA);
            context.AddParameter("@isdelete", isdelete);
            context.AddParameter("@update_by", "user_system_update");
            string sqlQuery = "[sp_master_bank_Update]";
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper<Master_BankDbo>(context, new Master_BankDbo()).FirstOrDefault();
        }

       
        #endregion

    }
}
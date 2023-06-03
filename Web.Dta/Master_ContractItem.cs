
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

        //public static Master_BankDbo GetById(int id)
        //{

        //    IDBHelper context = new DBHelper();
        //    context.CommandType = CommandType.StoredProcedure;
        //    context.CommandText = "sp_master_bank_GetById";
        //    context.AddParameter("@id", id);
        //    return DBUtil.ExecuteMapper<Master_BankDbo>(context, new Master_BankDbo()).FirstOrDefault();
        //}

        //public static List<GroupDbo> GetBank()
        //{
        //    IDBHelper context = new DBHelper();
        //    string sqlQuery = "[sp_master_bank_GetLooping]";
        //    context.CommandText = sqlQuery;
        //    context.CommandType = CommandType.StoredProcedure;
        //    return DBUtil.ExecuteMapper(context, new GroupDbo());
        //}


        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_log]
        /// </summary>        
        //public static Master_BankDbo Insert(Master_BankDbo obj)
        //{
        //    Random rdm = new Random();
        //    int NoRdm = rdm.Next(1, 1000);

        //    string Bank_id = "B" + NoRdm;

        //    IDBHelper context = new DBHelper();
        //    string sqlQuery = "sp_master_bank_Insert";
        //    context.AddParameter("@BankID", Bank_id);
        //    context.AddParameter("@Description", obj.Description);
        //    context.AddParameter("@Area", obj.Area);
        //    context.AddParameter("@Account", obj.Account);
        //    context.AddParameter("@Balance", obj.Balance);
        //    context.AddParameter("@account_name", obj.Account_Name);
        //    context.AddParameter("@COA", obj.COA);
        //    context.AddParameter("@create_date", DateTime.Now);
        //    context.AddParameter("@create_by", obj.create_by);
        //    context.CommandText = sqlQuery;
        //    context.CommandType = CommandType.StoredProcedure;
        //    return DBUtil.ExecuteMapper<Master_BankDbo>(context, new Master_BankDbo()).FirstOrDefault();
        //}

        //public static Master_BankDbo Update(Master_BankDbo obj,string isdelete)
        //{

        //    IDBHelper context = new DBHelper();
        //    context.AddParameter("@id", obj.id);
        //    context.AddParameter("@BankID", obj.BankID);
        //    context.AddParameter("@Description", obj.Description);
        //    context.AddParameter("@Area", obj.Area);
        //    context.AddParameter("@Account", obj.Account);
        //    context.AddParameter("@Balance", obj.Balance);
        //    context.AddParameter("@account_name", obj.Account_Name);
        //    context.AddParameter("@COA", obj.COA);
        //    context.AddParameter("@isdelete", isdelete);
        //    context.AddParameter("@update_by", obj.update_by);
        //    string sqlQuery = "[sp_master_bank_Update]";
        //    context.CommandText = sqlQuery;
        //    context.CommandType = CommandType.StoredProcedure;
        //    return DBUtil.ExecuteMapper<Master_BankDbo>(context, new Master_BankDbo()).FirstOrDefault();
        //}


        #endregion

    }
}
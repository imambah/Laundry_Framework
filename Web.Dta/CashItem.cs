
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using Web.Dto;
using System.Data;
namespace Web.Dta
{
    /// <summary>
    /// Dta Class of TABLE [Cashflow]
    /// </summary>    
    public partial class CashItem
    {
        public static List<CashDbo> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "sp_Cash_GetAll";
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper(context, new CashDbo());
        }

        public static CashDbo GetById(int id)
        {

            IDBHelper context = new DBHelper();
            context.CommandType = CommandType.StoredProcedure;
            context.CommandText = "[sp_Cash_GetById]";
            context.AddParameter("@id", id);
            return DBUtil.ExecuteMapper<CashDbo>(context, new CashDbo()).FirstOrDefault();
        }

        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_log]
        /// </summary>        
        public static CashDbo Insert(CashDbo obj)
        {

            IDBHelper context = new DBHelper();
            string sqlQuery = "[sp_Cash_Insert]";
            context.AddParameter("@Voucher_ID", obj.Voucher_ID);
            context.AddParameter("@Voucher_Desc", obj.Voucher_Desc);
            context.AddParameter("@PIC", obj.PIC);
            context.AddParameter("@Transaction_date", obj.Transaction_date);
            context.AddParameter("@keterangan_Cash", obj.BankID);
            context.AddParameter("@Amount", obj.Amount);
            context.AddParameter("@Voucher_Type", obj.Voucher_Type);
            context.AddParameter("@create_date", DateTime.Now);
            context.AddParameter("@create_by", obj.create_by);
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper<CashDbo>(context, new CashDbo()).FirstOrDefault();
        }

        public static CashDbo Update(CashDbo obj)
        {

            IDBHelper context = new DBHelper();
            context.AddParameter("@id", obj.id);
            context.AddParameter("@Voucher_ID", obj.Voucher_ID);
            context.AddParameter("@Voucher_Desc", obj.Voucher_Desc);
            context.AddParameter("@PIC", obj.PIC);
            context.AddParameter("@Transaction_date", obj.Transaction_date);
            context.AddParameter("@BankID", obj.BankID);
            context.AddParameter("@Amount", obj.Amount);
            context.AddParameter("@Voucher_Type", obj.Voucher_Type);
            context.AddParameter("@update_date", DateTime.Now);
            context.AddParameter("@update_by", obj.update_by);
            string sqlQuery = "[sp_Cash_Update]";
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper<CashDbo>(context, new CashDbo()).FirstOrDefault();
        }

        #endregion

        #region
        public static CashDbo GetMasterDetailByCode(string Voucher_ID)
        {
            CashDbo master = null;
            IDBHelper context = new DBHelper();
            context.CommandType = CommandType.StoredProcedure;
            context.CommandText = "[sp_Cash_Detail_GetByCode]";
            context.AddParameter("@Voucher_ID", Voucher_ID);
            //return DBUtil.ExecuteMapper<CashDetailDbo>(context, new CashDetailDbo()).FirstOrDefault();
            using (IDataReader reader = DBUtil.ExecuteReader(context))
            {
                while (reader.Read())
                {
                    master = new CashDbo().Map(reader);
                }
                if (master != null)
                {
                    if (reader.NextResult())
                    {
                        master.Details = new List<CashDetailDbo>();
                        while (reader.Read())
                        {

                            master.Details.Add(new CashDetailDbo().Map(reader));
                        }
                    }
                }
                // dah jalanin coba cak
            }

            return master;
        }

        public static CashDetailDbo InsertDetail(CashDetailDbo obj)
        {

            IDBHelper context = new DBHelper();
            string sqlQuery = "[sp_Cash_Detail_Insert]";
            context.AddParameter("@Voucher_ID", obj.Voucher_ID);
            context.AddParameter("@Description", obj.Description);
            context.AddParameter("@Value", obj.Value);
            context.AddParameter("@Category", obj.Category);
            context.AddParameter("@COA", obj.COA);
            //context.AddParameter("@create_date", DateTime.Now);
            //context.AddParameter("@create_by", "user_system");
            //context.AddParameter("@update_date", DateTime.Now);
            //context.AddParameter("@update_by", "user_system");
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper<CashDetailDbo>(context, new CashDetailDbo()).FirstOrDefault();
        }
        #endregion
    }
}
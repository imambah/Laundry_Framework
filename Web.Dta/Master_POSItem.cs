
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

        public static List<POSDbo> GetAll_ByBranchID(string strBranch_ID)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "[sp_pos_GetByBranch]";
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            context.AddParameter("@branchid", strBranch_ID);
            return DBUtil.ExecuteMapper(context, new POSDbo());
        }

        #region Data Access
       
        public static POSDbo Insert(POSDbo obj)
        {
            //Random rdm = new Random();
            //int NoRdm = rdm.Next(1, 1000);
            //var transId = obj.transaction_id + NoRdm;
            IDBHelper context = new DBHelper();
            string sqlQuery = "[sp_POS_Insert_Header]";
            context.AddParameter("@transaction_id", obj.transaction_id);
            context.AddParameter("@transaction_type", obj.transaction_type);
            context.AddParameter("@customer_id", obj.customerid);
            context.AddParameter("@customer_name", obj.customer_name);
            context.AddParameter("@customer_address", obj.customer_address);
            context.AddParameter("@customer_type", obj.customer_type);

            context.AddParameter("@jumlah_item", obj.jumlah_item);
            context.AddParameter("@Nilai", obj.nilai);
            context.AddParameter("@disc", obj.disc);
            context.AddParameter("@sub_total", obj.sub_total);

            context.AddParameter("@create_date", DateTime.Now);
            context.AddParameter("@create_by", obj.create_by);
            context.AddParameter("@branchid", obj.branchid);
            context.AddParameter("@estimasi_selesai", obj.estimasi_selesai);
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper<POSDbo>(context, new POSDbo()).FirstOrDefault();
        }

        public static POS_DetailDbo InsertDetail(POS_DetailDbo obj)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "[sp_POS_Insert_Detail]";
            context.AddParameter("@transaction_id", obj.transaction_id);
            context.AddParameter("@kode_item", obj.kode_item);
            context.AddParameter("@nama_item", obj.nama_item);

            context.AddParameter("@service_laundry_qty", obj.service_laundry_qty);
            context.AddParameter("@service_laundry_price", obj.service_laundry_price);
            context.AddParameter("@service_drycleaning_qty", obj.service_drycleaning_qty);
            context.AddParameter("@service_drycleaning_price", obj.service_drycleaning_price);

            context.AddParameter("@total_qty", obj.total_qty);
            context.AddParameter("@total_harga", obj.total_harga);
            context.AddParameter("@remarks", obj.remarks);
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper<POS_DetailDbo>(context, new POS_DetailDbo()).FirstOrDefault();
        }

        public static Service_PriceDbo GetPrice(string id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "sp_POS_GetPrice_ById";
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            context.AddParameter("@id", id);
            return DBUtil.ExecuteMapper<Service_PriceDbo>(context, new Service_PriceDbo()).FirstOrDefault();

        } 
        public static PosDetailPriceDbo GetPriceDetail(string transaction_id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "sp_POS_GetPriceDetail_ByTransactionID";
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            context.AddParameter("@transaction_id", transaction_id);
            return DBUtil.ExecuteMapper<PosDetailPriceDbo>(context, new PosDetailPriceDbo()).FirstOrDefault();

        }

        public static List<POS_TransactionDbo> Get_POSTransaction(string id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "[sp_POS_GetTransaction_ByID]";
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            context.AddParameter("@id", id);
            return DBUtil.ExecuteMapper(context, new POS_TransactionDbo());

            //return DBUtil.ExecuteMapper<Service_PriceDbo>(context, new Service_PriceDbo()).FirstOrDefault();
        }
        #endregion
        public static List<POS_TransactionDbo> Get_POSTransaction_Selesai(string id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "[sp_POS_GetTransaction_ByID_selesai]";
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            context.AddParameter("@id", id);
            return DBUtil.ExecuteMapper(context, new POS_TransactionDbo());

            //return DBUtil.ExecuteMapper<Service_PriceDbo>(context, new Service_PriceDbo()).FirstOrDefault();
        }
        public static POS_TransactionDbo Update(string transactionid, string update_by, string disc , string ppn, string grandtotal)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "[sp_POS_Proses_Selesai]";
            context.AddParameter("@transaction_id", transactionid);
            context.AddParameter("@disc", disc);
            context.AddParameter("@ppn", ppn);
            context.AddParameter("@grand_total", grandtotal);
            context.AddParameter("@finishedby", update_by);
            context.AddParameter("@update_by", update_by);
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper<POS_TransactionDbo>(context, new POS_TransactionDbo()).FirstOrDefault();
        }

        public static POS_DetailDbo UpdateItem(POS_DetailDbo obj)
        {
            IDBHelper context = new DBHelper();
            context.AddParameter("@id_Item", obj.kode_item);
            context.AddParameter("@transaction_id", obj.transaction_id);
            context.AddParameter("@service_laundry_qty", obj.service_laundry_qty);
            context.AddParameter("@service_laundry_price", obj.service_laundry_price);
            context.AddParameter("@service_drycleaning_qty", obj.service_drycleaning_qty);
            context.AddParameter("@service_drycleaning_price", obj.service_drycleaning_price);
            context.AddParameter("@total_qty", obj.total_qty);
            context.AddParameter("@total_harga", obj.total_harga);
            context.AddParameter("@remarks", obj.remarks);
            string sqlQuery = "[sp_POS_Update_Item]";
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper<POS_DetailDbo>(context, new POS_DetailDbo()).FirstOrDefault();
        }
    }
}
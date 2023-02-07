
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



        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tabel POS]
        /// </summary>        
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
            context.AddParameter("@create_date", DateTime.Now);
            context.AddParameter("@create_by", "user_system");
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
# endregion

    }
}
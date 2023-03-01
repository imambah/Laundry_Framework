
using DataAccessLayer;
using System;
namespace Web.Dto
{
    public class POS_TransactionDbo : IDataMapper<POS_TransactionDbo>
    {
    
        public string transaction_id { get; set; }
        public string transaction_date { get; set; }
        public string transaction_type { get; set; }
        public string customerid { get; set; }
        public string customer_name { get; set; }
        public string customer_address { get; set; }
        public string customer_type { get; set; }
        public string room { get; set; }
        public string jumlah_item { get; set; }
        public string Nilai { get; set; }
        public string subtotal { get; set; }
        public string ppn { get; set; }
        public string grand_total { get; set; }

        //==========Detail =============================================================

        public string nama_item { get; set; }
        public int service_laundry_qty { get; set; }
        public decimal service_laundry_price { get; set; }
        public int service_drycleaning_qty { get; set; }
        public decimal service_drycleaning_price { get; set; }
        public string total_harga { get; set; }
        public string subtotal_qty { get; set; }
        public string remarks { get; set; }
        public string receiveddate { get; set; }
        public string finishdate { get; set; }


        public POS_TransactionDbo Map(System.Data.IDataReader reader)
        {
            POS_TransactionDbo obj = new POS_TransactionDbo();
            obj.transaction_id = reader["transaction_id"].ToString();
            obj.transaction_date = reader["transaction_date"].ToString();
            obj.transaction_type = reader["transaction_type"].ToString();
            obj.customerid = reader["customerid"].ToString();
            obj.customer_name = reader["customer_name"].ToString();
            obj.customer_address = reader["customer_address"].ToString();
            obj.customer_type = reader["customer_type"].ToString();
            obj.room = reader["room"].ToString();
            obj.jumlah_item = reader["jumlah_item"].ToString();
            obj.Nilai = reader["Nilai"].ToString();
            obj.subtotal = reader["sub_total"].ToString();
            obj.ppn = reader["ppn"].ToString();
            obj.grand_total = reader["grand_total"].ToString();

            obj.nama_item = reader["nama_item"].ToString();
            obj.service_laundry_qty = reader["service_laundry_qty"] == DBNull.Value ? 0 : Convert.ToInt32(reader["service_laundry_qty"]);
            obj.service_laundry_price = reader["service_laundry_price"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["service_laundry_price"]);
            obj.service_drycleaning_qty = reader["service_drycleaning_qty"] == DBNull.Value ? 0 : Convert.ToInt32(reader["service_drycleaning_qty"]);
            obj.service_drycleaning_price = reader["service_drycleaning_price"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["service_drycleaning_price"]);
            obj.total_harga = reader["total_harga"].ToString();
            obj.subtotal_qty = reader["subtotal_qty"].ToString(); 
            obj.remarks = reader["remarks"].ToString();
            obj.receiveddate = reader["receiveddate"].ToString();
            obj.finishdate = reader["finishdate"].ToString();
            return obj;
        }
    }




}




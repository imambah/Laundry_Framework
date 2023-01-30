
using DataAccessLayer;
using System;
namespace Web.Dto
{
    public class POSDbo : IDataMapper<POSDbo>
    {
        public int id { get; set; }
        public string branchid { get; set; }
        public string transaction_id { get; set; }
        public DateTime? transaction_date { get; set; }
        public string transaction_type { get; set; }
        public string customerid { get; set; }
        public string customer_name { get; set; }
        public string customer_address { get; set; }
        public string customer_type { get; set; }
        public string room { get; set; }
        public int jumlah_item { get; set; }
        public decimal nilai { get; set; }
        public decimal disc { get; set; }
        public decimal sub_total { get; set; }
        public decimal ppn { get; set; }
        public double grand_total { get; set; }
        public string invoiced { get; set; }
        public DateTime? receiveddate { get; set; }
        public DateTime? finishdate { get; set; }
        public string received_by { get; set; }
        public string delivery_date { get; set; }
        public string finish_by { get; set; }
        public DateTime? create_date { get; set; }
        public string create_by { get; set; }
        public DateTime? update_date { get; set; }
        public string update_by { get; set; }
        public POSDbo Map(System.Data.IDataReader reader)
        {
            POSDbo obj = new POSDbo();
            obj.id = Convert.ToInt32(reader["id"]);
            obj.branchid = reader["branchid"].ToString();
            obj.transaction_id = reader["transaction_id"].ToString();
            obj.transaction_date = reader["transaction_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["transaction_date"]);
            obj.transaction_type = reader["transaction_type"].ToString();

            obj.customerid = reader["customerid"].ToString();
            obj.customer_name = reader["customer_name"].ToString();
            obj.customer_address = reader["customer_address"].ToString();
            obj.customer_type = reader["customer_type"].ToString();

            obj.room = reader["room"].ToString();
            obj.jumlah_item = Convert.ToInt32(reader["jumlah"]);
            obj.nilai = Convert.ToDecimal(reader["harga"]);
            obj.disc = Convert.ToDecimal(reader["disc"]);

            obj.sub_total = Convert.ToDecimal(reader["sub_total"]);
            obj.ppn = Convert.ToDecimal(reader["ppn"]);
            obj.grand_total = Convert.ToDouble(reader["grand_total"]);
            obj.invoiced =reader["metode_bayar"].ToString();

           
            obj.finishdate = reader["finishdate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["finishdate"]);
            obj.receiveddate = reader["receiveddate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["receiveddate"]);
            obj.received_by= reader["received_by"].ToString();

            obj.create_date = reader["create_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["create_date"]);
            obj.create_by = reader["create_by"].ToString();

            obj.update_date = reader["update_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["update_date"]);
            obj.update_by = reader["update_by"].ToString();
            return obj;
        }
    }




}




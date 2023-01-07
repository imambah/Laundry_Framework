
using DataAccessLayer;
using System;
namespace Web.Dto
{
    public class POSDbo : IDataMapper<POSDbo>
    {
        public int id { get; set; }
        public string transaction_id { get; set; }
        public DateTime? transaction_date { get; set; }
        public string customer_id { get; set; }
        public string customer_name { get; set; }
        public string kode_BOM { get; set; }
        public int jumlah { get; set; }
        public double harga { get; set; }
        public decimal disc { get; set; }
        public double sub_total { get; set; }
        public decimal ppn { get; set; }
        public double grand_total { get; set; }
        public int metode_bayar { get; set; }
        public DateTime? create_date { get; set; }
        public string create_by { get; set; }
        public POSDbo Map(System.Data.IDataReader reader)
        {
            POSDbo obj = new POSDbo();
            obj.id = Convert.ToInt32(reader["id"]);
            obj.transaction_id = reader["transaction_id"].ToString();
            obj.transaction_date = reader["create_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["create_date"]);
            obj.customer_id = reader["customerid"].ToString();
            obj.customer_name = reader["customer_name"].ToString();
            
            obj.kode_BOM = reader["kode_BOM"].ToString();
            obj.jumlah = Convert.ToInt32(reader["jumlah"]);
            obj.harga = Convert.ToDouble(reader["harga"]);
            obj.disc = Convert.ToDecimal(reader["disc"]);

            obj.sub_total = Convert.ToDouble(reader["sub_total"]);
            obj.ppn = Convert.ToDecimal(reader["ppn"]);
            obj.grand_total = Convert.ToDouble(reader["grand_total"]);
            obj.metode_bayar = Convert.ToInt32(reader["metode_bayar"]);

            obj.create_date = reader["create_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["create_date"]);
            obj.create_by = reader["create_by"].ToString();
            return obj;
        }
    }




}




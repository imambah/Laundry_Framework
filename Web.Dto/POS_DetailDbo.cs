
using DataAccessLayer;
using System;
namespace Web.Dto
{
    public class POS_DetailDbo : IDataMapper<POS_DetailDbo>
    {
        public int id { get; set; }
        public string transaction_id { get; set; }
        public string kode_item { get; set; }
        public string nama_item { get; set; }
        public int service_laundry_qty { get; set; }
        public decimal service_laundry_price { get; set; }
        public int service_drycleaning_qty { get; set; }
        public decimal service_drycleaning_price { get; set; }
        public int total_qty { get; set; }
        public decimal total_harga { get; set; }
        public string remarks { get; set; }
       
        public POS_DetailDbo Map(System.Data.IDataReader reader)
        {
            POS_DetailDbo obj = new POS_DetailDbo();
            obj.id = Convert.ToInt32(reader["id"]);
            obj.transaction_id = reader["transaction_id"].ToString();
            obj.kode_item = reader["kode_item"].ToString();
            obj.nama_item = reader["nama_item"].ToString();

            obj.service_laundry_qty = reader["service_laundry_qty"] == DBNull.Value ? 0 : Convert.ToInt32(reader["service_laundry_qty"]);
            obj.service_laundry_price = reader["service_laundry_price"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["service_laundry_price"]);
           
            obj.service_drycleaning_qty = reader["service_drycleaning_qty"] == DBNull.Value ? 0 : Convert.ToInt32(reader["service_drycleaning_qty"]);
            obj.service_drycleaning_price = reader["service_drycleaning_price"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["service_drycleaning_price"]);
            
            obj.total_qty = reader["total_qty"] == DBNull.Value ? 0 : Convert.ToInt32(reader["total_qty"]);
            obj.total_harga = reader["total_harga"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["total_harga"]);
            obj.remarks = reader["remarks"].ToString();
            return obj;
        }
    }




}





using DataAccessLayer;
using System;
namespace Web.Dto
{
	public class Master_Klien : IDataMapper<Master_Klien>
	{

		public int id { get; set; }
        public string kode_klien { get; set; }
        public string nama_klien { get; set; }
        public string alamat { get; set; }
        public string alamat2 { get; set; }
        public string kota { get; set; }
        public string area { get; set; }
        public string negara { get; set; }
        public string kodepos { get; set; }
        public string no_telp { get; set; }
        public string email { get; set; }
        public string PIC { get; set; }
        public string tax_id { get; set; }
        public string tax_name { get; set; }
        public string tax_address { get; set; }
        public string bank_account { get; set; }
        public string bank_name { get; set; }
        public string bank_branch { get; set; }
        public string credit_limit { get; set; }
        public bool is_supplier { get; set; }
        public bool is_customer { get; set; }
        public DateTime ? create_date{ get; set; }
		public string create_by { get; set; }
		public DateTime ? update_date { get; set; }
		public string update_by { get; set; }

        public Master_Klien Map(System.Data.IDataReader reader)
        {
            Master_Klien obj = new Master_Klien();
            obj.id = Convert.ToInt32(reader["id"]);
            obj.kode_klien = reader["kode_klien"].ToString();
            obj.nama_klien = reader["nama_klien"].ToString();
            obj.alamat = reader["alamat"].ToString();
            obj.no_telp = reader["no_telp"].ToString();
            obj.is_supplier = Convert.ToBoolean(reader["is_supplier"]);
            obj.is_customer = Convert.ToBoolean(reader["is_customer"]); 
            obj.create_date = reader["create_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["create_date"]);
            obj.create_by = reader["create_by"].ToString();
            obj.update_date = reader["update_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["update_date"]);
            obj.update_by = reader["update_by"].ToString();
            return obj;
        }
    }

}





using DataAccessLayer;
using System;
namespace Web.Dto
{
	public class Master_ContractDbo : IDataMapper<Master_ContractDbo>
	{

		public int id { get; set; }
        public string Kode_Klien { get; set; }
        public string Nama_Klien { get; set; }
        public string Kode_layanan { get; set; }
        public string Nama_layanan { get; set; }
        public string Harga { get; set; }       
        public DateTime ? create_date{ get; set; }
		public string create_by { get; set; }
		public DateTime ? update_date { get; set; }
		public string update_by { get; set; }
        public int is_delete { get; set; }

        public Master_ContractDbo Map(System.Data.IDataReader reader)
        {
            Master_ContractDbo obj = new Master_ContractDbo();
            obj.id = Convert.ToInt32(reader["id"]);
            obj.Kode_Klien = reader["Kode_Klien"].ToString();
            obj.Nama_Klien = reader["Nama_Klien"].ToString();
            obj.Kode_layanan = reader["Kode_layanan"].ToString();
            obj.Nama_layanan= reader["Nama_layanan"].ToString();
            obj.Harga = reader["Harga"].ToString();
            obj.create_date = reader["create_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["create_date"]);
            obj.create_by = reader["create_by"].ToString();
            obj.update_date = reader["update_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["update_date"]);
            obj.update_by = reader["update_by"].ToString();
            obj.is_delete = reader["is_delete"] == DBNull.Value ? 0 : Convert.ToInt32(reader["is_delete"]);
            return obj;
        }
    }

}




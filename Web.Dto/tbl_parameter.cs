
using DataAccessLayer;
using System;
namespace Web.Dto
{
	public class tbl_parameter : IDataMapper<tbl_parameter>
	{
		public int id { get; set; }

		public string nama_tabel { get; set; }

		public string kode_tabel { get; set; }

		public string nama_panjang { get; set; }

		public string nama_pendek { get; set; }

		public int? nilai { get; set; }

		public DateTime ? create_date{ get; set; }
		public string create_by { get; set; }
		public DateTime ? update_date { get; set; }
		public string update_by { get; set; }

		public int is_delete { get; set; }

		public tbl_parameter Map(System.Data.IDataReader reader)
		{
			tbl_parameter obj = new tbl_parameter();
			obj.id = Convert.ToInt32(reader["id"]);
			obj.nama_tabel = reader["nama_tabel"].ToString();
			obj.kode_tabel = reader["kode_tabel"].ToString();
			obj.nama_panjang = reader["nama_panjang"].ToString();
			obj.nama_pendek = reader["nama_pendek"].ToString();
			obj.nilai = (reader["nilai"] is System.DBNull) ? 0 : Convert.ToInt32(reader["nilai"]);
			obj.create_date = reader["create_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["create_date"]);
			obj.create_by = reader["create_by"].ToString();
			obj.update_date = reader["update_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["update_date"]);
			obj.update_by = reader["update_by"].ToString();
			obj.is_delete = reader["is_delete"] == DBNull.Value ? 0 : Convert.ToInt32(reader["is_delete"]);
			return obj;
		}
	}

}





using DataAccessLayer;
using System;
namespace Web.Dto
{
	public class Master_SupplierDbo : IDataMapper<Master_SupplierDbo>
	{

		public int id { get; set; }
        public string kode_suplier { get; set; }
        public string nama_suplier { get; set; }
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
        public int is_delete { get; set; }
        public string status { get; set; }
        public string COA { get; set; }
        public string TOP { get; set; }
        public double margin { get; set; }
        public DateTime ? create_date{ get; set; }
		public string create_by { get; set; }
		public DateTime ? update_date { get; set; }
		public string update_by { get; set; }
       

        public Master_SupplierDbo Map(System.Data.IDataReader reader)
        {
            Master_SupplierDbo obj = new Master_SupplierDbo();
            obj.id = Convert.ToInt32(reader["id"]);
            obj.kode_suplier = reader["kode_suplier"].ToString();
            obj.nama_suplier = reader["nama_suplier"].ToString();
            obj.alamat = reader["alamat"].ToString();
            obj.alamat2 = reader["alamat2"].ToString();
            obj.kota = reader["kota"].ToString();
            obj.area = reader["area"].ToString();
            obj.negara = reader["negara"].ToString();
            obj.kodepos = reader["kodepos"].ToString();
            obj.no_telp = reader["no_telp"].ToString();
            obj.email = reader["email"].ToString();
            obj.PIC = reader["pic"].ToString();
            obj.tax_id = reader["tax_id"].ToString();
            obj.tax_name = reader["tax_name"].ToString();
            obj.tax_address = reader["tax_address"].ToString();
            obj.bank_account = reader["bank_account"].ToString();
            obj.bank_name = reader["bank_name"].ToString();
            obj.bank_branch = reader["bank_branch"].ToString();
            obj.status = reader["status"].ToString();
            obj.COA = reader["COA"].ToString();
            obj.TOP = reader["TOP"].ToString();
            obj.margin = Convert.ToDouble(reader["margin"]); 
            obj.create_date = reader["create_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["create_date"]);
            obj.create_by = reader["create_by"].ToString();
            obj.update_date = reader["update_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["update_date"]);
            obj.update_by = reader["update_by"].ToString();
            obj.is_delete = reader["is_delete"] == DBNull.Value ? 0 : Convert.ToInt32(reader["is_delete"]);
            return obj;
        }
    }

}




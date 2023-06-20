
using DataAccessLayer;
using System;
namespace Web.Dto
{
	public class VoucherDbo : IDataMapper<VoucherDbo>
	{

		public int id { get; set; }
        public string voucher_code { get; set; }
        public DateTime ? voucher_date{ get; set; }
		public string description { get; set; }
		public double nominal { get; set; }
        public string status { get; set; }
        public DateTime? create_date { get; set; }
        public string create_by { get; set; }
        public DateTime? update_date { get; set; }
        public string update_by { get; set; }

        public VoucherDbo Map(System.Data.IDataReader reader)
        {
            VoucherDbo obj = new VoucherDbo();
            obj.id = Convert.ToInt32(reader["id"]);
            obj.voucher_code = reader["voucher_code"].ToString();
            obj.voucher_date = reader["voucher_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["voucher_date"]);
            obj.description = reader["description"].ToString();
            obj.nominal = Convert.ToDouble(reader["nominal"]);
            obj.status = reader["status"].ToString();
            obj.create_by = reader["create_by"].ToString();
            obj.create_date = reader["create_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["create_date"]);
            obj.update_by = reader["update_by"].ToString();
            obj.update_date = reader["update_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["update_date"]);
            return obj;
        }
    }

}




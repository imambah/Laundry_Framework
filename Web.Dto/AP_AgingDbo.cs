
using DataAccessLayer;
using System;
namespace Web.Dto
{
	public class AP_AgingDbo : IDataMapper<AP_AgingDbo>
	{
        public string cabang { get; set; }
        public string supplier_id { get; set; }
        public string supplier_name { get; set; }
        public decimal amt { get; set; }
        public decimal curr { get; set; }
        public decimal a0130 { get; set; }
        public decimal a3160 { get; set; }
        public decimal a6190 { get; set; }
        public decimal a91 { get; set; }
        public string gr_no { get; set; }
        public DateTime? gr_date { get; set; }
        public DateTime? due_date { get; set; }

        public AP_AgingDbo Map(System.Data.IDataReader reader)
        {
            AP_AgingDbo obj = new AP_AgingDbo();
            obj.cabang = reader["cabang"].ToString();
            obj.supplier_id = reader["supplier_id"].ToString();
            obj.supplier_name = reader["supplier_name"].ToString();
            obj.amt = reader["amt"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["amt"]);
            obj.curr = reader["curr"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["curr"]);
            obj.a0130 = reader["a30"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["a30"]);
            obj.a3160 = reader["a60"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["a60"]);
            obj.a6190 = reader["a90"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["a90"]);
            obj.a91 = reader["a91"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["a91"]);
            obj.gr_no = reader["gr_no"].ToString();
            obj.gr_date = reader["gr_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["gr_date"]);
            obj.due_date = reader["due_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["due_date"]);
            return obj;
        }
    }

}




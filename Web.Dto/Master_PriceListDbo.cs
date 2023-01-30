
using DataAccessLayer;
using System;
namespace Web.Dto
{
    public class Master_PricelistDbo : IDataMapper<Master_PricelistDbo>
    {
        public int id { get; set; }
        public string type { get; set; }
        public string service { get; set; }
        public double laundry { get; set; }
        public double dry_clean { get; set; }
        public int is_delete { get; set; }
        public int qty { get; set; }
        public DateTime? create_date { get; set; }
        public string create_by { get; set; }
        public DateTime? update_date { get; set; }
        public string update_by { get; set; }
        public Master_PricelistDbo Map(System.Data.IDataReader reader)
        {
            Master_PricelistDbo obj = new Master_PricelistDbo();
            obj.id = Convert.ToInt32(reader["id"]);
            obj.type = reader["type"].ToString();
            obj.service= reader["service"].ToString();
            obj.laundry = reader["laundry"] == DBNull.Value ? 0 : Convert.ToDouble(reader["laundry"]);
            obj.dry_clean = reader["dry_clean"] == DBNull.Value ? 0 : Convert.ToDouble(reader["dry_clean"]);
            obj.is_delete = reader["is_delete"] == DBNull.Value ? 0 : Convert.ToInt32(reader["is_delete"]);
            obj.qty = reader["qty"] == DBNull.Value ? 0 : Convert.ToInt32(reader["qty"]);
            obj.create_date = reader["create_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["create_date"]);
            obj.create_by = reader["create_by"].ToString();
            obj.update_date = reader["update_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["update_date"]);
            obj.update_by = reader["update_by"].ToString();
            return obj;
        }
    }




}




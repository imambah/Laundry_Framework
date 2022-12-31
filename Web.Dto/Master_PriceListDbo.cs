
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


        public Master_PricelistDbo Map(System.Data.IDataReader reader)
        {
            Master_PricelistDbo obj = new Master_PricelistDbo();
            obj.id = Convert.ToInt32(reader["id"]);
            obj.type = reader["type"].ToString();
            obj.service= reader["service"].ToString();
            obj.laundry = reader["laundry"] == DBNull.Value ? 0 : Convert.ToDouble(reader["laundry"]);
            obj.dry_clean = reader["dry_clean"] == DBNull.Value ? 0 : Convert.ToDouble(reader["dry_clean"]);
            return obj;
        }
    }




}




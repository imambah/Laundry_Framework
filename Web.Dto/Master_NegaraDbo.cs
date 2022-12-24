
using DataAccessLayer;
using System;
namespace Web.Dto
{
    public class Master_NegaraDbo : IDataMapper<Master_NegaraDbo>
    {
        public int id { get; set; }
        public string nation_name { get; set; }

        public Master_NegaraDbo Map(System.Data.IDataReader reader)
        {
            Master_NegaraDbo obj = new Master_NegaraDbo();
            obj.id = Convert.ToInt32(reader["id"]);
            obj.nation_name = reader["nation_name"].ToString();
            return obj;
        }
    }




}




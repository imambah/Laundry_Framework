
using DataAccessLayer;
using System;
namespace Web.Dto
{
    public class BOMDetailDbo : IDataMapper<BOMDetailDbo>
    {
        public int id { get; set; }
        public string kode_BOM { get; set; }
        public string item_code { get; set; }
        public double jumlah { get; set; }
      
        public BOMDetailDbo Map(System.Data.IDataReader reader)
        {
            BOMDetailDbo obj = new BOMDetailDbo();
            obj.id = Convert.ToInt32(reader["id"]);
            obj.kode_BOM = reader["kode_BOM"].ToString();
            obj.item_code = reader["item_code"].ToString();
            obj.jumlah = reader["jumlah"] == DBNull.Value ? 0 : Convert.ToDouble(reader["jumlah"]);
                      
            return obj;
        }
    }




}




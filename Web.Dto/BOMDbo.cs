
using DataAccessLayer;
using System;
namespace Web.Dto
{
    public class BOMDbo : IDataMapper<BOMDbo>
    {
        public int id { get; set; }
        public string kode_BOM { get; set; }
        public string keterangan_BOM { get; set; }
        public double harga_jual { get; set; }
        
        public BOMDbo Map(System.Data.IDataReader reader)
        {
            BOMDbo obj = new BOMDbo();
            obj.id = Convert.ToInt32(reader["id"]);
            obj.kode_BOM = reader["kode_BOM"].ToString();
            obj.keterangan_BOM = reader["keterangan_BOM"].ToString();
            obj.harga_jual = Convert.ToDouble(reader["harga_jual"]);
            return obj;
        }
    }




}




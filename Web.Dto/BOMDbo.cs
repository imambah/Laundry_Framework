
using DataAccessLayer;
using System;
using System.Collections.Generic;

namespace Web.Dto
{
    public class BOMDbo : IDataMapper<BOMDbo>
    {
        public int id { get; set; }
        public string kode_BOM { get; set; }
        public string keterangan_BOM { get; set; }
        public double harga_jual { get; set; }
        public DateTime? create_date { get; set; }
        public string create_by { get; set; }
        public DateTime? update_date { get; set; }
        public string update_by { get; set; }

        public List<BOMDetailDbo> Details { get; set; }

        public BOMDbo Map(System.Data.IDataReader reader)
        {
            BOMDbo obj = new BOMDbo();
            obj.id = Convert.ToInt32(reader["id"]);
            obj.kode_BOM = reader["kode_BOM"].ToString();
            obj.keterangan_BOM = reader["keterangan_BOM"].ToString();
            obj.harga_jual = Convert.ToDouble(reader["harga_jual"]);
            obj.create_date = reader["create_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["create_date"]);
            obj.create_by = reader["create_by"].ToString();
            obj.update_date = reader["update_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["update_date"]);
            obj.update_by = reader["update_by"].ToString();
            return obj;
        }
    }




}




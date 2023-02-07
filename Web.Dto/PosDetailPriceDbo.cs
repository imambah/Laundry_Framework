
using DataAccessLayer;
using System;
namespace Web.Dto
{
    public class PosDetailPriceDbo : IDataMapper<PosDetailPriceDbo>
    {

        public int jumlah_qty { get; set; }
        public decimal jumlah_nilai { get; set; }
        public decimal disc { get; set; }

        public PosDetailPriceDbo Map(System.Data.IDataReader reader)
        {
            PosDetailPriceDbo obj = new PosDetailPriceDbo();
            obj.jumlah_qty = reader["jumlah_qty"] == DBNull.Value ? 0 : Convert.ToInt32(reader["jumlah_qty"]);
            obj.jumlah_nilai = reader["jumlah_nilai"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["jumlah_nilai"]);
            obj.disc = reader["disc"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["disc"]); 
            return obj;
        }
    }




}




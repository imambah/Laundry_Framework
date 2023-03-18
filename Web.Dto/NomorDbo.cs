
using DataAccessLayer;
using System;
namespace Web.Dto
{
	public class NomorDbo : IDataMapper<NomorDbo>
	{

     
        public int tahun { get; set; }
        public int bulan { get; set; }
        public int nomer { get; set; }
        public NomorDbo Map(System.Data.IDataReader reader)
        {
            NomorDbo obj = new NomorDbo();
            obj.tahun = Convert.ToInt32(reader["tahun"]);
            obj.bulan = Convert.ToInt32(reader["bulan"]);
            obj.nomer = Convert.ToInt32(reader["nomer"]);
            return obj;
        }
    }

}




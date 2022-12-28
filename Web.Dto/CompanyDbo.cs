
using DataAccessLayer;
using System;
namespace Web.Dto
{
    public class CompanyDbo : IDataMapper<CompanyDbo>
    {
        public int id { get; set; }
        public string nama_tabel { get; set; }
        public string kode_tabel { get; set; }
        public string nama_panjang { get; set; }
        public string nama_pendek { get; set; }


        public CompanyDbo Map(System.Data.IDataReader reader)
        {
            CompanyDbo obj = new CompanyDbo();
            obj.id = Convert.ToInt32(reader["id"]);
            obj.nama_tabel = reader["nama_tabel"].ToString();
            obj.kode_tabel = reader["kode_tabel"].ToString();
            obj.nama_panjang = reader["nama_panjang"].ToString();
            obj.nama_pendek = reader["nama_pendek"].ToString();
            return obj;
        }
    }




}




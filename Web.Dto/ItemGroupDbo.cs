
using DataAccessLayer;
using System;
namespace Web.Dto
{
    public class ItemGroupDbo : IDataMapper<ItemGroupDbo>
    {
        public int id { get; set; }
        public string nama_tabel { get; set; }
        public string kode_tabel { get; set; }
        public string nama_panjang { get; set; }
        public string nama_pendek { get; set; }

        public ItemGroupDbo Map(System.Data.IDataReader reader)
        {
            ItemGroupDbo obj = new ItemGroupDbo();
            obj.id = Convert.ToInt32(reader["id"]);
            obj.nama_tabel = reader["nama_tabel"] == DBNull.Value ? null : reader["nama_tabel"].ToString();
            obj.kode_tabel = reader["kode_tabel"] == DBNull.Value ? null : reader["kode_tabel"].ToString();
            obj.nama_panjang = reader["nama_panjang"] == DBNull.Value ? null : reader["nama_panjang"].ToString();
            obj.nama_pendek = reader["nama_pendek"] == DBNull.Value ? null : reader["nama_pendek"].ToString();

            return obj;
        }
    }




}




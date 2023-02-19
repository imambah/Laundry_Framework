
using DataAccessLayer;
using System;
namespace Web.Dto
{
    public class Master_COADbo : IDataMapper<Master_COADbo>
    {
        public int id { get; set; }
        public string kode_COA { get; set; }
        public string nama_COA { get; set; }
        public string DRCR { get; set; }
        public int kelompok_COA { get; set; }
        public string nama_kelompok_COA { get; set; }
        public int sub_gl { get; set; }
        public string nama_sub_gl { get; set; }
        public int level_COA { get; set; }
        public string nama_level_COA { get; set; }

        public DateTime? create_date { get; set; }
        public string create_by { get; set; }
        public DateTime? update_date { get; set; }
        public string update_by { get; set; }
        public int is_delete { get; set; }
        public Master_COADbo Map(System.Data.IDataReader reader)
        {
            Master_COADbo obj = new Master_COADbo
            {
                id = Convert.ToInt32(reader["id"]),
                kode_COA = reader["kode_COA"].ToString(),
                nama_COA = reader["nama_COA"].ToString(),
                DRCR = reader["DRCR"].ToString(),
                sub_gl = reader["sub_gl"] == DBNull.Value ? 0 : Convert.ToInt32(reader["sub_gl"]),
                level_COA = reader["level_COA"] == DBNull.Value ? 0 : Convert.ToInt32(reader["level_COA"]),
                kelompok_COA = reader["kelompok_COA"] == DBNull.Value ? 0 : Convert.ToInt32(reader["kelompok_COA"]),
                nama_kelompok_COA = reader["nama_kelompok_COA"].ToString(),
                nama_sub_gl = reader["nama_sub_gl"].ToString(),
                nama_level_COA = reader["nama_level_COA"].ToString(),
                is_delete = reader["is_delete"] == DBNull.Value ? 0 : Convert.ToInt32(reader["is_delete"]),
                create_date = reader["create_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["create_date"]),
                create_by = reader["create_by"].ToString(),
                update_date = reader["update_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["update_date"]),
                update_by = reader["update_by"].ToString()
            };

            return obj;
        }
    }




}




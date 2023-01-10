
using DataAccessLayer;
using System;
namespace Web.Dto
{
    public class Master_BarangDbo : IDataMapper<Master_BarangDbo>
    {
        public int id { get; set; }
        public string ItemCode { get; set; }
        public string ItemDesc { get; set; }
        public string Barcode { get; set; }
        public string Group_Code { get; set; }
        public string Group_Desc { get; set; }
        public string UoM { get; set; }
        public double Price_Purchase { get; set; }
        public double Price_Inventory { get; set; }
        public string Stock { get; set; }
        public string Buffer_Stock { get; set; }
        public string Company_Persentage { get; set; }
        public string Vat_Flag { get; set; }
        public string Conversion { get; set; }
        public string BatchNo { get; set; }

        public DateTime? create_date { get; set; }
        public string create_by { get; set; }
        public DateTime? update_date { get; set; }
        public string update_by { get; set; }

        public Master_BarangDbo Map(System.Data.IDataReader reader)
        {
            Master_BarangDbo obj = new Master_BarangDbo();
            obj.id = Convert.ToInt32(reader["id"]);
            obj.ItemCode = reader["ItemCode"].ToString();
            obj.ItemDesc = reader["ItemDesc"].ToString();
            obj.Barcode = reader["Barcode"].ToString();
            obj.Group_Code = reader["Group_Code"] == DBNull.Value ? null : reader["Group_Code"].ToString();
            obj.UoM = reader["UoM"].ToString();
            obj.Buffer_Stock = reader["Buffer_Stock"].ToString();
            obj.Vat_Flag = reader["Vat_Flag"].ToString();
            obj.Conversion = reader["Conversion"].ToString();
            obj.BatchNo = reader["BatchNo"].ToString();
            obj.create_date = reader["create_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["create_date"]);
            obj.create_by = reader["create_by"].ToString();
            obj.update_date = reader["update_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["update_date"]);
            obj.update_by = reader["update_by"].ToString();
            obj.Group_Desc = reader["Group_Desc"].ToString();
            return obj;
        }
    }




}




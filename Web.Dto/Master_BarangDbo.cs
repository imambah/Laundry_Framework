
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
        public decimal Stock { get; set; }
        public decimal Buffer_Stock { get; set; }
        public string Vat_Flag { get; set; }
        public string Conversion { get; set; }
        public string BatchNo { get; set; }

        public DateTime? create_date { get; set; }
        public string create_by { get; set; }
        public DateTime? update_date { get; set; }
        public string update_by { get; set; }
        public int is_delete { get; set; }
        public Master_BarangDbo Map(System.Data.IDataReader reader)
        {
            Master_BarangDbo obj = new Master_BarangDbo();
            obj.id = Convert.ToInt32(reader["id"]);
            obj.ItemCode = reader["ItemCode"] == DBNull.Value ? null : reader["ItemCode"].ToString();
            obj.ItemDesc = reader["ItemDesc"] == DBNull.Value ? null : reader["ItemDesc"].ToString();
            obj.Barcode = reader["Barcode"] == DBNull.Value ? null : reader["Barcode"].ToString();
            obj.Group_Code = reader["Group_Code"] == DBNull.Value ? null : reader["Group_Code"].ToString();
            obj.UoM = reader["UoM"] == DBNull.Value ? null : reader["UoM"].ToString();
            obj.Stock = reader["Stock"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Stock"]);
            obj.Buffer_Stock = reader["Buffer_Stock"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Buffer_Stock"]); 
            obj.Vat_Flag = reader["Vat_Flag"] == DBNull.Value ? null : reader["Vat_Flag"].ToString();
            obj.Conversion = reader["Conversion"] == DBNull.Value ? null : reader["Conversion"].ToString();
            obj.BatchNo = reader["BatchNo"] == DBNull.Value ? null : reader["BatchNo"].ToString();
            obj.is_delete = reader["is_delete"] == DBNull.Value ? 0 : Convert.ToInt32(reader["is_delete"]);
            obj.create_date = reader["create_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["create_date"]);
            obj.create_by = reader["create_by"] == DBNull.Value ? null : reader["create_by"].ToString();
            obj.update_date = reader["update_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["update_date"]);
            obj.update_by = reader["update_by"] == DBNull.Value ? null : reader["update_by"].ToString();
            obj.Group_Desc = reader["Group_Desc"] == DBNull.Value ? null : reader["Group_Desc"].ToString();
            obj.Price_Purchase = reader["Price_Purchase"] == DBNull.Value ? 0 : Convert.ToDouble(reader["Price_Purchase"]);
            obj.Price_Inventory = reader["Price_Inventory"] == DBNull.Value ? 0 : Convert.ToDouble(reader["Price_Inventory"]);
            return obj;
        }
    }




}




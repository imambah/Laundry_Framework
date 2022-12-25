
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
        public string CategoryID { get; set; }
        public string UoM { get; set; }
        public double Price_Purchase { get; set; }
        public double Price_Inventory { get; set; }
        public string Stock { get; set; }
        public string Buffer_Stock { get; set; }
        public string Company_Persentage { get; set; }
        public string Vendor_Persentage { get; set; }
        public string Vat_Flag { get; set; }
        public string Conversion { get; set; }
        public string Batch_No { get; set; }
        public string Warehouse_ID { get; set; }
        public string Group_Code { get; set; }
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
            obj.CategoryID = reader["CategoryID"].ToString();
            obj.UoM = reader["UoM"].ToString();
            obj.Price_Purchase = Convert.ToDouble(reader["Price_Purchase"]); 
            obj.Price_Inventory = Convert.ToDouble(reader["Price_Inventory"]);
            obj.Stock = reader["Stock"].ToString();
            obj.Buffer_Stock = reader["Buffer_Stock"].ToString();
            obj.Company_Persentage = reader["Company_Persentage"].ToString();
            obj.Vendor_Persentage = reader["Vendor_Persentage"].ToString();
            obj.Vat_Flag = reader["Vat_Flag"].ToString();
            obj.Conversion = reader["Conversion"].ToString();
            obj.Batch_No = reader["Batch_No"].ToString();
            obj.Warehouse_ID = reader["Warehouse_ID"].ToString();
            obj.Group_Code = reader["Group_Code"].ToString();
            obj.create_date = reader["create_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["create_date"]);
            obj.create_by = reader["create_by"].ToString();
            obj.update_date = reader["update_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["update_date"]);
            obj.update_by = reader["update_by"].ToString();
            return obj;
        }
    }




}





using DataAccessLayer;
using System;
namespace Web.Dto
{
    public class GR_DetailDbo : IDataMapper<GR_DetailDbo>
    {
        public int RecordID { get; set; }
        public string GR_Number { get; set; }
        public int GR_line { get; set; }
        public string Item_Code { get; set; }
        public double Price_Purchasing { get; set; }
        public string UOM { get; set; }
        public int qty { get; set; }
        public Double Discount { get; set; }
        public Double Price_Sales { get; set; }
        public Double Total { get; set; }
        public int Begining_Stock{ get; set; }
        public int Current_Stock { get; set; }
        public int BatchNumber  { get; set; }
        public DateTime? Expire_Date { get; set; }
        public int CountBatch { get; set; }
        public DateTime? Create_Date { get; set; }
        public string keterangan { get; set; }

        public GR_DetailDbo Map(System.Data.IDataReader reader)
        {
            GR_DetailDbo obj = new GR_DetailDbo();
            obj.RecordID = Convert.ToInt32(reader["RecordID"]);
            obj.GR_Number = reader["GR_Number"] == DBNull.Value ? "": reader["GR_Number"].ToString();
            obj.GR_line = reader["GR_line"] == DBNull.Value ? 0 : Convert.ToInt32(reader["GR_line"]);
            obj.Item_Code = reader["ItemCode"] == DBNull.Value ? "" : reader["ItemCode"].ToString();
            obj.Price_Purchasing = reader["Price_Purchasing"] == DBNull.Value ? 0: Convert.ToDouble(reader["Price_Purchasing"]);
            obj.UOM = reader["uom"] == DBNull.Value ? "" : reader["uom"].ToString();
            obj.qty =  reader["qty"] == DBNull.Value ? 0 : Convert.ToInt32(reader["qty"]); 
            obj.Discount = reader["discount"] == DBNull.Value ? 0 : Convert.ToDouble(reader["discount"]);
            obj.Price_Sales = reader["VAT_Amount"] == DBNull.Value ? 0 : Convert.ToDouble(reader["VAT_Amount"]);
            obj.Total = reader["TAX_Amount"] == DBNull.Value ? 0 : Convert.ToDouble(reader["TAX_Amount"]);
            obj.Begining_Stock = reader["Total_Amount"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Total_Amount"]);
            obj.Current_Stock = reader["Current_Stock"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Current_Stock"]);
            obj.BatchNumber = reader["BatchNumber"] == DBNull.Value ? 0 : Convert.ToInt32(reader["BatchNumber"]);
            obj.Expire_Date = reader["Expire_Date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["Expire_Date"]);
            obj.CountBatch = reader["CountBatch"] == DBNull.Value ? 0 : Convert.ToInt32(reader["CountBatch"]);
            obj.Create_Date = reader["Create_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["Create_date"]);
            obj.keterangan = reader["keterangan"] == DBNull.Value ? "" : reader["keterangan"].ToString();
            return obj;
        }
    }
}




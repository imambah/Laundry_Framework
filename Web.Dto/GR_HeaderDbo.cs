
using DataAccessLayer;
using System;
namespace Web.Dto
{
    public class GR_HeaderDbo : IDataMapper<GR_HeaderDbo>
    {
        public int RecordID { get; set; }
        public string GR_Number { get; set; }
        public DateTime? GR_date { get; set; }
        public string PO_Number { get; set; }
        public string supplierid { get; set; }
        public string DO_Number { get; set; }
        public DateTime? DO_date { get; set; }
        public string send_by { get; set; }
        public Double Amount { get; set; }
        public Double discount { get; set; }
        public Double VAT_Amount { get; set; }
        public Double TAX_Amount { get; set; }
        public Double Total_Amount { get; set; }
        public string BranchID { get; set; }
        public string PO_Description { get; set; }
        public string EntryByUser { get; set; }
        public int Posting_Flag { get; set; }
        public DateTime? Create_date { get; set; }
        
        public GR_HeaderDbo Map(System.Data.IDataReader reader)
        {
            GR_HeaderDbo obj = new GR_HeaderDbo();
            obj.RecordID = Convert.ToInt32(reader["RecordID"]);
            obj.GR_Number = reader["GR_Number"] == DBNull.Value ? "": reader["GR_Number"].ToString();
            obj.GR_date = reader["GR_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["GR_date"]);
            obj.PO_Number = reader["PO_Number"] == DBNull.Value ? "" : reader["PO_Number"].ToString();
            obj.supplierid = reader["supplierid"] == DBNull.Value ? "" : reader["supplierid"].ToString();
            obj.DO_date = reader["GR_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["DO_date"]);
            obj.send_by = reader["send_by"] == DBNull.Value ? "" : reader["send_by"].ToString();
            obj.Amount =  reader["Amount"] == DBNull.Value ? 0 : Convert.ToDouble(reader["Amount"]); 
            obj.discount = reader["discount"] == DBNull.Value ? 0 : Convert.ToDouble(reader["discount"]);
            obj.VAT_Amount = reader["VAT_Amount"] == DBNull.Value ? 0 : Convert.ToDouble(reader["VAT_Amount"]);
            obj.TAX_Amount = reader["TAX_Amount"] == DBNull.Value ? 0 : Convert.ToDouble(reader["TAX_Amount"]);
            obj.Total_Amount = reader["Total_Amount"] == DBNull.Value ? 0 : Convert.ToDouble(reader["Total_Amount"]);
            obj.BranchID = reader["BranchID"] == DBNull.Value ? "" : reader["BranchID"].ToString();
            obj.PO_Description = reader["PO_Description"] == DBNull.Value ? "" :  reader["PO_Description"].ToString();
            obj.EntryByUser = reader["EntryByUser"] == DBNull.Value ? "" :  reader["EntryByUser"].ToString();
            obj.Posting_Flag = reader["Posting_Flag"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Total_Amount"]);
            obj.Create_date = reader["Create_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["Create_date"]);
            return obj;
        }
    }
}




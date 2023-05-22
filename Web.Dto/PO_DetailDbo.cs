
using DataAccessLayer;
using System;
namespace Web.Dto
{
    public class PO_DetailDbo : IDataMapper<PO_DetailDbo>
    {
        public int RecordID { get; set; }
        public string PO_number { get; set; }
        public int PO_line { get; set; }
        public string ItemCode { get; set; }
        public decimal Price { get; set; }
        public string UOM { get; set; }
        public int Qty { get; set; }
        public int Qty_Outstanding { get; set; }
        public decimal Disc { get; set; }
        public decimal Total { get; set; }
        public DateTime? create_date { get; set; }
        public DateTime? expire_date { get; set; }

        public PO_DetailDbo Map(System.Data.IDataReader reader)
        {
            PO_DetailDbo obj = new PO_DetailDbo();
            obj.RecordID = Convert.ToInt32(reader["RecordID"]);
            obj.PO_number = reader["PO_number"].ToString();
            obj.PO_line = reader["PO_date"] == DBNull.Value ? 0 : Convert.ToInt32(reader["PO_date"]);        
            obj.ItemCode = reader["itemcode"].ToString();
            obj.Price = reader["price"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["price"]);  
            obj.UOM = reader["uom"] == DBNull.Value ? "" : reader["uom"].ToString();  
            obj.Qty = reader["quantity"] == DBNull.Value ? 0 : Convert.ToInt32(reader["quantity"]);  
            obj.Qty_Outstanding= reader["quantity_outstanding"] == DBNull.Value ? 0 : Convert.ToInt32(reader["quantity_outstanding"]);  
            obj.Disc = reader["discount"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["discount"]);  
            obj.Total = reader["total"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["total"]);              
            obj.create_date = reader["create_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["create_date"]);
            obj.expire_date = reader["expired_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["expired_date"]);
            return obj;
        }
    }
}




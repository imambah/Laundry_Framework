
using DataAccessLayer;
using System;
namespace Web.Dto
{
    public class PODbo : IDataMapper<PODbo>
    {
        public int RecordID { get; set; }
        public string PO_number { get; set; }
        public string PR_number { get; set; }
        public string SupplierID { get; set; }
        public string PIC { get; set; }
        public string customerid { get; set; }
        public DateTime? DeliveryDatePlan { get; set; }
        public int Total_Line { get; set; }
        public decimal amount { get; set; }
        public decimal discount { get; set; }
        public decimal VAT_amount { get; set; }
        public decimal TAX_amount { get; set; }
        public decimal Total_amount { get; set; }
        public string Term_Of_Payment { get; set; }
        public string BranchId { get; set; }
        public string PO_Description { get; set; }
        public int status { get; set; }
        public DateTime? delivery_date { get; set; }
        public string EntryByUser { get; set; }
        public DateTime? create_date { get; set; }
        public DateTime? last_update { get; set; }
        public DateTime? expire_date { get; set; }

        public PODbo Map(System.Data.IDataReader reader)
        {
            PODbo obj = new PODbo();
            obj.RecordID = Convert.ToInt32(reader["RecordID"]);
            obj.PO_number = reader["PO_number"].ToString();
            obj.PR_number = reader["PR_number"].ToString();
            obj.SupplierID = reader["SupplierID"].ToString();
            obj.PIC = reader["PIC"].ToString();
          
            obj.customerid = reader["customerid"].ToString();
            obj.DeliveryDatePlan = reader["DeliveryDatePlan"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["DeliveryDatePlan"]);

            obj.Total_Line = reader["Total_Line"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Total_Line"]); 
            obj.amount = reader["amount"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["amount"]);  
            obj.discount = reader["discount"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["discount"]);  
            obj.amount = reader["amount"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["amount"]);  
            obj.VAT_amount = reader["VAT_amount"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["VAT_amount"]);  
            obj.TAX_amount = reader["TAX_amount"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["TAX_amount"]);  
            obj.Total_amount = reader["Total_amount"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Total_amount"]);  
                       
            obj.BranchId = reader["BranchId"].ToString();
            obj.PO_Description = reader["PO_Description"].ToString();
            obj.Term_Of_Payment = reader["Term_Of_Payment"].ToString();
            obj.status = reader["status"] == DBNull.Value ? 0 : Convert.ToInt32(reader["status"]);  
           
            obj.delivery_date = reader["delivery_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["delivery_date"]);
            obj.EntryByUser = reader["EntryByUser"].ToString();

            obj.create_date = reader["create_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["create_date"]);
            obj.last_update = reader["last_update"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["last_update"]);
            obj.expire_date = reader["expire_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["expire_date"]);
            return obj;
        }
    }




}




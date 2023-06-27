
using DataAccessLayer;
using System;
namespace Web.Dto
{
    public class PO_HeaderDbo : IDataMapper<PO_HeaderDbo>
    {
        public int RecordID { get; set; }
        public string PO_number { get; set; }
        public DateTime? PO_date { get; set; }
        public string customerid { get; set; }
        public string customername { get; set; }

        public DateTime? DeliveryDatePlan { get; set; }
        public string Term_Of_Payment { get; set; }
        public string PO_Description { get; set; }
        public string BranchID { get; set; }
        public string Billto_Id { get; set; }
        public string Billto_Name { get; set; }
        public decimal amount { get; set; }
        public int ppn_percent { get; set; }
        public int disc_percent { get; set; }
        public decimal totalAmount { get; set; }




        public PO_HeaderDbo Map(System.Data.IDataReader reader)
        {
            PO_HeaderDbo obj = new PO_HeaderDbo();
            obj.RecordID = Convert.ToInt32(reader["RecordID"]);
            obj.PO_number = reader["PO_number"] == DBNull.Value ? "" : reader["PO_number"].ToString();
            obj.PO_date = reader["PO_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["create_date"]);
            obj.customerid = reader["customerid"] == DBNull.Value ? "" : reader["customerid"].ToString();
            obj.customername = reader["customername"] == DBNull.Value ? "" : reader["customername"].ToString();
            obj.DeliveryDatePlan = reader["DeliveryDatePlan"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["DeliveryDatePlan"]);
            obj.Term_Of_Payment = reader["Term_Of_Payment"] == DBNull.Value ? "" : reader["Term_Of_Payment"].ToString();
            obj.PO_Description = reader["PO_Description"] == DBNull.Value ? "" : reader["PO_Description"].ToString();
            obj.BranchID = reader["BranchID"] == DBNull.Value ? "" : reader["BranchID"].ToString();
            obj.Billto_Id = reader["Billto_Id"] == DBNull.Value ? "" : reader["Billto_Id"].ToString();
            obj.Billto_Name = reader["Billto_Name"] == DBNull.Value ? "" : reader["Billto_Name"].ToString();
            obj.amount = reader["amount"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["amount"]);
            obj.ppn_percent = reader["ppn_percent"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ppn_percent"]);
            obj.disc_percent = reader["disc_percent"] == DBNull.Value ? 0 : Convert.ToInt32(reader["disc_percent"]);
            obj.totalAmount = reader["total_amount"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["total_amount"]);
            return obj;
        }
    }
}




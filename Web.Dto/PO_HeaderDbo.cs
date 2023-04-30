
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
        
        public PO_HeaderDbo Map(System.Data.IDataReader reader)
        {
            PO_HeaderDbo obj = new PO_HeaderDbo();
            obj.RecordID = Convert.ToInt32(reader["RecordID"]);
            obj.PO_number = reader["PO_number"].ToString();
            obj.PO_date = reader["PO_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["create_date"]);
            obj.customerid = reader["customerid"].ToString();
            obj.customername = reader["customername"].ToString();
            obj.DeliveryDatePlan = reader["DeliveryDatePlan"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["DeliveryDatePlan"]);
            obj.Term_Of_Payment = reader["Term_Of_Payment"].ToString();
            obj.PO_Description = reader["PO_Description"].ToString();
            obj.BranchID = reader["BranchID"].ToString();
            return obj;
        }
    }
}




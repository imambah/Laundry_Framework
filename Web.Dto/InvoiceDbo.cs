
using DataAccessLayer;
using System;
namespace Web.Dto
{
	public class InvoiceDbo : IDataMapper<InvoiceDbo>
	{

        //public int id { get; set; }
        public int id { get; set; }
        public int no_urut { get; set; }
        public string transaction_id { get; set; }
        public string customerid { get; set; }
        public string customer_name { get; set; }
        public string customer_address { get; set; }
        public string customer_type { get; set; }
        public string transaction_date { get; set; }
        public string transaction_type { get; set; }
        public string nilai { get; set; }
        public string BranchID { get; set; }
        public string BranchName { get; set; }


        public InvoiceDbo Map(System.Data.IDataReader reader)
        {
            InvoiceDbo obj = new InvoiceDbo();
            obj.id = Convert.ToInt32(reader["id"]);
            obj.no_urut = Convert.ToInt32(reader["no_urut"]);
            obj.transaction_id = reader["transaction_id"].ToString();
            obj.customerid = reader["customerid"].ToString();
            obj.customer_name = reader["customer_name"].ToString();
            obj.customer_address = reader["customer_address"].ToString();
            obj.customer_type = reader["customer_type"].ToString();
            obj.transaction_date = reader["transaction_date"].ToString();
            obj.transaction_type = reader["transaction_type"].ToString();
            obj.nilai = reader["nilai"].ToString();
            obj.BranchID = reader["BranchID"].ToString();
            obj.BranchName = reader["BranchName"].ToString();
            return obj;
        }
    }

}





using DataAccessLayer;
using System;
namespace Web.Dto
{
	public class InvoiceSummaryDbo : IDataMapper<InvoiceSummaryDbo>
	{

        //public int id { get; set; }
        public int id { get; set; }
        public string invoice_no { get; set; }
        public string invoice_date { get; set; }
        public string transaction_id { get; set; }
        public string customerid { get; set; }
        public decimal nilai { get; set; }
        public decimal ppn { get; set; }
        public decimal disc { get; set; }
        public decimal total { get; set; }


        public InvoiceSummaryDbo Map(System.Data.IDataReader reader)
        {
            InvoiceSummaryDbo obj = new InvoiceSummaryDbo();
            obj.id = Convert.ToInt32(reader["id"]);
            obj.invoice_no = reader["invoice_no"].ToString();
            //obj.invoice_date = reader["invoice_date"].ToString();
            obj.transaction_id = reader["transaction_id"].ToString();
            obj.customerid = reader["customer_id"].ToString();
            obj.nilai = reader["nilai"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["nilai"]);
            obj.ppn = reader["ppn"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["ppn"]);
            obj.disc = reader["disc"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["disc"]);
            obj.total = reader["total"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["total"]);

            return obj;
        }
    }

}




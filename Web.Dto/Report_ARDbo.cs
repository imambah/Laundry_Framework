
using DataAccessLayer;
using System;
namespace Web.Dto
{
	public class Report_ARDbo : IDataMapper<Report_ARDbo>
	{
        public string cabang { get; set; }
        public string custid { get; set; }
        public string custname { get; set; }
        public decimal amt { get; set; }
        public decimal outstanding { get; set; }
        public string invoice_no { get; set; }
        public DateTime ? invoice_date { get; set; }
        public DateTime ? due_date { get; set; }

        public Report_ARDbo Map(System.Data.IDataReader reader)
        {
            Report_ARDbo obj = new Report_ARDbo();
            obj.cabang = reader["cabang"].ToString();
            obj.custid = reader["custid"].ToString();
            obj.custname = reader["custname"].ToString();
            obj.amt = reader["amt"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["amt"]);
            obj.outstanding = reader["outstanding"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["outstanding"]);
            obj.invoice_no = reader["invoice_no"].ToString();
            obj.invoice_date = reader["invoice_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["invoice_date"]);
            obj.due_date = reader["due_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["due_date"]);
            return obj;
        }
    }

}




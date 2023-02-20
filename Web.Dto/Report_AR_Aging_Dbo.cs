
using DataAccessLayer;
using System;
namespace Web.Dto
{
	public class Report_AR_Aging_Dbo : IDataMapper<Report_AR_Aging_Dbo>
	{
        public string cabang { get; set; }
        public string custid { get; set; }
        public string custname { get; set; }
        public decimal amt { get; set; }
        public decimal curr { get; set; }
        public decimal a0130 { get; set; }
        public decimal a3160 { get; set; }
        public decimal a6190 { get; set; }
        public decimal a91 { get; set; }

        public Report_AR_Aging_Dbo Map(System.Data.IDataReader reader)
        {
            Report_AR_Aging_Dbo obj = new Report_AR_Aging_Dbo();
            obj.cabang = reader["cabang"].ToString();
            obj.custid = reader["custid"].ToString();
            obj.custname = reader["custname"].ToString();
            obj.amt = reader["amt"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["amt"]);
            obj.curr = reader["curr"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["curr"]);
            obj.a0130 = reader["a30"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["a30"]);
            obj.a3160 = reader["a60"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["a60"]);
            obj.a6190 = reader["a90"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["a90"]);
            obj.a91 = reader["a91"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["a91"]);
            return obj;
        }
    }

}




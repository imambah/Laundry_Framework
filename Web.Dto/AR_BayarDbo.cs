
using DataAccessLayer;
using System;
namespace Web.Dto
{
    public class AR_BayarDbo : IDataMapper<AR_BayarDbo>
    {
        public string   Invoice_No { get; set; }
        public decimal NilaiPiutang { get; set; }
        public decimal SisaPiutang { get; set; }
        public decimal BayarPiutang { get; set; }
        public string Create_By { get; set; }
        public string bank_id { get; set; }


        public AR_BayarDbo Map(System.Data.IDataReader reader)
        {
            AR_BayarDbo obj = new AR_BayarDbo();
            obj.Invoice_No = reader["invoice_no"].ToString();
            obj.NilaiPiutang =  reader["nilaipiutang"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["nilaipiutang"]);
            obj.SisaPiutang = reader["sisapiutang"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["sisapiutang"]);
            obj.BayarPiutang = reader["bayarpiutang"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["bayarpiutang"]);
            obj.Create_By = reader["create_by"].ToString();
            obj.bank_id = reader["bank_id"].ToString();

            return obj;
        }
    }




}




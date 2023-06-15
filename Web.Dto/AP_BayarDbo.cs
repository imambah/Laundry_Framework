
using DataAccessLayer;
using System;
namespace Web.Dto
{
    public class AP_BayarDbo : IDataMapper<AP_BayarDbo>
    {
        public string  GR_No { get; set; }
        public decimal NilaiHutang { get; set; }
        public decimal SisaHutang{ get; set; }
        public decimal BayarHutang { get; set; }
        public string Create_By { get; set; }

        //public decimal Create_Date { get; set; }



        public AP_BayarDbo Map(System.Data.IDataReader reader)
        {
            AP_BayarDbo obj = new AP_BayarDbo();
            obj.GR_No = reader["GR_No"].ToString();
            obj.NilaiHutang =  reader["nilaihutang"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["nilaihutang"]);
            obj.SisaHutang = reader["sisahutang"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["sisahutang"]);
            obj.BayarHutang = reader["bayarhutang"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["bayarhutang"]);
            obj.Create_By = reader["create_by"].ToString();

            return obj;
        }
    }




}




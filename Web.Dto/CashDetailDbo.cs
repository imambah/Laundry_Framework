
using DataAccessLayer;
using System;
namespace Web.Dto
{
    public class CashDetailDbo : IDataMapper<CashDetailDbo>
    {

        public int id { get; set; }
        public string Voucher_ID { get; set; }
        public string Voucher_Desc { get; set; }
        public string PIC { get; set; }
        public DateTime? Transaction_date { get; set; }
        public string BankID { get; set; }
        public string BankName { get; set; }
        public double Amount { get; set; }
        public string Voucher_Type { get; set; }
        public int id_detail { get; set; }
        public string Voucher_ID_Detail { get; set; }
        public string Description_Detail { get; set; }
        public string Category_Detail { get; set; }
        public string COA_Detail { get; set; }
        public double value_detail { get; set; }

        public CashDetailDbo Map(System.Data.IDataReader reader)
        {
            CashDetailDbo obj = new CashDetailDbo();
            obj.id = Convert.ToInt32(reader["id"]);
            obj.Voucher_ID = reader["Voucher_ID"].ToString();
            obj.Voucher_Desc = reader["Voucher_Desc"].ToString();
            obj.PIC = reader["PIC"].ToString();
            obj.Transaction_date = reader["Transaction_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["Transaction_date"]);
            obj.BankID = reader["BankID"].ToString();
            obj.BankID = reader["BankName"].ToString();
            obj.Amount = Convert.ToDouble(reader["Amount"]);
            obj.Voucher_Type = reader["Voucher_Type"].ToString();
            obj.id_detail = reader["id_detail"] == DBNull.Value ? 0 : Convert.ToInt32(reader["id_detail"]);
            obj.Voucher_ID_Detail = reader["Voucher_ID"].ToString();
            obj.Description_Detail = reader["Description_Detail"].ToString();
            obj.Category_Detail = reader["Category_Detail"] == DBNull.Value ? "" : reader["Category_Detail"].ToString();
            obj.COA_Detail = reader["COA_Detail"] == DBNull.Value ? "" : reader["COA_Detail"].ToString();
            obj.value_detail = reader["Value_Detail"] == DBNull.Value ? 0 : Convert.ToDouble(reader["Value_Detail"]);
            return obj;
        }
    }




}




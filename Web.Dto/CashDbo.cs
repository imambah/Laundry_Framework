
using DataAccessLayer;
using System;
using System.Collections.Generic;

namespace Web.Dto
{
    public class CashDbo : IDataMapper<CashDbo>
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
        public string Posted { get; set; }
        public DateTime? create_date { get; set; }
        public string create_by { get; set; }
        public DateTime? update_date { get; set; }
        public string update_by { get; set; }

        public List<CashDetailDbo> Details { get; set; }

        public CashDbo Map(System.Data.IDataReader reader)
        {
            CashDbo obj = new CashDbo();
            obj.id = Convert.ToInt32(reader["id"]);
            obj.Voucher_ID = reader["Voucher_ID"].ToString();
            obj.Voucher_Desc = reader["Voucher_Desc"].ToString();
            obj.PIC = reader["PIC"].ToString();
            obj.Transaction_date = reader["Transaction_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["Transaction_date"]);
            obj.BankID = reader["BankID"].ToString();
            obj.BankID = reader["BankName"].ToString();
            obj.Amount = Convert.ToDouble(reader["Amount"]);
            obj.Voucher_Type = reader["Voucher_Type"].ToString();
            obj.Posted = reader["Posted"].ToString();
            obj.create_date = reader["create_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["create_date"]);
            obj.create_by = reader["create_by"].ToString();
            obj.update_date = reader["update_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["update_date"]);
            obj.update_by = reader["update_by"].ToString();
            return obj;
        }
    }




}




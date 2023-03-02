
using DataAccessLayer;
using System;
namespace Web.Dto
{
    public class CashDetailDbo : IDataMapper<CashDetailDbo>
    {
        public int id { get; set; }
        public string Voucher_ID { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string COA { get; set; }
        public double Value { get; set; }

        public CashDetailDbo Map(System.Data.IDataReader reader)
        {
            CashDetailDbo obj = new CashDetailDbo();
            obj.id = Convert.ToInt32(reader["id"]);
            obj.Voucher_ID = reader["Voucher_ID"].ToString();
            obj.Description = reader["Description"].ToString();
            obj.Category = reader["Category"].ToString();
            obj.COA = reader["COA"].ToString();
            obj.Value = reader["Value"] == DBNull.Value ? 0 : Convert.ToDouble(reader["Value"]);
                      
            return obj;
        }
    }




}




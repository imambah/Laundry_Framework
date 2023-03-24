
using DataAccessLayer;
using System;
namespace Web.Dto
{
    public class POS_AgentDbo : IDataMapper<POS_AgentDbo>
    {
        public int id { get; set; }
        public string agent_id { get; set; }
        public string agent_name { get; set; }
        public string transaction_id { get; set; }
        public DateTime? finished_date { get; set; }
        public decimal transaction_amt { get; set; }
        public string invoice_flag { get; set; }
        public DateTime? create_date { get; set; }
        public string create_by { get; set; }
        public DateTime? update_date { get; set; }
        public string update_by { get; set; }

        public POS_AgentDbo Map(System.Data.IDataReader reader)
        {
            POS_AgentDbo obj = new POS_AgentDbo();
            obj.id = Convert.ToInt32(reader["id"]);
            obj.transaction_id = reader["transaction_id"].ToString();
            obj.finished_date = reader["finished_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["finished_date"]);
            obj.transaction_amt = reader["transaction_amt"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["transaction_amt"]);
            obj.invoice_flag = reader["invoice_flag"].ToString();
            obj.create_date = reader["create_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["create_date"]);
            obj.create_by = reader["create_by"].ToString();
            obj.update_date = reader["update_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["update_date"]);
            obj.update_by = reader["update_by"].ToString();
            return obj;
        }
    }




}





using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace Web.Dto
{
    public class tbl_log : IDataMapper<tbl_log>
    {
        #region tbl_log Properties
        public Int64 id { get; set; }
        public DateTime? created { get; set; }
        public string text_message { get; set; }
        public string log_type { get; set; }
        public string current_login { get; set; }
        public string ip_address { get; set; }
        #endregion    
        public tbl_log Map(System.Data.IDataReader reader)
        {
            tbl_log obj = new tbl_log();   
            obj.id = Convert.ToInt64(reader["id"]);
            obj.created = reader["created"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["created"]);
            obj.text_message = reader["text_message"] == DBNull.Value ? null : reader["text_message"].ToString();
            obj.log_type = reader["log_type"] == DBNull.Value ? null : reader["log_type"].ToString();
            obj.current_login = reader["current_login"] == DBNull.Value ? null : reader["current_login"].ToString();
            obj.ip_address = reader["ip_address"] == DBNull.Value ? null : reader["ip_address"].ToString();
            return obj;
        }
    }
}
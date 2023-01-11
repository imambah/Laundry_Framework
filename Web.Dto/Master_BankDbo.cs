
using DataAccessLayer;
using System;
namespace Web.Dto
{
	public class Master_BankDbo : IDataMapper<Master_BankDbo>
	{

		public int id { get; set; }
        public string BankID { get; set; }
        public string Description { get; set; }
        public string Account { get; set; }
        public string Area { get; set; }
        public string Balance { get; set; }
        public string Account_Name { get; set; }
        public string COA { get; set; }

        public int is_delete { get; set; }
        public DateTime ? create_date{ get; set; }
		public string create_by { get; set; }
		public DateTime ? update_date { get; set; }
		public string update_by { get; set; }

        public Master_BankDbo Map(System.Data.IDataReader reader)
        {
            Master_BankDbo obj = new Master_BankDbo();
            obj.id = Convert.ToInt32(reader["id"]);
            obj.BankID = reader["BankID"].ToString();
            obj.Description = reader["Description"].ToString();
            obj.Account = reader["Account"].ToString();
            obj.Area = reader["Area"].ToString();
            obj.Balance = reader["Balance"].ToString();
            obj.Account_Name = reader["account_name"].ToString();
            obj.COA = reader["COA"].ToString();
            obj.is_delete = reader["is_delete"] == DBNull.Value ? 0 : Convert.ToInt32(reader["is_delete"]);
            obj.create_date = reader["create_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["create_date"]);
            obj.create_by = reader["create_by"].ToString();
            obj.update_date = reader["update_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["update_date"]);
            obj.update_by = reader["update_by"].ToString();
            return obj;
        }
    }

}




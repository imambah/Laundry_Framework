
using DataAccessLayer;
using System;
namespace Web.Dto
{
    public class Company_ProfileDbo : IDataMapper<Company_ProfileDbo>
    {
        public string company_name { get; set; }
        public string company_address { get; set; }
        public string telp_no { get; set; }
        public DateTime? create_date { get; set; }
        public string create_by { get; set; }
        public DateTime? update_date { get; set; }
        public string update_by { get; set; }

        public Company_ProfileDbo Map(System.Data.IDataReader reader)
        {
            Company_ProfileDbo obj = new Company_ProfileDbo();
            obj.company_name = reader["company_name"].ToString();
            obj.company_address = reader["company_address"].ToString();
            obj.telp_no = reader["telp_no"].ToString();
            obj.create_date = reader["create_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["create_date"]);
            obj.create_by = reader["create_by"].ToString();
            obj.update_date = reader["update_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["update_date"]);
            obj.update_by = reader["update_by"].ToString();
            return obj;
        }
    }

}




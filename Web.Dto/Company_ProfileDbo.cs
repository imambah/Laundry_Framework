
using DataAccessLayer;
using System;
namespace Web.Dto
{
    public class Company_ProfileDbo : IDataMapper<Company_ProfileDbo>
    {
        public int id { get; set; }
        public string company_name { get; set; }
        public string company_address { get; set; }
        public string company_address2 { get; set; }
        public string telp_no { get; set; }
        public string city { get; set; }
        public string area { get; set; }
        public string country { get; set; }
        public string zip { get; set; }
        public string email { get; set; }
        public string PIC { get; set; }
        public string tax_id { get; set; }
        public string tax_name { get; set; }
        public string tax_address { get; set; }
        public string logo { get; set; }
        public string director { get; set; }
        public string finance { get; set; }
        public string website_erp { get; set; }
        public string certificate_no { get; set; }
        public string fbackground { get; set; }
        public string bank { get; set; }
        public string account_name { get; set; }
        public string account_no { get; set; }
        public string bank_branch { get; set; }
        public DateTime? create_date { get; set; }
        public string create_by { get; set; }
        public DateTime? update_date { get; set; }
        public string update_by { get; set; }

        public Company_ProfileDbo Map(System.Data.IDataReader reader)
        {
            Company_ProfileDbo obj = new Company_ProfileDbo();
            obj.company_name = reader["company_name"].ToString();
            obj.company_address = reader["company_address"].ToString();
            obj.company_address2 = reader["company_address2"].ToString();
            obj.telp_no = reader["telp_no"].ToString();
            obj.city = reader["city"].ToString();
            obj.area = reader["area"].ToString();
            obj.country = reader["country"].ToString();
            obj.zip = reader["zip"].ToString();
            obj.email = reader["email"].ToString();
            obj.PIC = reader["PIC"].ToString();
            obj.tax_id = reader["tax_id"].ToString();
            obj.tax_name = reader["tax_name"].ToString();
            obj.tax_address = reader["tax_address"].ToString();
            obj.logo = reader["logo"].ToString();
            obj.director = reader["director"].ToString();
            obj.finance = reader["finance"].ToString();
            obj.website_erp = reader["website_erp"].ToString();
            obj.certificate_no = reader["certificate_no"].ToString();
            obj.fbackground = reader["fbackground"].ToString();
            obj.bank = reader["bank"].ToString();
            obj.account_name = reader["account_name"].ToString();
            obj.account_no = reader["account_no"].ToString();
            obj.bank_branch = reader["bank_branch"].ToString();
            obj.create_date = reader["create_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["create_date"]);
            obj.create_by = reader["create_by"].ToString();
            obj.update_date = reader["update_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["update_date"]);
            obj.update_by = reader["update_by"].ToString();
            return obj;
        }
    }

}




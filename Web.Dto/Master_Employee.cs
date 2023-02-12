
using DataAccessLayer;
using System;
namespace Web.Dto
{
	public class Master_Employee : IDataMapper<Master_Employee>
	{

	public int RecordID { get; set; }
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Area { get; set; }
        public string Country { get; set; }
        public string Zip { get; set; }
        public string Gender { get; set; }
        public string Religion { get; set; }
        public string Status { get; set; }
        public string ID_Card { get; set; }
        public string ID_Card_No { get; set; }
        public decimal Salary { get; set; }
        public decimal Transport_Allowance { get; set; }
        public decimal Meal_Allowance { get; set; }
        public decimal Position_Allowance { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string TAXID { get; set; }
        public string TAXName { get; set; }
        public string TaxAddress { get; set; }
        public string bank_account { get; set; }
        public string bank_name { get; set; }
        public string bank_branch { get; set; }
        public DateTime ? Start_Date { get; set; }
        public DateTime ? End_Date { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public string Placement { get; set; }

        public DateTime ? create_date{ get; set; }
	public string create_by { get; set; }
	public DateTime ? update_date { get; set; }
	public string update_by { get; set; }
        public int is_delete { get; set; }


        public Master_Employee Map(System.Data.IDataReader reader)
        {
            Master_Employee obj = new Master_Employee();
            obj.RecordID = Convert.ToInt32(reader["RecordID"]);
            obj.EmployeeID = reader["kode_Employee"].ToString();
            obj.EmployeeName = reader["EmployeeName"].ToString();
            obj.Address1 = reader["Address1"].ToString();
            obj.Address2 = reader["Address2"].ToString();
            obj.City = reader["City"].ToString();
            obj.Area = reader["Area"].ToString();
            obj.Country = reader["Country"].ToString();
            obj.Zip = reader["Zip"].ToString();
            obj.Gender = reader["Gender"].ToString();
            obj.Religion = reader["Religion"].ToString();
            obj.Status = reader["Status"].ToString();
            obj.Gender = reader["Gender"].ToString();
            obj.ID_Card = reader["ID_Card"].ToString();
            obj.ID_Card_No = reader["ID_Card_No"].ToString();
            obj.Salary = reader["Salary"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Salary"]); 
            obj.Transport_Allowance = reader["Transport_Allowance"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["credit_limit"]); 
            obj.Meal_Allowance = reader["Meal_Allowance"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Meal_Allowance"]); 
            obj.Position_Allowance = reader["Position_Allowance"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Position_Allowance"]); 
            obj.Phone = reader["pic"].ToString();
            obj.Email = reader["Email"].ToString();
            obj.TAXID = reader["tax_id"].ToString();
            obj.TAXName = reader["tax_name"].ToString();
            obj.TaxAddress = reader["tax_address"].ToString();
            obj.bank_account = reader["bank_account"].ToString();
            obj.bank_name = reader["bank_name"].ToString();
            obj.bank_branch = reader["bank_branch"].ToString();
            obj.Start_Date = reader["Start_Date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["Start_Date"]);
            obj.End_Date = reader["End_Date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["End_Date"]);

            obj.Department = reader["Department"].ToString();
            obj.Position = reader["Position"].ToString();
            obj.Placement = reader["Placement"].ToString();

            obj.create_date = reader["create_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["create_date"]);
            obj.create_by = reader["create_by"].ToString();
            obj.update_date = reader["update_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["update_date"]);
            obj.update_by = reader["update_by"].ToString();
            obj.is_delete = reader["is_delete"] == DBNull.Value ? 0 : Convert.ToInt32(reader["is_delete"]);
            return obj;
        }
    }

}




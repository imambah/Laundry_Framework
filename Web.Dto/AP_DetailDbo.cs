
using DataAccessLayer;
using System;
namespace Web.Dto
{
    public class AP_DetailDbo : IDataMapper<AP_DetailDbo>
    {
        public string   recordid { get; set; }
        public string   gr_number { get; set; }
        public DateTime? gr_date { get; set; }
        public string   supplier_id { get; set; }
        public string   supplier_name { get; set; }
        public decimal total { get; set; }
        public decimal outstanding { get; set; }


        public AP_DetailDbo Map(System.Data.IDataReader reader)
        {
            AP_DetailDbo obj = new AP_DetailDbo();
            obj.recordid = reader["recordid"] == DBNull.Value ? "" : reader["recordid"].ToString();
            obj.gr_number = reader["gr_no"].ToString();
            obj.gr_date = reader["gr_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["gr_date"]);
            obj.supplier_id = reader["supplierid"].ToString();
            obj.supplier_name = reader["supplier_name"].ToString();
            obj.total = Convert.ToDecimal(reader["total"]);
            obj.outstanding = Convert.ToDecimal(reader["outstanding"]);
            
            //obj.Create_By = reader["create_by"] == DBNull.Value ? "" :  reader["create_by"].ToString();
            //obj.branchid = reader["branchid"] == DBNull.Value ? "" : reader["branchid"].ToString();

            return obj;
        }
    }




}




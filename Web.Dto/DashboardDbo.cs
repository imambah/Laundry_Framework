
using DataAccessLayer;
using System;
namespace Web.Dto
{
    public class DashboardDbo : IDataMapper<DashboardDbo>
    {
        public string  label { get; set; }
        public string   value { get; set; }
       
        //public decimal Create_Date { get; set; }



        public DashboardDbo Map(System.Data.IDataReader reader)
        {
            DashboardDbo obj = new DashboardDbo();
            obj.label = reader["label"] == DBNull.Value ? "" : reader["label"].ToString();
            obj.value = reader["value"].ToString();

            return obj;
        }
    }




}




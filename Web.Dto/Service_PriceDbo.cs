
using DataAccessLayer;
using System;
namespace Web.Dto
{
    public class Service_PriceDbo : IDataMapper<Service_PriceDbo>
    {
        public string id { get; set; }
        public decimal service_Laundry_price { get; set; }
        public decimal service_DryCleaning_price { get; set; }

        public Service_PriceDbo Map(System.Data.IDataReader reader)
        {
            Service_PriceDbo obj = new Service_PriceDbo();
            obj.id = reader["id"].ToString();
            obj.service_Laundry_price = reader["service_laundry_price"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["service_Laundry_price"]);
            obj.service_DryCleaning_price = reader["service_dryclean_price"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["service_dryclean_price"]); 
            return obj;
        }
    }
}




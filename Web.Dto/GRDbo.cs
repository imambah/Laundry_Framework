
using DataAccessLayer;
using System;
namespace Web.Dto
{
    public class GRDbo : IDataMapper<GRDbo>
    {
        public int RecordID { get; set; }
        public string PO_Number { get; set; }
        public string GR_Number { get; set; }
        public string supplier_id { get; set; }
        public string supplier_name { get; set; }
        public int is_delete { get; set; }
        public DateTime? tgl_po { get; set; }
        public GRDbo Map(System.Data.IDataReader reader)
        {
            GRDbo obj = new GRDbo();
            obj.RecordID = Convert.ToInt32(reader["RecordID"]);
            obj.PO_Number = reader["PO_Number"] == DBNull.Value ? "" : reader["PO_Number"].ToString();
            obj.GR_Number = reader["GR_Number"] == DBNull.Value ? "" : reader["GR_Number"].ToString();
            obj.supplier_id = reader["supplier_id"] == DBNull.Value ? "" : reader["supplier_id"].ToString();
            obj.supplier_name = reader["supplier_name"] == DBNull.Value ? "" : reader["supplier_name"].ToString();
            obj.is_delete = reader["is_delete"] == DBNull.Value ? 0 : Convert.ToInt32(reader["is_delete"]);
            obj.tgl_po = reader["tgl_po"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["tgl_po"]);
            return obj;
        }
    }
}




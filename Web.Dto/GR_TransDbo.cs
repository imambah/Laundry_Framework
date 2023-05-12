
using DataAccessLayer;
using System;
namespace Web.Dto
{
    public class GR_TransDbo : IDataMapper<GR_TransDbo>
    {
        public int RecordID { get; set; }
        public string PO_Number { get; set; }
        public DateTime? tgl_po { get; set; }
        public string supplier_id { get; set; }
        public string supplier_name { get; set; }
        public DateTime? rencana_kirim { get; set; }
        public string cara_bayar { get; set; }
        public string PO_description { get; set; }

        public GR_TransDbo Map(System.Data.IDataReader reader)
        {
            GR_TransDbo obj = new GR_TransDbo();
            obj.RecordID = Convert.ToInt32(reader["RecordID"]);
            obj.PO_Number = reader["PO_Number"] == DBNull.Value ? "" : reader["PO_Number"].ToString();
            obj.supplier_id = reader["supplier_id"] == DBNull.Value ? "" : reader["supplier_id"].ToString();
            obj.supplier_name = reader["supplier_name"] == DBNull.Value ? "" : reader["supplier_name"].ToString();
            obj.tgl_po = reader["tgl_po"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["tgl_po"]);
            obj.rencana_kirim = reader["rencana_kirim"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["rencana_kirim"]);
            obj.cara_bayar = reader["cara_bayar"] == DBNull.Value ? "" : reader["cara_bayar"].ToString();
            obj.PO_description = reader["PO_description"] == DBNull.Value ? "" : reader["PO_description"].ToString();
            return obj;
        }
    }
}




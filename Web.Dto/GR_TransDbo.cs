
using DataAccessLayer;
using System;
namespace Web.Dto
{
    public class GR_TransDbo : IDataMapper<GR_TransDbo>
    {
        public int RecordID { get; set; }
        public string PO_Number { get; set; }
        public string supplier_id { get; set; }
        public string supplier_name { get; set; }
        public DateTime? tgl_po { get; set; }
        public DateTime? rencana_kirim { get; set; }
        public string cara_bayar { get; set; }
        public string PO_description { get; set; }
        /// <summary>
        /// detaillllllllllllllllll
        /// </summary>
        /// 
        public int RecordID_det { get; set; }
        public int po_line { get; set; }
        public string item_code { get; set; }
        public string item_name { get; set; }
        public double price { get; set; }
        public string uom { get; set; }
        public int qty { get; set; }
        public double total { get; set; }
        public int sisa { get; set; }
        public string keterangan { get; set; }
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

            obj.RecordID = Convert.ToInt32(reader["RecordID_det"]);
            obj.po_line = reader["PO_line"] == DBNull.Value ? 0 : Convert.ToInt32(reader["PO_line"]);
            obj.item_code = reader["ItemCode"] == DBNull.Value ? "" : reader["ItemCode"].ToString();
            obj.item_name = reader["ItemDesc"] == DBNull.Value ? "" : reader["ItemDesc"].ToString();
            obj.price = reader["Price"] == DBNull.Value ? 0 : Convert.ToDouble(reader["Price"]);
            obj.uom = reader["Uom"] == DBNull.Value ? "" : reader["Uom"].ToString();
            obj.qty = reader["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Quantity"]);
            obj.total = reader["Total"] == DBNull.Value ? 0 : Convert.ToDouble(reader["Total"]);
            obj.sisa = reader["sisa"] == DBNull.Value ? 0 : Convert.ToInt32(reader["sisa"]);
            obj.keterangan = reader["keterangan"] == DBNull.Value ? "" : reader["keterangan"].ToString();
            return obj;
        }
    }
}





using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using Web.Dto;
using System.Data;
namespace Web.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_log]
    /// </summary>    
    public partial class POItem
    {
        public static List<PODbo> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "sp_PO_GetAll";
            //context.AddParameter("@branchid", strBranchID);
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper(context, new PODbo());
        }

        public static PO_HeaderDbo Insert_Header(PO_HeaderDbo obj)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "[sp_PO_Insert_Header]";
            context.AddParameter("@po_number", obj.PO_number);
            context.AddParameter("@po_date", obj.PO_date);
            context.AddParameter("@customerid", obj.customerid);
            context.AddParameter("@customername", obj.customername);
            context.AddParameter("@delivery_date_plant", obj.DeliveryDatePlan);
            context.AddParameter("@tof", obj.Term_Of_Payment);

            context.AddParameter("@po_description", obj.PO_Description);
            context.AddParameter("@branchid", obj.BranchID);
            context.AddParameter("@billto_id", obj.Billto_Id);
            context.AddParameter("@billto_name", obj.Billto_Name);
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper<PO_HeaderDbo>(context, new PO_HeaderDbo()).FirstOrDefault();
        }

        public static PO_DetailDbo Insert_Detail(PO_DetailDbo obj)
        {

            IDBHelper context = new DBHelper();
            string sqlQuery = "[sp_PO_Insert_Detail]";
            context.AddParameter("@po_number", obj.PO_number);
            context.AddParameter("@po_line", obj.PO_line);
            context.AddParameter("@itemcode", obj.ItemCode);
            context.AddParameter("@price", obj.Price);
            context.AddParameter("@uom", obj.UOM);
            context.AddParameter("@quantity", obj.Qty);

            context.AddParameter("@quantity_outstanding", obj.Qty_Outstanding);
            context.AddParameter("@disc", obj.Disc);
            context.AddParameter("@total", obj.Total);
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper<PO_DetailDbo>(context, new PO_DetailDbo()).FirstOrDefault();
        }

        public static List<GR_TransDbo> getItemBarang(string po_no)
        {

            IDBHelper context = new DBHelper();
            context.CommandType = CommandType.StoredProcedure;
            context.CommandText = "sp_PO_GetItemByPO";
            context.AddParameter("@po_no", po_no);
            return DBUtil.ExecuteMapper(context, new GR_TransDbo());
        }

        public static PODbo GetByPo(string po_no)
        {
            IDBHelper context = new DBHelper();
            context.CommandType = CommandType.StoredProcedure;
            context.CommandText = "[sp_PO_Getby_PONO]";
            context.AddParameter("@po_no", po_no);
            return DBUtil.ExecuteMapper<PODbo>(context, new PODbo()).FirstOrDefault();
        }

        public static PODbo Update(PODbo objPO, string is_delete)
        {

            IDBHelper context = new DBHelper();
            context.AddParameter("@po_no", objPO.PO_number);
            //context.AddParameter("@update_by", objPO.EntryByUser);
            context.AddParameter("@is_delete", is_delete);
            string sqlQuery = "[sp_PO_Delete]";
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper<PODbo>(context, new PODbo()).FirstOrDefault();
        }
    }
}

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
    public partial class GRItem
    {
        public static List<GRDbo> GetAll(string strBranchID)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "sp_GR_GetAll";          
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper(context, new GRDbo());
        }

        public static List<GR_TransDbo> Get_GRTransaction(string po_no)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "[sp_GR_GetTransaction_ByPoNo]";
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            context.AddParameter("@po_no", po_no);
            return DBUtil.ExecuteMapper(context, new GR_TransDbo());

            //return DBUtil.ExecuteMapper<Service_PriceDbo>(context, new Service_PriceDbo()).FirstOrDefault();
        }
        //Get_GRTransaction(po_no);

        public static GR_HeaderDbo Insert_Header(GR_HeaderDbo obj)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "[sp_GR_Insert_Header]";
            context.AddParameter("@gr_number", obj.GR_Number);
            context.AddParameter("@po_number", obj.PO_Number);
            context.AddParameter("@supplierid", obj.supplierid);
            context.AddParameter("@rencana_kirim", obj.DO_date);
            context.AddParameter("@po_description", obj.PO_Description);
            context.AddParameter("@branchid", obj.BranchID);
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper<GR_HeaderDbo>(context, new GR_HeaderDbo()).FirstOrDefault();
        }

        public static GR_DetailDbo Insert_Detail(GR_DetailDbo obj, string po_no)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "[sp_GR_Insert_Detail]";
            context.AddParameter("@gr_number", obj.GR_Number);
            context.AddParameter("@gr_line", obj.GR_line);
            context.AddParameter("@item_code", obj.Item_Code);
            context.AddParameter("@quantity", obj.qty);
            context.AddParameter("@po_no", po_no);
            context.AddParameter("@keterangan", obj.keterangan);
            context.AddParameter("@price", obj.Price_Sales);
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper<GR_DetailDbo>(context, new GR_DetailDbo()).FirstOrDefault();
        }


        public static List<GR_DetailDbo> getItemBarang(string po_no)
        {

            IDBHelper context = new DBHelper();
            context.CommandType = CommandType.StoredProcedure;
            context.CommandText = "sp_GR_GetTransaction_ByPoNo";
            context.AddParameter("@po_no", po_no);
            return DBUtil.ExecuteMapper(context, new GR_DetailDbo());
        }
    }
}
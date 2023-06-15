
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
    public partial class APItem
    {
        public static List<APDbo> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "sp_AP_GetAll";          
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper(context, new APDbo());
        }

        public static List<AP_DetailDbo> GetDetailByID(string supplier_id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "[sp_AP_GetItem_byID]";
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            context.AddParameter("@supplier_id", supplier_id);
            return DBUtil.ExecuteMapper(context, new AP_DetailDbo());

        }

        public static AP_BayarDbo Insert(AP_BayarDbo obj)
        {

            IDBHelper context = new DBHelper();
            string sqlQuery = "[sp_GR_SettleAP]";
            context.AddParameter("@gr_no", obj.GR_No);
            context.AddParameter("@nilai_bayar", obj.BayarHutang);
            context.AddParameter("@create_by", obj.Create_By);

            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper<AP_BayarDbo>(context, new AP_BayarDbo()).FirstOrDefault();
        }
    }
}
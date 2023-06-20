
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
    public partial class VoucherItem
    {
        public static List<VoucherDbo> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "[sp_Voucher_GetAll]";
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper(context, new VoucherDbo());
        }
        public static VoucherDbo Insert(VoucherDbo obj)
        {

            IDBHelper context = new DBHelper();
            string sqlQuery = "[sp_Voucher_Insert]";
            context.AddParameter("@voucher_code", obj.voucher_code);
            context.AddParameter("@voucher_date", obj.voucher_date);
            context.AddParameter("@description", obj.description);
            context.AddParameter("@nominal", obj.nominal);
            context.AddParameter("@status", obj.status);
            context.AddParameter("@create_by", obj.create_by);
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper<VoucherDbo>(context, new VoucherDbo()).FirstOrDefault();
        }

        

        #region Data Access

        #endregion

    }
}
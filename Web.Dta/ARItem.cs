
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
    public partial class ARItem
    {
              

        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_log]
        /// </summary>        
        public static AR_BayarDbo Insert(AR_BayarDbo obj)
        {
           
            IDBHelper context = new DBHelper();
            string sqlQuery = "sp_Invoice_SettleAR";
            context.AddParameter("@invoice_no", obj.Invoice_No);
            context.AddParameter("@nilai_bayar", obj.BayarPiutang);
            context.AddParameter("@create_by", obj.Create_By);

            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper<AR_BayarDbo>(context, new AR_BayarDbo()).FirstOrDefault();
        }

       
        #endregion

    }
}
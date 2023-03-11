
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
    public partial class InvoiceItem
    {
        public static List<InvoiceDbo> GetItemByParam(string strType, string CustomerID, string Periode)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "sp_Invoice_Get";
            context.CommandText = sqlQuery;
            context.AddParameter("@type", strType);
            context.AddParameter("@customerid", CustomerID);
            context.AddParameter("@periode", Periode);
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper(context, new InvoiceDbo());
        }

       

        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_log]
        /// </summary>        
      
       

        #endregion

    }
}
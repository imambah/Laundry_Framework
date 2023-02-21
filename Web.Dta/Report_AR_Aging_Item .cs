
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using Web.Dto;
using System.Data;
namespace Web.Dta
{
    /// <summary>
    /// Dta Class of TABLE [sp_report_AR_Aging]
    /// </summary>    
    public partial class Report_AR_Aging_Item
    {
        public static List<Report_AR_Aging_Dbo> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "sp_report_AR_Aging";
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper(context, new Report_AR_Aging_Dbo());
        }

        #region Data Access     
        #endregion

    }
}
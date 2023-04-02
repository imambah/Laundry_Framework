
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
        public static List<Report_ARDbo> GetDetail(string custid)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "sp_report_AR_Aging_Detail";
            context.AddParameter("param", custid); //sementara hardcode
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper(context, new Report_ARDbo());
        }

        #region Data Access     
        #endregion

    }
}
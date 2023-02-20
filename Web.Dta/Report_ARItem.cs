
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using Web.Dto;
using System.Data;
namespace Web.Dta
{
    /// <summary>
    /// Dta Class of TABLE [sp_report_AR]
    /// </summary>    
    public partial class Report_ARItem
    {
        public static List<Report_ARDbo> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "sp_report_AR";
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper(context, new Report_ARDbo());
        }
        public static List<Report_ARDbo> GetDetail(string custid)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "sp_report_AR_Detail";
            context.AddParameter("param", "A001"); //sementara hardcode
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper(context, new Report_ARDbo());
        }

        #region Data Access     
        #endregion

    }
}
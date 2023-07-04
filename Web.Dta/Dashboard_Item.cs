
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
    public partial class Dashboard_Item
    {
        public static List<DashboardDbo> GetARByBranch(string bulan , string tahun)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "[sp_Dashboard_AR_ByBranch]";          
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            context.AddParameter("@bulan", Convert.ToInt32(bulan));
            context.AddParameter("@tahun", Convert.ToInt32(tahun));
            return DBUtil.ExecuteMapper(context, new DashboardDbo());
        }
        public static List<DashboardDbo> GetAPByBranch(string bulan, string tahun)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "[sp_Dashboard_AP_ByBranch]";
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            context.AddParameter("@bulan", Convert.ToInt32(bulan));
            context.AddParameter("@tahun", Convert.ToInt32(tahun));
            return DBUtil.ExecuteMapper(context, new DashboardDbo());
        }



    }
}
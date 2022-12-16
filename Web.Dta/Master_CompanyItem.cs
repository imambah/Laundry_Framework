
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
    public partial class Master_CompanyItem
    {
        public static List<CompanyDbo> GetBranch()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "sp_GetCompany";
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper(context, new CompanyDbo());
        }
        #region Data Access

        #endregion

    }
}

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
    public partial class Master_NegaraItem
    {
        public static List<Master_NegaraDbo> GetNegara()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "sp_master_negara_GetAll";
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper(context, new Master_NegaraDbo());
        }
        #region Data Access

        #endregion

    }
}
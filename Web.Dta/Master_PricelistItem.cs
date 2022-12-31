
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
    public partial class Master_PricelistItem
    {
        public static List<Master_PricelistDbo> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "sp_master_pricelist_GetAll";
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper(context, new Master_PricelistDbo());
        }
        #region Data Access

        #endregion

    }
}
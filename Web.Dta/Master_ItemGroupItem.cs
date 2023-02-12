
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
    public partial class Master_ItemGroupItem
    {
        public static List<ItemGroupDbo> GetItemGroupALL()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "sp_GetItemGroup";
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper(context, new ItemGroupDbo());
        }

        public static List<ItemGroupDbo> GetItemParameterByTable(string tbl)
        {
            IDBHelper context = new DBHelper();
            context.CommandType = CommandType.StoredProcedure;
            context.CommandText = "sp_lookup_parameter";
            context.AddParameter("@table", tbl);
            return DBUtil.ExecuteMapper(context, new ItemGroupDbo());
        }
        #region Data Access

        #endregion

    }
}
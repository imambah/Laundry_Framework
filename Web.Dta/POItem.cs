
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
    public partial class POItem
    {
        public static List<PODbo> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "sp_PO_GetAll";
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper(context, new PODbo());
        }

        //public static BOMDbo GetById(int id)
        //{

        //    IDBHelper context = new DBHelper();
        //    context.CommandType = CommandType.StoredProcedure;
        //    context.CommandText = "[sp_BOM_GetById]";
        //    context.AddParameter("@id", id);
        //    return DBUtil.ExecuteMapper<BOMDbo>(context, new BOMDbo()).FirstOrDefault();
        //}

        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_log]
        /// </summary>        
      

        #endregion

        #region
        
        #endregion
    }
}
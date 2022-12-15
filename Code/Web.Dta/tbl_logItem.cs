
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
    public partial class tbl_logItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_log]
        /// </summary>        
        public static tbl_log Insert(tbl_log obj)
        {
             IDBHelper context = new DBHelper();
             string sqlQuery = "Gen_tbl_log_Insert";
             context.AddParameter("@created", obj.created);
             context.AddParameter("@text_message", obj.text_message);
             context.AddParameter("@log_type", obj.log_type);
             context.AddParameter("@current_login", obj.current_login);
             context.AddParameter("@ip_address", obj.ip_address);
             context.CommandText = sqlQuery;
             context.CommandType = CommandType.StoredProcedure;
             return DBUtil.ExecuteMapper<tbl_log>(context, new tbl_log()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_log]
        /// </summary>        
        public static tbl_log Update(tbl_log obj)
        {
             IDBHelper context = new DBHelper();
             context.AddParameter("@text_message", obj.text_message);
             context.AddParameter("@log_type", obj.log_type);
             context.AddParameter("@current_login", obj.current_login);
             context.AddParameter("@ip_address", obj.ip_address);
             string sqlQuery = "Gen_tbl_log_Update";
             context.CommandText = sqlQuery;
             context.CommandType = CommandType.StoredProcedure;
             return DBUtil.ExecuteMapper<tbl_log>(context, new tbl_log()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_log]
        /// </summary>        
        public static int Delete(Int64 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery ="Gen_tbl_log_Delete";
            context.CommandText = sqlQuery;
            context.AddParameter("@id", id);
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteNonQuery(context);
        }
        public static int GetCount(int PageSize, int PageIndex)
        {
            return GetTotalRecord();
        }
        /// <summary>
        /// Get Total records from [tbl_log]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "Gen_tbl_log_GetTotalRecord";
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
        }

        /// <summary>
        /// Get All records from TABLE [tbl_log]
        /// </summary>        
        public static List<tbl_log> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "Gen_tbl_log_GetAll";
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper<tbl_log>(context, new tbl_log());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_log]
        /// </summary>        
        public static List<tbl_log> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            long FirstRow = ((long)PageIndex * (long)PageSize) + 1;
            long LastRow = ((long)PageIndex * (long)PageSize) + PageSize;
            string sqlQuery = "Gen_tbl_log_GetAll_WithPaging";
            context.AddParameter("@FirstRow", FirstRow);
            context.AddParameter("@LastRow", LastRow);
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper<tbl_log>(context, new tbl_log());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_log] by Primary Key
        /// </summary>        
        public static tbl_log GetByPK(Int64 id)
        {
            IDBHelper context = new DBHelper();
            context.CommandType = CommandType.StoredProcedure;
            context.CommandText = "Gen_tbl_log_GetByPK";
            context.AddParameter("@id", id);
            return DBUtil.ExecuteMapper<tbl_log>(context, new tbl_log()).FirstOrDefault();
        }

        #endregion

    }
}
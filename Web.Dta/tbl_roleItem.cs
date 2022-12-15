
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using Web.Dto;
using System.Data;
namespace Web.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_role]
    /// </summary>    
    public partial class tbl_roleItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_role]
        /// </summary>        
        public static tbl_role Insert(tbl_role obj)
        {
             IDBHelper context = new DBHelper();
             string sqlQuery = "Gen_tbl_role_Insert";
             context.AddParameter("@Name", obj.Name);
             context.AddParameter("@Description", obj.Description);
             context.AddParameter("@is_deleted", obj.is_deleted);
             context.AddParameter("@created", obj.created);
             context.AddParameter("@creator", obj.creator);
             context.AddParameter("@edited", obj.edited);
             context.AddParameter("@editor", obj.editor);
             context.CommandText = sqlQuery;
             context.CommandType = CommandType.StoredProcedure;
             return DBUtil.ExecuteMapper<tbl_role>(context, new tbl_role()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_role]
        /// </summary>        
        public static tbl_role Update(tbl_role obj)
        {
             IDBHelper context = new DBHelper();
             context.AddParameter("@Name", obj.Name);
             context.AddParameter("@Description", obj.Description);
             context.AddParameter("@is_deleted", obj.is_deleted);
             context.AddParameter("@creator", obj.creator);
             context.AddParameter("@edited", obj.edited);
             context.AddParameter("@editor", obj.editor);
             string sqlQuery = "Gen_tbl_role_Update";
             context.CommandText = sqlQuery;
             context.CommandType = CommandType.StoredProcedure;
             return DBUtil.ExecuteMapper<tbl_role>(context, new tbl_role()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_role]
        /// </summary>        
        public static int Delete(Int32 ID)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery ="Gen_tbl_role_Delete";
            context.CommandText = sqlQuery;
            context.AddParameter("@ID", ID);
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteNonQuery(context);
        }
        public static int GetCount(int PageSize, int PageIndex)
        {
            return GetTotalRecord();
        }
        /// <summary>
        /// Get Total records from [tbl_role]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "Gen_tbl_role_GetTotalRecord";
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
        }

        /// <summary>
        /// Get All records from TABLE [tbl_role]
        /// </summary>        
        public static List<tbl_role> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "Gen_tbl_role_GetAll";
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper<tbl_role>(context, new tbl_role());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_role]
        /// </summary>        
        public static List<tbl_role> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            long FirstRow = ((long)PageIndex * (long)PageSize) + 1;
            long LastRow = ((long)PageIndex * (long)PageSize) + PageSize;
            string sqlQuery = "Gen_tbl_role_GetAll_WithPaging";
            context.AddParameter("@FirstRow", FirstRow);
            context.AddParameter("@LastRow", LastRow);
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper<tbl_role>(context, new tbl_role());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_role] by Primary Key
        /// </summary>        
        public static tbl_role GetByPK(Int32 ID)
        {
            IDBHelper context = new DBHelper();
            context.CommandType = CommandType.StoredProcedure;
            context.CommandText = "Gen_tbl_role_GetByPK";
            context.AddParameter("@ID", ID);
            return DBUtil.ExecuteMapper<tbl_role>(context, new tbl_role()).FirstOrDefault();
        }

        #endregion

    }
}
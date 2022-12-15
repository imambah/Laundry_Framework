
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using Web.Dto;
using System.Data;
namespace Web.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_user_role]
    /// </summary>    
    public partial class tbl_user_roleItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_user_role]
        /// </summary>        
        public static tbl_user_role Insert(tbl_user_role obj)
        {
             IDBHelper context = new DBHelper();
             string sqlQuery = "Gen_tbl_user_role_Insert";
             context.AddParameter("@Username", obj.Username);
             context.AddParameter("@RoleID", obj.RoleID);
             context.CommandText = sqlQuery;
             context.CommandType = CommandType.StoredProcedure;
             return DBUtil.ExecuteMapper<tbl_user_role>(context, new tbl_user_role()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_user_role]
        /// </summary>        
        public static tbl_user_role Update(tbl_user_role obj)
        {
             IDBHelper context = new DBHelper();
             context.AddParameter("@Username", obj.Username);
             context.AddParameter("@RoleID", obj.RoleID);
             string sqlQuery = "Gen_tbl_user_role_Update";
             context.CommandText = sqlQuery;
             context.CommandType = CommandType.StoredProcedure;
             return DBUtil.ExecuteMapper<tbl_user_role>(context, new tbl_user_role()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_user_role]
        /// </summary>        
        public static int Delete(Int32 ID)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery ="Gen_tbl_user_role_Delete";
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
        /// Get Total records from [tbl_user_role]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "Gen_tbl_user_role_GetTotalRecord";
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
        }

        /// <summary>
        /// Get All records from TABLE [tbl_user_role]
        /// </summary>        
        public static List<tbl_user_role> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "Gen_tbl_user_role_GetAll";
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper<tbl_user_role>(context, new tbl_user_role());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_user_role]
        /// </summary>        
        public static List<tbl_user_role> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            long FirstRow = ((long)PageIndex * (long)PageSize) + 1;
            long LastRow = ((long)PageIndex * (long)PageSize) + PageSize;
            string sqlQuery = "Gen_tbl_user_role_GetAll_WithPaging";
            context.AddParameter("@FirstRow", FirstRow);
            context.AddParameter("@LastRow", LastRow);
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper<tbl_user_role>(context, new tbl_user_role());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_user_role] by Primary Key
        /// </summary>        
        public static tbl_user_role GetByPK(Int32 ID)
        {
            IDBHelper context = new DBHelper();
            context.CommandType = CommandType.StoredProcedure;
            context.CommandText = "Gen_tbl_user_role_GetByPK";
            context.AddParameter("@ID", ID);
            return DBUtil.ExecuteMapper<tbl_user_role>(context, new tbl_user_role()).FirstOrDefault();
        }

        /// <summary>
        /// Get All records of TABLE [tbl_user_role] by TABLE [tbl_role]
        /// </summary>
        public static List<tbl_user_role> GetByRoleID(Int32? RoleID)
        {
            IDBHelper context = new DBHelper();
            context.CommandType = System.Data.CommandType.Text;
            string sqlQuery =@"
SELECT  ID, Username, RoleID
FROM    [tbl_user_role]
WHERE   [RoleID] = @RoleID";

            context.AddParameter("@RoleID", RoleID);
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_user_role>(context, new tbl_user_role());
        }

        /// <summary>
        /// Get All records of TABLE [tbl_user_role] by TABLE [tbl_role] (with Paging)
        /// </summary>
        public static List<tbl_user_role> GetByRoleID(Int32? RoleID, int PageSize, int PageIndex)
        {
            long FirstRow = ((long)PageIndex * (long)PageSize) + 1;
            long LastRow = ((long)PageIndex * (long)PageSize) + PageSize;
            
            IDBHelper context = new DBHelper();
            context.CommandType = System.Data.CommandType.Text;
            string sqlQuery =@"
WITH [Paging_tbl_user_role] AS
(
    SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_user_role].[ID]) AS PAGING_ROW_NUMBER,
            [tbl_user_role].*
    FROM    [tbl_user_role]
    WHERE   [RoleID] = @RoleID
)

SELECT      [Paging_tbl_user_role].*
FROM        [Paging_tbl_user_role]
WHERE		PAGING_ROW_NUMBER BETWEEN @FirstRow AND @LastRow";

            context.AddParameter("@RoleID", RoleID);
            return DBUtil.ExecuteMapper<tbl_user_role>(context, new tbl_user_role());
        }

        #endregion

    }
}
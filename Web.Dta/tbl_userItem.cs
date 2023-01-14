
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using Web.Dto;
using System.Data;
namespace Web.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_user]
    /// </summary>    
    public partial class tbl_userItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_user]
        /// </summary>        
        public static tbl_user Insert(tbl_user obj)
        {
            //obj.BranchName = "";
             IDBHelper context = new DBHelper();
             string sqlQuery = "Gen_tbl_user_Insert";
             context.AddParameter("@Username", obj.Username);
             context.AddParameter("@Password", obj.Password);
             context.AddParameter("@LastLogin", obj.LastLogin);
             context.AddParameter("@IsLogin", obj.IsLogin);
             context.AddParameter("@IPAddress", obj.IPAddress);
             context.AddParameter("@MachineName", obj.MachineName);
      
             context.AddParameter("@FullName", obj.FullName);
             context.AddParameter("@created", obj.created);
             context.AddParameter("@creator", obj.creator);
             context.AddParameter("@edited", obj.edited);
             context.AddParameter("@editor", obj.editor);
             context.AddParameter("@IsActive", obj.IsActive);
             context.AddParameter("@UserGroup", obj.UserGroup);
             context.AddParameter("@Branch", obj.Branch);
            
             context.CommandText = sqlQuery;
             context.CommandType = CommandType.StoredProcedure;
             return DBUtil.ExecuteMapper<tbl_user>(context, new tbl_user()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_user]
        /// </summary>        
        public static tbl_user Update(tbl_user obj , string is_delete)
        {
            /*
              @Username VARCHAR(50) = NULL,
    @Password VARCHAR(1000) = NULL,
    @LastLogin DATETIME = NULL,
    @IsLogin INT = NULL,
    @IPAddress VARCHAR(15) = NULL,
    @MachineName VARCHAR(100) = NULL,
    @FullName VARCHAR(500) = NULL,
    @created DATETIME = NULL,
    @creator VARCHAR(50) = NULL,
    @edited DATETIME = NULL,
    @editor VARCHAR(50) = NULL,
    @IsActive NVARCHAR(1)= NULL,
	@Branch NVARCHAR(30) = NULL,
	@UserGroup NVARCHAR(30) = NULL,
	@kode_perusahaan nvarchar(50) = NULL
             */
            IDBHelper context = new DBHelper();
             context.AddParameter("@Username", obj.Username);
             context.AddParameter("@Password", obj.Password);
             context.AddParameter("@LastLogin", obj.LastLogin);
             context.AddParameter("@IsLogin", obj.IsLogin);
             context.AddParameter("@IPAddress", obj.IPAddress);
             context.AddParameter("@MachineName", obj.MachineName);
             context.AddParameter("@FullName", obj.FullName);
             context.AddParameter("@creator", obj.creator);
             context.AddParameter("@edited", obj.edited);
             context.AddParameter("@editor", obj.editor);
             context.AddParameter("@IsActive", is_delete);
             context.AddParameter("@UserGroup", obj.UserGroup);
             context.AddParameter("@Branch", obj.Branch);
             //context.AddParameter("@kode_perusahaan", obj.kode_perusahaan);
             //context.AddParameter("@nama_perusahaan", obj.nama_perusahaan);
            string sqlQuery = "Gen_tbl_user_Update";
             context.CommandText = sqlQuery;
             context.CommandType = CommandType.StoredProcedure;
             return DBUtil.ExecuteMapper<tbl_user>(context, new tbl_user()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_user]
        /// </summary>        
        public static int Delete(string Username)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery ="Gen_tbl_user_Delete";
            context.CommandText = sqlQuery;
            context.AddParameter("@Username", Username);
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteNonQuery(context);
        }
        public static int GetCount(int PageSize, int PageIndex)
        {
            return GetTotalRecord();
        }
        /// <summary>
        /// Get Total records from [tbl_user]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "Gen_tbl_user_GetTotalRecord";
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
        }

        /// <summary>
        /// Get All records from TABLE [tbl_user]
        /// </summary>        
        public static List<tbl_user> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "Gen_tbl_user_GetAll";
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper<tbl_user>(context, new tbl_user());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_user]
        /// </summary>        
        public static List<tbl_user> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            long FirstRow = ((long)PageIndex * (long)PageSize) + 1;
            long LastRow = ((long)PageIndex * (long)PageSize) + PageSize;
            string sqlQuery = "Gen_tbl_user_GetAll_WithPaging";
            context.AddParameter("@FirstRow", FirstRow);
            context.AddParameter("@LastRow", LastRow);
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper<tbl_user>(context, new tbl_user());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_user] by Primary Key
        /// </summary>        
        public static tbl_user GetByPK(string Username)
        {
            IDBHelper context = new DBHelper();
            context.CommandType = CommandType.StoredProcedure;
            context.CommandText = "Gen_tbl_user_GetByPK";
            context.AddParameter("@Username", Username);
            return DBUtil.ExecuteMapper<tbl_user>(context, new tbl_user()).FirstOrDefault();
        }


        #endregion

    }
}
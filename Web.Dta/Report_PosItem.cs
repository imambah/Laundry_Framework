
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
    public partial class Report_PosItem
    {


        public static string GetKetentuan()
        {
            string strKetentuan = "";
            IDBHelper context = new DBHelper();
            //string sqlQuery = "sp_parameter_Ketentuan";
            string sqlQuery = "sp_parameter_Ketentuan";
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                strKetentuan = obj.ToString();
            return strKetentuan;
        }

        public static string Get_workshop()
        {
            string strWorkshop = "";
            IDBHelper context = new DBHelper();
            //string sqlQuery = "sp_klien_workshop";
            string sqlQuery = "sp_klien_workshop";
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                strWorkshop = obj.ToString();
            return strWorkshop;
        }

    }
}
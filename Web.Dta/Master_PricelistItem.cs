
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
        public static Master_PricelistDbo Insert(Master_PricelistDbo obj)
        {
            Random rdm = new Random();
            //int NoRdm = rdm.Next(1, 100000);

            //string ItemCode = "I" + NoRdm;

            IDBHelper context = new DBHelper();
            string sqlQuery = "sp_master_pricelist_Insert";
            context.AddParameter("@type", obj.type);
            context.AddParameter("@service", obj.service);
            context.AddParameter("@laundry", obj.laundry);
            context.AddParameter("@dry_clean", obj.dry_clean);
            context.AddParameter("@create_date", DateTime.Now);
            context.AddParameter("@create_by", "user_system");
            context.AddParameter("@update_date", DateTime.Now);
            context.AddParameter("@update_by", "user_system");
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper<Master_PricelistDbo>(context, new Master_PricelistDbo()).FirstOrDefault();
        }

        public static Master_PricelistDbo GetById(int id)
        {

            IDBHelper context = new DBHelper();
            context.CommandType = CommandType.StoredProcedure;
            context.CommandText = "sp_master_pricelist_GetById";
            context.AddParameter("@id", id);
            return DBUtil.ExecuteMapper<Master_PricelistDbo>(context, new Master_PricelistDbo()).FirstOrDefault();
        }

        public static Master_PricelistDbo Update(Master_PricelistDbo obj, string is_delete)
        {

            IDBHelper context = new DBHelper();
            context.AddParameter("@id", obj.id);
            context.AddParameter("@type", obj.type);
            context.AddParameter("@service", obj.service);
            context.AddParameter("@laundry", obj.laundry);
            context.AddParameter("@dry_clean", obj.dry_clean);
            context.AddParameter("@update_date", DateTime.Now);
            context.AddParameter("@update_by", "user_system_update");
            context.AddParameter("@is_delete", is_delete);
            string sqlQuery = "sp_master_pricelist_Update";
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper<Master_PricelistDbo>(context, new Master_PricelistDbo()).FirstOrDefault();
        }


        
        #endregion



    }
}
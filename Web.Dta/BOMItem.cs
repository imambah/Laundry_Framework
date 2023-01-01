
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
    public partial class BOMItem
    {
        public static List<BOMDbo> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "sp_BOM_GetAll";
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper(context, new BOMDbo());
        }

        public static BOMDbo GetById(int id)
        {

            IDBHelper context = new DBHelper();
            context.CommandType = CommandType.StoredProcedure;
            context.CommandText = "[sp_BOM_GetById]";
            context.AddParameter("@id", id);
            return DBUtil.ExecuteMapper<BOMDbo>(context, new BOMDbo()).FirstOrDefault();
        }

        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_log]
        /// </summary>        
        public static BOMDbo Insert(BOMDbo obj)
        {

            IDBHelper context = new DBHelper();
            string sqlQuery = "[sp_BOM_Insert]";
            context.AddParameter("@kode_BOM", obj.kode_BOM);
            context.AddParameter("@keterangan_BOM", obj.keterangan_BOM);
            context.AddParameter("@harga_jual", obj.harga_jual);
            context.AddParameter("@create_date", DateTime.Now);
            context.AddParameter("@create_by", "user_system");
            context.AddParameter("@update_date", DateTime.Now);
            context.AddParameter("@update_by", "user_system");
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper<BOMDbo>(context, new BOMDbo()).FirstOrDefault();
        }

        public static BOMDbo Update(BOMDbo obj)
        {

            IDBHelper context = new DBHelper();
            context.AddParameter("@id", obj.id);
            context.AddParameter("@kode_BOM", obj.kode_BOM);
            context.AddParameter("@keterangan_BOM", obj.keterangan_BOM);
            context.AddParameter("@harga_jual", obj.harga_jual);
            context.AddParameter("@update_date", DateTime.Now);
            context.AddParameter("@update_by", "user_system_update");
            string sqlQuery = "[sp_BOM_Update]";
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper<BOMDbo>(context, new BOMDbo()).FirstOrDefault();
        }

        #endregion

        #region
        public static BOMDbo GetMasterDetailByCode(string kode_BOM)
        {
            BOMDbo master = null;
            IDBHelper context = new DBHelper();
            context.CommandType = CommandType.StoredProcedure;
            context.CommandText = "[sp_BOM_Detail_GetByCode]";
            context.AddParameter("@kode_BOM", kode_BOM);
            //return DBUtil.ExecuteMapper<BOMDetailDbo>(context, new BOMDetailDbo()).FirstOrDefault();
            using (IDataReader reader = DBUtil.ExecuteReader(context))
            {
                while (reader.Read())
                {
                    master = new BOMDbo().Map(reader);
                }
                if (master != null)
                {
                    if (reader.NextResult())
                    {
                        master.Details = new List<BOMDetailDbo>();
                        while (reader.Read())
                        {

                            master.Details.Add(new BOMDetailDbo().Map(reader));
                        }
                    }
                }
                // dah jalanin coba cak
            }

            return master;
        }
        #endregion
    }
}
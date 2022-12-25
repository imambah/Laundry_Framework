
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
    public partial class Master_BarangItem
    {
        public static List<Master_BarangDbo> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "sp_master_barang_GetAll";
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper(context, new Master_BarangDbo());
        }

        public static Master_BarangDbo GetById(int id)
        {

            IDBHelper context = new DBHelper();
            context.CommandType = CommandType.StoredProcedure;
            context.CommandText = "sp_master_bank_GetById";
            context.AddParameter("@id", id);
            return DBUtil.ExecuteMapper<Master_BarangDbo>(context, new Master_BarangDbo()).FirstOrDefault();
        }

        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_log]
        /// </summary>        
        public static Master_BarangDbo Insert(Master_BarangDbo obj)
        {
            Random rdm = new Random();
            int NoRdm = rdm.Next(1, 100000);

            string ItemCode = "I" + NoRdm;

            IDBHelper context = new DBHelper();
            string sqlQuery = "sp_master_barang_Insert";
            context.AddParameter("@ItemCode", ItemCode);
            context.AddParameter("@ItemDesc", obj.ItemDesc);
            context.AddParameter("@Barcode", obj.Barcode);
            context.AddParameter("@CategoryID", obj.CategoryID);
            context.AddParameter("@UoM", obj.UoM);
            context.AddParameter("@Price_Purchase", obj.Price_Purchase);
            context.AddParameter("@Price_Inventory", obj.Price_Inventory);
            context.AddParameter("@Stock", obj.Stock);
            context.AddParameter("@Buffer_Stock", obj.Buffer_Stock);
            context.AddParameter("@Company_Persentage", obj.Company_Persentage);
            context.AddParameter("@Vendor_Persentage", obj.Vendor_Persentage);
            context.AddParameter("@Vat_Flag", obj.Vat_Flag);
            context.AddParameter("@Conversion", obj.Conversion);
            context.AddParameter("@BatchNo", obj.Batch_No);
            context.AddParameter("@WarhouseID", obj.Warehouse_ID);
            context.AddParameter("@Group_Code", obj.Group_Code);
            context.AddParameter("@create_date", DateTime.Now);
            context.AddParameter("@create_by", "user_system");
            context.AddParameter("@update_date", DateTime.Now);
            context.AddParameter("@update_by", "user_system");
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper<Master_BarangDbo>(context, new Master_BarangDbo()).FirstOrDefault();
        }

        //public static Master_BankDbo Update(Master_BankDbo obj)
        //{

        //    IDBHelper context = new DBHelper(); 
        //    //context.AddParameter("@kode_klien", obj.kode_klien);
        //    //context.AddParameter("@nama_klien", obj.nama_klien);
        //    //context.AddParameter("@alamat", obj.alamat);
        //    //context.AddParameter("@no_telp", obj.no_telp);
        //    //context.AddParameter("@is_supplier", obj.is_supplier);
        //    //context.AddParameter("@is_customer", obj.is_customer);
        //    //context.AddParameter("@update_date", DateTime.Now);
        //    context.AddParameter("@update_by", "user_system_update");
        //    string sqlQuery = "sp_master_client_Update";
        //    context.CommandText = sqlQuery;
        //    context.CommandType = CommandType.StoredProcedure;
        //    return DBUtil.ExecuteMapper<Master_BankDbo>(context, new Master_BankDbo()).FirstOrDefault();
        //}

        //public static Master_BankDbo Delete(string client_code) {
        //    IDBHelper context = new DBHelper();
        //    context.AddParameter("@kode_klien", client_code);
        //    string sqlQuery = "sp_master_client_Delete";
        //    context.CommandText = sqlQuery;
        //    context.CommandType = CommandType.StoredProcedure;
        //    //return DBUtil.ExecuteNonQuery(context);
        //    return DBUtil.ExecuteMapper<Master_BankDbo>(context, new Master_BankDbo()).FirstOrDefault();
        //}
        #endregion

    }
}

using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using Web.Dto;
using System.Data;
using System.Configuration;
namespace Web.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_log]
    /// </summary>    
    public partial class tbl_parameterItem
    {
        public static List<tbl_parameter> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "sp_parameter_GetAll";
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper(context, new tbl_parameter());
        }

        public static tbl_parameter GetById(int id)
        {
            
            IDBHelper context = new DBHelper();
            context.CommandType = CommandType.StoredProcedure;
            context.CommandText = "sp_parameter_GetById";
            context.AddParameter("@id", id);
            return DBUtil.ExecuteMapper<tbl_parameter>(context, new tbl_parameter()).FirstOrDefault();
        }

        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_log]
        /// </summary>        
        public static tbl_parameter Insert(tbl_parameter obj)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "sp_parameter_Insert";
            context.AddParameter("@nama_tabel", obj.nama_tabel);
            context.AddParameter("@kode_tabel", obj.kode_tabel);
            context.AddParameter("@nama_panjang", obj.nama_panjang);
            context.AddParameter("@nama_pendek", obj.nama_pendek);
            context.AddParameter("@nilai", obj.nilai);
            context.AddParameter("@create_date", DateTime.Now);
            context.AddParameter("@create_by", obj.create_by);
            context.AddParameter("@update_date", "");
            context.AddParameter("@update_by", "");
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
           return DBUtil.ExecuteMapper<tbl_parameter>(context, new tbl_parameter()).FirstOrDefault();
        }

        public static tbl_parameter Update(tbl_parameter obj, string is_delete) {

            IDBHelper context = new DBHelper();
            context.AddParameter("@id", obj.id);
            context.AddParameter("@nama_tabel", obj.nama_tabel);
            context.AddParameter("@kode_tabel", obj.kode_tabel);
            context.AddParameter("@nama_panjang", obj.nama_panjang);
            context.AddParameter("@nama_pendek", obj.nama_pendek);
            context.AddParameter("@nilai", obj.nilai);
            context.AddParameter("@update_date", DateTime.Now);
            context.AddParameter("@update_by", obj.update_by);
            context.AddParameter("@is_delete", is_delete);
            string sqlQuery = "sp_parameter_Update";
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper<tbl_parameter>(context, new tbl_parameter()).FirstOrDefault();
        }


        public static List<tbl_parameter> Pricelist_GetTypeAll()
        {
            IDBHelper context = new DBHelper();
            context.CommandType = CommandType.StoredProcedure;
            context.CommandText = "sp_parameter_GetByType";
            context.AddParameter("@type", "pricelist");
            return DBUtil.ExecuteMapper(context, new tbl_parameter());
        }

        public static NomorDbo getNomer(string strJenis)
        {
            IDBHelper context = new DBHelper();
            context.CommandType = CommandType.StoredProcedure;
            context.CommandText = "[sp_GetNomer]";
            context.AddParameter("@jenis", strJenis);
            return DBUtil.ExecuteMapper<NomorDbo>(context, new NomorDbo()).FirstOrDefault();
        }

        public static string getInvoce_Nomer(string strJenis)
        {
            string GenNo = "";
            int no_seri = 0;
            NomorDbo nomer = tbl_parameterItem.getNomer(strJenis);
            int intID = nomer.id;
            string strTahun = nomer.tahun.ToString();
            string strBulan = nomer.bulan.ToString();
            string strNo = nomer.nomer.ToString();

            DateTime now = DateTime.Now;
            string strYearNow = now.Year.ToString();
            string strMonthNow = now.Month.ToString();

            NomorDbo penomoran = new NomorDbo();
            if (strTahun == strYearNow && strBulan == strMonthNow) {
                no_seri = Convert.ToInt32(strNo) + 1;
                penomoran.id = intID;
                penomoran.tahun = Convert.ToInt32(strTahun);
                penomoran.bulan = Convert.ToInt32(strBulan);
                penomoran.nomer = Convert.ToInt32(no_seri);
                strNo = no_seri.ToString();
            }
            else
            {
                no_seri = Convert.ToInt32(1);
                penomoran.id = intID;
                penomoran.tahun = Convert.ToInt32(strYearNow);
                penomoran.bulan = Convert.ToInt32(strMonthNow);
                penomoran.nomer = Convert.ToInt32(no_seri);
                strNo = no_seri.ToString();
            }

            UpdateNomer(penomoran);

            if (strNo.Length == 1)
            {
                strNo = "00" + strNo;
            }
            else if (strNo.Length == 2)
            {
                strNo = "0" + strNo;
            }
            if (strJenis == "cashin" || strJenis == "cashout")
            {
                GenNo = now.Date.ToString("yyyy") + "." + now.Date.ToString("MM") + "." + now.Date.ToString("dd")+"." + strNo;

            }
            else {
                if (strBulan == "1")
                    strBulan = "I";
                else if (strBulan == "2")
                    strBulan = "II";
                else if (strBulan == "3")
                    strBulan = "III";
                else if (strBulan == "4")
                    strBulan = "IV";
                else if (strBulan == "5")
                    strBulan = "V";
                else if (strBulan == "6")
                    strBulan = "VI";
                else if (strBulan == "7")
                    strBulan = "VII";
                else if (strBulan == "8")
                    strBulan = "VIII";
                else if (strBulan == "9")
                    strBulan = "XI";
                else if (strBulan == "10")
                    strBulan = "X";
                else if (strBulan == "11")
                    strBulan = "XI";
                else if (strBulan == "12")
                    strBulan = "XII";
                GenNo = strNo + "/" + "BiW" + strBulan + "/" + strTahun;
            }
            
            return GenNo;
        }
        #endregion
        public static NomorDbo UpdateNomer(NomorDbo obj)
        {

            IDBHelper context = new DBHelper();
            context.AddParameter("@id", obj.id);
            context.AddParameter("@tahun", obj.tahun);
            context.AddParameter("@bulan", obj.bulan);
            context.AddParameter("@nomer", obj.nomer);

            string sqlQuery = "sp_parameter_Update_Nomer";
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper<NomorDbo>(context, new NomorDbo()).FirstOrDefault();
        }

        public static string getPO_Nomer(string strJenis)
        {
            string GenNo = "";
            int no_seri = 0;
            NomorDbo nomer = tbl_parameterItem.getNomer(strJenis);
            int intID = nomer.id;
            string strTahun = nomer.tahun.ToString();
            string strBulan = nomer.bulan.ToString();
            string strNo = nomer.nomer.ToString();

            DateTime now = DateTime.Now;
            string strYearNow = now.Year.ToString();
            string strMonthNow = now.Month.ToString();

            NomorDbo penomoran = new NomorDbo();
            if (strTahun == strYearNow && strBulan == strMonthNow)
            {
                no_seri = Convert.ToInt32(strNo) + 1;
                penomoran.id = intID;
                penomoran.tahun = Convert.ToInt32(strTahun);
                penomoran.bulan = Convert.ToInt32(strBulan);
                penomoran.nomer = Convert.ToInt32(no_seri);
                strNo = no_seri.ToString();
            }
            else
            {
                no_seri = Convert.ToInt32(1);
                penomoran.id = intID;
                penomoran.tahun = Convert.ToInt32(strYearNow);
                penomoran.bulan = Convert.ToInt32(strMonthNow);
                penomoran.nomer = Convert.ToInt32(no_seri);
                strNo = no_seri.ToString();
            }

            UpdateNomer(penomoran);

            if (strNo.Length == 1)
            {
                strNo = "00" + strNo;
            }
            else if (strNo.Length == 2)
            {
                strNo = "0" + strNo;
            }
            if (strJenis == "gr")
            {
                GenNo = "GR-" + now.Date.ToString("yyyy") + "." + now.Date.ToString("MM") + "." + now.Date.ToString("dd") + "." + strNo;
            }
            else if (strJenis == "po")
            {
                GenNo = "PO-" + now.Date.ToString("yyyy") + "." + now.Date.ToString("MM") + "." + now.Date.ToString("dd") + "." + strNo;
            }
            else {
                GenNo = "VO-" + now.Date.ToString("yyyy") + "." + now.Date.ToString("MM") + "." + now.Date.ToString("dd") + "." + strNo;
            }
            
            return GenNo;
        }

        public static string getVoucher_Nomer(string strJenis)
        {
            string GenNo = "";
            int no_seri = 0;
            NomorDbo nomer = tbl_parameterItem.getNomer(strJenis);
            int intID = nomer.id;
            string strTahun = nomer.tahun.ToString();
            string strBulan = nomer.bulan.ToString();
            string strNo = nomer.nomer.ToString();

            DateTime now = DateTime.Now;
            string strYearNow = now.Year.ToString();
            string strMonthNow = now.Month.ToString();

            NomorDbo penomoran = new NomorDbo();
            if (strTahun == strYearNow && strBulan == strMonthNow)
            {
                no_seri = Convert.ToInt32(strNo) + 1;
                penomoran.id = intID;
                penomoran.tahun = Convert.ToInt32(strTahun);
                penomoran.bulan = Convert.ToInt32(strBulan);
                penomoran.nomer = Convert.ToInt32(no_seri);
                strNo = no_seri.ToString();
            }
            else
            {
                no_seri = Convert.ToInt32(1);
                penomoran.id = intID;
                penomoran.tahun = Convert.ToInt32(strYearNow);
                penomoran.bulan = Convert.ToInt32(strMonthNow);
                penomoran.nomer = Convert.ToInt32(no_seri);
                strNo = no_seri.ToString();
            }

            UpdateNomer(penomoran);

            if (strNo.Length == 1)
            {
                strNo = "00" + strNo;
            }
            else if (strNo.Length == 2)
            {
                strNo = "0" + strNo;
            }
            GenNo = strJenis +"-"+ strNo+ "/" + "BiW" + strBulan + "/" + strTahun;
            return GenNo;
        }
    }
}
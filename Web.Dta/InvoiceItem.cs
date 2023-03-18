
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
    public partial class InvoiceItem
    {
        public static List<InvoiceDbo> GetItemByParam(string strType, string CustomerID, string Periode)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "sp_Invoice_Get";
            context.CommandText = sqlQuery;
            context.AddParameter("@type", strType);
            context.AddParameter("@customerid", CustomerID);
            context.AddParameter("@periode", Periode);
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper(context, new InvoiceDbo());
        }


        public static InvoiceDbo create_invoice_detail(string strInvoice, string strTransaction, string strCustomerID)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "[sp_Invoice_CreateInvoice_Detail]";
            context.AddParameter("@transaction_id", strTransaction);
            context.AddParameter("@invoice_no", strInvoice);
            context.AddParameter("@customer_id", strCustomerID);
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper<InvoiceDbo>(context, new InvoiceDbo()).FirstOrDefault();
        }

        public static InvoiceDbo create_invoice_header(string strInvoice, string strCustID, string strCustName )
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "[sp_Invoice_CreateInvoice_Header]";
            context.AddParameter("@invoice_no", strInvoice);
            context.AddParameter("@customer_id", strCustID);
            context.AddParameter("@customer_name", strCustName);
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper<InvoiceDbo>(context, new InvoiceDbo()).FirstOrDefault();
        }

        public static List<InvoiceDbo> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "sp_invoice_getList";
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.StoredProcedure;
            return DBUtil.ExecuteMapper(context, new InvoiceDbo());
        }

    }
}
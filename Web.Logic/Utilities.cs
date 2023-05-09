using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Web.Logic
{

    public class Utilities
    {
        public static int GetTotalPage(int totalRecords, int pageSize)
        {
            double pageCount = (double)((decimal)totalRecords / Convert.ToDecimal(pageSize));
            return (int)Math.Ceiling(pageCount);

        }
        public static string Username
        {
            get
            {
                return string.Format("{0}", HttpContext.Current == null ? "" : HttpContext.Current.Session["Username"]);
                //string username = "";
                //if (HttpContext.Current.User.Identity.IsAuthenticated)
                //{
                //    try
                //    {
                //        username = HttpContext.Current.User.Identity.Name;
                //    }
                //    catch (Exception)
                //    {
                //        //Log.Error(ex);
                //    }
                //}
                //return username;
            }
        }

        /// <summary>
        /// input format 10,000.32
        /// output format 10000,32
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static string ToString(decimal d)
        {
            return d.ToString(FORMAT_Money);
            //return sTemp.Replace(",", "");
        }

        public static string ToString(decimal d, string format)
        {
            return d.ToString(format);
            //return sTemp.Replace(",", "");
        }

        public static decimal ToDecimal(string p)
        {
            //string sTemp = p.Replace(",", ".");
            decimal dTemp = 0;
            decimal.TryParse(p, out dTemp);
            return dTemp;
        }

        public static string ToString(DateTime date)
        {

            return date == null ? "" : date.ToString(FORMAT_Date);
        }

        public const string FORMAT_Date = "dd MMM yyyy";
        public const string FORMAT_DateTime = "dd MMM yyyy HH:mm:ss";
        public const string FORMAT_DateTime_Flat = "yyyyMMddHHmmss";
        public const string FORMAT_Date_Flat = "ddMMyyyy";
        public const string FORMAT_Money = "N0";
        public static string FullDateFormat(DateTime? dt)
        {
            return string.Format("{0:dd-MMM-yyyy HH:mm:ss}", dt);
        }
        public static string FormatToMoney(decimal? money)
        {
            //id-ID

            return !money.HasValue ? 0.ToString() : string.Format("{0:N0}", money);
        }
        public static string CorrectFormat(string textValue)
        {

            decimal decTemp = 0;
            decimal.TryParse(textValue, out decTemp);

            return ToString(decTemp);
        }

        public static string CorrectFormat(string textValue, string format)
        {

            decimal decTemp = 0;
            decimal.TryParse(textValue, out decTemp);

            return ToString(decTemp, format);
        }


        public static string RawNumberFormat(string textValue)
        {
            //textValue = Regex.Replace(textValue, "^[0-9]", string.Empty);

            textValue = textValue.Replace(",", string.Empty);
            return textValue;
        }
        public static string Crop(string text, int length)
        {
            if (text == null) text = string.Empty;
            if (text.Length > length)
            {
                text = text.Substring(0, length);
            }
            return text;
        }

        public static string GetComputerName()
        {
            string hostName = "HOST";
            try
            {
                var hostEntry = Dns.GetHostEntry(Dns.GetHostName());
                hostName = hostEntry.HostName;
            }
            catch (Exception)
            {
            }

            return hostName;

        }

        public static string CurrentIPAddress
        {
            get
            {
                string UserHostAddress = "";
                try
                {
                    UserHostAddress = HttpContext.Current.Request.UserHostAddress;
                }
                catch (Exception)
                {

                }

                return UserHostAddress;

            }
        }
        public static string GetIpAddress()
        {
            string IpAddress = string.Empty;
            try
            {
                var hostEntry = Dns.GetHostEntry(Dns.GetHostName());
                foreach (var item in hostEntry.AddressList)
                {
                    if (item.AddressFamily.ToString() == "InterNetwork")
                    {
                        IpAddress = item.ToString();
                        break;
                    }
                }
            }
            catch (Exception)
            {
            }

            return Utilities.Crop(IpAddress, 15);
        }



        public static byte[] ReadFile(string filePath)
        {
            byte[] buffer;
            FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            try
            {
                int length = (int)fileStream.Length;  // get file length
                buffer = new byte[length];            // create buffer
                int count;                            // actual number of bytes read
                int sum = 0;                          // total number of bytes read

                // read until Read method returns 0 (end of the stream has been reached)
                while ((count = fileStream.Read(buffer, sum, length - sum)) > 0)
                    sum += count;  // sum is a buffer offset for next reading
            }
            finally
            {
                fileStream.Close();
            }
            return buffer;
        }

        public static string User_Level
        {
            get
            {
                return string.Format("{0}", HttpContext.Current == null ? "" : HttpContext.Current.Session["user_level"]);
            }
        }
    }
}

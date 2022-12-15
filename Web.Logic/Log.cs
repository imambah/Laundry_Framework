using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Dta;
using Web.Dto;
using Web.Logic.Enum;

namespace Web.Logic
{

    public class Log
    {
          public static void Error(Exception ex)
        {
            tbl_logItem.Insert(
                new tbl_log()
                {
                    created = DateTime.Now,
                    current_login = Utilities.Username,
                    log_type = LogType.ERROR.ToString(),
                    text_message = ex.ToString(),
                    ip_address = Utilities.GetIpAddress()

                });
        }

        public static void Info(string message)
        {
            tbl_logItem.Insert(
                  new tbl_log()
                  {
                      created = DateTime.Now,
                      current_login = Utilities.Username,
                      log_type = LogType.INFROMATION.ToString(),
                      text_message = message,
                      ip_address = Utilities.GetIpAddress()

                  });
        }

        public static void Warning(string message)
        {
            tbl_logItem.Insert(new tbl_log()
            {
                created = DateTime.Now,
                current_login = Utilities.Username,
                log_type = LogType.WARNING.ToString(),
                text_message = message,
                ip_address = Utilities.GetIpAddress()

            });
        }

        public static void Delete(string message)
        {
            tbl_logItem.Insert(new tbl_log()
            {
                created = DateTime.Now,
                current_login = Utilities.Username,
                log_type = LogType.ERROR.ToString(),
                text_message = message,
                ip_address = Utilities.GetIpAddress()

            });
        }
        
        

    }
}

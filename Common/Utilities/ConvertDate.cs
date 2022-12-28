using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utilities
{
    public static class ConvertDate
    {
        public static string Toshamsi(DateTime value)
        {
            PersianCalendar pc = new PersianCalendar();
            var date= pc.GetYear(value) + "/" + pc.GetMonth(value)
                .ToString("00") + "/" + pc.GetDayOfMonth(value).ToString("00");
            return date;
        }
        public static DateTime ToMiladi(string value)
        {
            

            DateTime date = DateTime.Parse(value, new CultureInfo("fa-IR"));

            return date;
        }




    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSKApp.Helpers
{
    public class AppUtilities
    {
        public static DateTime GetCurrentDateTimeAsDateTime(string format = "M-d-yyyy HH:mm:ss")
        {
            return Convert.ToDateTime(DateTime.Now.ToString(format, CultureInfo.InvariantCulture));
        }

        public static string GetCurrentDateTimeAsString(string format = "M-d-yyyy HH:mm:ss")
        {
            return DateTime.Now.ToString(format, CultureInfo.InvariantCulture);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSKApp.Helpers
{
    public class AppConstants
    {
#if DEBUG

        public const string APIUrl = "" + "/{0}";
        public const string WebUrl = "https://localhost:44308/";
#else
        public const string APIUrl = "" + "/{0}";
       // public const string WebUrl = "http://test.smartcare.sg/";
        //public const string WebUrl = "https://philipsklkiosk.oneservicecare.com/";
        public const string WebUrl = "http://localhost/";


#endif


    }
}

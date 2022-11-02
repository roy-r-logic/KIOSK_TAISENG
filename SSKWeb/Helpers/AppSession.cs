using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSKWeb.Helpers
{
    public sealed class AppSession
    {
        private static AppSession _current = null;

        private AppSession()
        {

        }

        public static AppSession GetInstance()
        {
            if (_current == null)
            {
                _current = new AppSession();
            }

            return _current;
        }

        public static bool HasData()
        {
            return _current != null;
        }

        public static void Dispose()
        {
            _current = null;
        }

        public bool IsQRCodeScanned { get; set; }

        private string _CustomerContact;
        public string CustomerContact
        {
            get { return _CustomerContact; }
            set
            {

                if (!string.IsNullOrEmpty(value))
                {
                    if (value.ToCharArray().FirstOrDefault() == '6')
                    {
                        value = value.Remove(0, 1);
                    }
                }
                _CustomerContact = value;

            }
        }

        public string currentRoute { get; set; }
        public bool isDirectToHome { get; set; } = false;

        #region lenovo
        //create job
        public string Serial { get; set; }
        public bool? InWarranty { get; set; } = null;
        public string customerName { get; set; }
        public string customerEmail { get; set; }
        public string customerPhoneNumber { get; set; }
        public string jobDeviceSerial { get; set; }
        public string jobProblemDescription { get; set; }
        public bool isReturnDropOff { get; set; }
        public string jobtag { get; set; }
        public List<string> problemDescriptions { get; set; }
        //get job
        public string jobTag { get; set; }
        public string warrantyType { get; set; }
        public bool isExists { get; set; }
        public string status { get; set; }
        public int? statusId { get; set; }
        #endregion
    }
}

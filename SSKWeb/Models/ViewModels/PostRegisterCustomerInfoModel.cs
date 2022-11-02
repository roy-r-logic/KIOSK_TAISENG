using System.Collections.Generic;

namespace SSKWeb.Models.ViewModels
{
    public class PostRegisterCustomerInfoModel
    {
        public string Serial { get; set; }
        public bool? InWarranty { get; set; } = null;
        public string customerName { get; set; }
        public string customerEmail { get; set; }
        public string customerPhoneNumber { get; set; }
        public string jobDeviceSerial { get; set; }
        public string jobProblemDescription { get; set; }
        public bool isReturnDropOff { get; set; }
        public List<string> problemDescriptions { get; set; }
    }
}

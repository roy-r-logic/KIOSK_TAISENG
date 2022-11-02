using System.Collections.Generic;

namespace SSKWeb.Models.ViewModels
{
    public class PostRegisterCustomerInfoResultModel
    {
        public string CaseNumber { get; set; }
        public string jobtag { get; set; }

        public Dictionary<string, List<string>> Errors { get; set; }
    }
}

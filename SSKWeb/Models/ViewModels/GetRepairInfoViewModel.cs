using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSKWeb.Models.ViewModels
{
    public class GetRepairInfoViewModel
    {
        public int ModelID { get; set; }
        public string ModelName { get; set; }
        public bool ModelIsQuickFixedAllowed { get; set; }
        public bool IsModelUnderCustomer { get; set; }

        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerContact { get; set; }
        public bool IsCustomerExists { get; set; }

        public Dictionary<string, List<string>> Errors { get; set; }

    }
}

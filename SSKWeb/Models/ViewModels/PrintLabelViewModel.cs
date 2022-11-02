using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSKWeb.Models.ViewModels
{
    public class PrintLabelViewModel
    {
        public string CustomerName { get; set; }
        public string CustomerContact { get; set; }
        public string SerialNumber { get; set; }
        public string CaseNumber { get; set; }
        public string WarrantyType { get; set; }

    }
}

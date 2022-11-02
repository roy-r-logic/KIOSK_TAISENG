using System.Collections.Generic;

namespace SSKWeb.Models.ViewModels
{
    public class ResultWarrantyViewModel
    {
        public string Serial { get; set; }
        public string Product { get; set; } = null;
        public bool? InWarranty { get; set; } = null;
        public string Purchased { get; set; } = null;
        public string Shipped { get; set; } = null;
        public string Country { get; set; } = null;
        public string UpgradeUrl { get; set; } = null;
        public List<Warranty> Warranty { get; set; } = null;

        public int? ErrorCode { get; set; }
        public string ErrorMessage { get; set; } = null;
        public bool IsServerError { get; set; } = false;

        public Dictionary<string, List<string>> Errors { get; set; }

    }
    public class Warranty
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Start { get; set; }
        public string End { get; set; }

    }

}

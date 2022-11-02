using System.Collections.Generic;

namespace SSKWeb.Models.ViewModels
{
    public class ResultJobViewModel
    {
        public string jobTag { get; set; }
        public string warrantyType { get; set; } = null;
        public bool isExists { get; set; }
        public string status { get; set; } = null;
        public int? statusId { get; set; } = null;
        public string serial { get; set; } = null;

        public Dictionary<string, List<string>> Errors { get; set; }
    }
}

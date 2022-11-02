using System.Collections.Generic;

namespace SSKWeb.Models.ViewModels
{
    public class ProblemDescriptionModel
    {
        public int productDescID { get; set; }
        public string productDesc { get; set; }

        public Dictionary<string, List<string>> Errors { get; set; }
        public List<ProblemDescriptionModel> ProblemDescriptions { get; set; }


    }

}

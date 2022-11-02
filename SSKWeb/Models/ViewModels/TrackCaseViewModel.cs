using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSKWeb.Models.ViewModels
{
    public class TrackCaseViewModel
    {
        public List<CaseViewModel> PreviousList { get; set; }

        public string Model { get; set; }
        public string Contact { get; set; }
    }
}

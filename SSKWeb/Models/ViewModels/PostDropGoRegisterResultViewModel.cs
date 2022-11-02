using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSKWeb.Models.ViewModels
{

    public class PostDropGoRegisterResultViewModel
    {
        public string CaseNumber { get; set; }

        public Dictionary<string, List<string>> Errors { get; set; }
    }
}

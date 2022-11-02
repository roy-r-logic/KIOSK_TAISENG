using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSKWeb.Models.ViewModels
{
    public class _BaseViewModel
    {
        public int Id { get; set; }
        public Dictionary<string, List<string>> Errors { get; set; }
    }
}

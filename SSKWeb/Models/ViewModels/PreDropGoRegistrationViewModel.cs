using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSKWeb.Models.ViewModels
{
    public class PreDropGoRegistrationViewModel
    {
        public List<DefectTypesViewModel> DefectTypes { get; set; }
        public List<AccessoriesTypesViewModel> AccessoriesTypes { get; set; }
        public List<WarrantyTypesViewModel> WarrantyTypes { get; set; }
        public List<SetConditionTypesViewModel> SetConditionTypes { get; set; }
        public List<OutWarrantyTypes> OutWarrantyTypes { get; set; }
        

        public string Contact { get; set; }
        public string Name { get; set; }
        public bool IsCustomerExists { get; set; }
    }
}

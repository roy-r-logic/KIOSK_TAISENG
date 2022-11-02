using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSKApp.Helpers
{
    public class AppValidator
    {
        public static void ValidateObject(object model)
        {
            ValidationContext context = new ValidationContext(model, null, null);
            List<ValidationResult> results = new List<ValidationResult>();

            bool valid = Validator.TryValidateObject(model, context, results, true);

            if (!valid)
            {
                Dictionary<string, string> dic = new Dictionary<string, string>();

                foreach (ValidationResult vr in results)
                {
                    dic.Add(vr.MemberNames.First(), vr.ErrorMessage);
                }

                throw new AppException(dic);
            }
        }

       
    }
}

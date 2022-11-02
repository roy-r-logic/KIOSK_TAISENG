using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;

namespace SSKWeb.Helpers
{
    public class AppValidator
    {
        public static Dictionary<string, string> ValidateObject(object model)
        {
            ValidationContext context = new ValidationContext(model, null, null);
            List<ValidationResult> results = new List<ValidationResult>();

            bool valid = Validator.TryValidateObject(model, context, results, true);

            if (!valid)
            {
                Dictionary<string, string> dic = new Dictionary<string, string>();

                foreach (ValidationResult vr in results)
                {
                    if (!dic.ContainsKey(vr.MemberNames.First()))
                    {
                        dic.Add(vr.MemberNames.First(), vr.ErrorMessage);
                    }
                }

                return dic;
            }

            return new Dictionary<string, string>();
        }

        public static Dictionary<string, string> ValidateeProperty(object model, string name)
        {

            PropertyInfo fieldPropertyInfo = model.GetType().GetProperties()
                             .FirstOrDefault(f => f.Name.ToLower() == name.ToLower());

            var propertyValue = fieldPropertyInfo.GetValue(model, null);



            ValidationContext context = new ValidationContext(model, null, null)
            {
                MemberName = name
            };
            List<ValidationResult> results = new List<ValidationResult>();


            bool valid = Validator.TryValidateProperty(propertyValue, context, results);

            if (!valid)
            {
                Dictionary<string, string> dic = new Dictionary<string, string>();

                foreach (ValidationResult vr in results)
                {
                    if (!dic.ContainsKey(vr.MemberNames.First()))
                    {
                        dic.Add(vr.MemberNames.First(), vr.ErrorMessage);
                    }
                }

                return dic;
            }

            return new Dictionary<string, string>();

        }
    }
}
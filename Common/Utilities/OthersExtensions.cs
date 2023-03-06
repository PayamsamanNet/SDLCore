using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Common.Utilities
{
    public static class OthersExtensions
    {
        public static List<string> ValidateClass(object model)
        {
            var ProPerties = model.GetType().GetProperties().ToList();
            List<string> result = new List<string>();
            foreach (var item in ProPerties)
            {
                var Validations = item.GetCustomAttributes().ToList();
                var _Display = item.GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute;
                var RequiredAttribute = item.GetCustomAttribute(typeof(RequiredAttribute)) as RequiredAttribute;
                var Error = "";
                if (RequiredAttribute != null)
                {
                    Error += " وارد کردن نام " + _Display.Name + " الزامی است ";
                    result.Add(Error);
                }
            }
            return result;
        }
      
    }
}

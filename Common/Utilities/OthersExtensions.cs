using Common.Utilities.ClassUtilities;
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
        public static string GenerateCode()
        {
            StringBuilder builder = new StringBuilder();
            Enumerable
               .Range(65, 26)
                .Select(e => ((char)e).ToString())
                .Concat(Enumerable.Range(97, 26).Select(e => ((char)e).ToString()))
                .Concat(Enumerable.Range(0, 10).Select(e => e.ToString()))
                .OrderBy(e => Guid.NewGuid())
                .Take(8)
                .ToList().ForEach(e => builder.Append(e));
            string code = builder.ToString();
            return code;
        }
        public static List<ControllerModel> GetAccessProject<BaseType>(params Assembly[] assemblies)
        {
            IEnumerable<Type> types = assemblies.SelectMany(s => s.GetExportedTypes())
                .Where(c => c.IsClass && !c.IsAbstract && c.IsPublic && typeof(BaseType).IsAssignableFrom(c)).ToList();
            List<ControllerModel> Result = new List<ControllerModel>();
            int number = 0;
            int numberAction = 1;
            foreach (var item in types)
            {
                number++;
                ControllerModel model = new ControllerModel();
                model.Title = item.Name;
                model.IsMenu = true;
                model.Number = number;
                var Items = item.GetTypeInfo().DeclaredMethods.ToList();
                List<ListActions> Actions = new List<ListActions>();
                foreach (var action in Items)
                {
                    var name = action.GetCustomAttribute(typeof(DisplayAttribute), false);

                    Actions.Add(new ListActions
                    {
                        Title = action.Name,
                        Number = numberAction++,
                        NumberMenu = model.Number
                    });
                }
                model.Actions = Actions;
                Result.Add(model);

            }
            return Result;
        }
    }
}

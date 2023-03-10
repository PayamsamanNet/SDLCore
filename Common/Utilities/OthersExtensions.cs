using Common.Utilities.ClassUtilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Collections.Specialized.BitVector32;

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
                var NameCon = item.GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute;
                if (NameCon != null)
                {

                    number++;
                    ControllerModel model = new ControllerModel();

                    if (NameCon != null)
                    {
                        model.Title = NameCon.Name;
                    }
                    else
                    {
                        model.Title = item.Name;
                    }
                    model.IsMenu = true;
                    model.Number = number;
                    model.Url = $"api/{item.Name}";
                    var Items = item.GetTypeInfo().DeclaredMethods.ToList();
                    List<ListActions> Actions = new List<ListActions>();
                    foreach (var action in Items)
                    {
                        string Name = "";
                        var NameAtr = action.GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute;
                        if (NameAtr != null)
                        {
                            Name = NameAtr.Name;
                            Actions.Add(new ListActions
                            {
                                Title = Name,
                                Number = numberAction++,
                                NumberMenu = model.Number,
                                Url = $"api/{item.Name}/{action.Name}"
                            });
                        }
                        else
                        {
                           
                        }    
                    }
                    model.Actions = Actions;
                    Result.Add(model);
                }
               
            }
            return Result;
        }
    }
}

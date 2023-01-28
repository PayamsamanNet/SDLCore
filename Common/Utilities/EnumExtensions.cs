using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utilities
{
    public static class EnumExtensions
    {
        public static string GetEnumDescription(Enum value)
        {

            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
        public static List<EnumModel> GetEnumlist<TName>() where TName : Enum
        {
            var List = Enum.GetValues(typeof(TName)).Cast<TName>().ToList();
            List<EnumModel> listEnums = new List<EnumModel>();
            foreach (var item in List)
            {
                EnumModel Model = new EnumModel();
                Model.Id = Convert.ToInt32(item);
                Model.Name = item.ToString();
                Model.Description = GetEnumDescription(item);
                listEnums.Add(Model);
            }
            return listEnums;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CFA.Infrastructure.Extensions
{
    public static class DomainExtensions
    {
        public static bool HasValue<T>(this T model)
        {
            if (model == null)
                return false;

            PropertyInfo idPropertyInfo = model.GetType().GetProperty("Id");
            if (idPropertyInfo == null)
            {
                throw new NullReferenceException("Property Name 'Id' specified, does not exist in the supplied Model '" + model.GetType().Name + "'! Please contact your system administrator.");
            }
            
            string id = idPropertyInfo.GetValue(model, null).ToString();
            return model != null && !string.IsNullOrWhiteSpace(id) ? true : false;
        }

        public static bool IsNull<T>(this T model)
        {
            if (model == null)
                return true;

            PropertyInfo idPropertyInfo = model.GetType().GetProperty("Id");
            if (idPropertyInfo == null)
                return true;

            int id = Convert.ToInt32(idPropertyInfo.GetValue(model, null));
            return model != null && id == 0 ? true : false;
        }

       




    }
}

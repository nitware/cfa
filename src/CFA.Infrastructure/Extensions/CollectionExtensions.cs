using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFA.Infrastructure.Extensions
{
    public static class CollectionExtensions
    {
        public static bool HasItem<T>(this ICollection<T> items)
        {
            return items != null && items.Count > 0 ? true : false;
        }


        //public static bool IsEmpty<T>(this ICollection<T> items)
        //{
        //    return (items == null || items.Count <= 0);
        //}

        public static bool IsEmpty<T>(this IList<T> items)
        {
            return (items == null || items.Count <= 0);
        }
        public static bool IsEmpty<T>(this IQueryable<T> items)
        {
            return (items == null || items.Count() <= 0);
        }

        public static void AddRange<T>(this ICollection<T> initial, IEnumerable<T> others)
        {
            if (others == null)
                return;

            var list = initial as IList<T>;
            if (list.HasItem())
            {
                list.AddRange(others);
                return;
            }

            others.Each(x => initial.Add(x));
        }

        

    }


}

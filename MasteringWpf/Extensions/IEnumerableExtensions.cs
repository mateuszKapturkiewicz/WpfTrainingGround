using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;

namespace MasteringWpf.Extensions
{
    public static class IEnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach (T item in collection) action(item);
        }

        public static string ToCommaSeparatedString<T>(this IEnumerable<T> collection)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int index = 0;
            foreach (T item in collection)
            {
                if (index > 0)
                {
                    if (index < collection.Count() - 1) stringBuilder.Append(", ");
                    else if (index == collection.Count() - 1) stringBuilder.Append(" and ");
                }
                stringBuilder.Append(item.ToString());
                index++;
            }
            return stringBuilder.ToString();
        }
    }
}

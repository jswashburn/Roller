using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Roller.Extensions
{
    public static class EnumerableExtensions
    {
        public static string Stringify<T>(this IEnumerable<T> original)
        {
            var items = new StringBuilder("[");

            foreach (T item in original)
                items.Append($"{item}, ");

            items.Append($"{items}]");

            return items.ToString();
        }

        public static void LogEach<T>(this IEnumerable<T> original)
        {
            foreach (T item in original)
                Debug.Log(item);
        }
    }
}
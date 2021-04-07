using System.Collections.Generic;
using System.Text;

namespace Roller.Extensions
{
    public static class ListExtensions
    {
        // Removes and returns item at index
        public static T Pop<T>(this IList<T> original, int index)
        {
            T thing = original[index];
            original.RemoveAt(index);
            return thing;
        }

        public static string Stringify<T>(this IList<T> original)
        {
            StringBuilder items = new StringBuilder("[");

            foreach (T item in original)
                items.Append($"{item}, ");

            items.Append($"{items}]");
            
            return items.ToString();
        }
    }
}

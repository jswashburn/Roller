using System.Collections.Generic;

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
            string s = "[ ";
        
            foreach (T item in original)
            {
                s += $"{item}, ";
            }

            return $"{s} ]";        
        }
    }
}

using System.Collections.Generic;
using System.Text;
using UnityEngine;

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

        public static int GetRandomIdx<T>(this IList<T> original)
        {
            return Random.Range(0, original.Count - 1);
        }

        public static T PopRandom<T>(this IList<T> original)
        {
            return original.Pop(original.GetRandomIdx());
        }

        public static T GetRandom<T>(this IList<T> original)
        {
            return original[original.GetRandomIdx()];
        }

        public static string Stringify<T>(this IList<T> original)
        {
            var items = new StringBuilder("[");

            foreach (T item in original)
                items.Append($"{item}, ");

            items.Append($"{items}]");

            return items.ToString();
        }
    }
}
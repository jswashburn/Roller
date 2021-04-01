using System.Collections.Generic;

public static class ListExtensions
{
    // Removes and returns item at index
    public static T Pop<T>(this List<T> original, int index)
    {
        T thing = original[index];
        original.RemoveAt(index);
        return thing;
    }
}

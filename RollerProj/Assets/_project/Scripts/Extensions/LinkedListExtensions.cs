using System.Collections.Generic;

public static class LinkedListExtensions
{
    public static string Stringify<T>(this LinkedList<T> original)
    {
        string s = "[";
        LinkedListNode<T> currentNode = original.First;
        while (true)
        {
            s += $"{currentNode.Value} -> ";
            if (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
            }
            else
            {
                return $"{s}]";
            }
        }       
    }

    public static void Cycle<T>(this LinkedList<T> original, T newItem)
    {
        original.AddLast(newItem);
        original.RemoveFirst();
    }
}

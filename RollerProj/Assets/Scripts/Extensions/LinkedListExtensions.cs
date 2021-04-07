using System.Collections.Generic;
using System.Text;

namespace Roller.Extensions
{
    public static class LinkedListExtensions
    {
        public static string Stringify<T>(this LinkedList<T> original)
        {
            StringBuilder nodes = new StringBuilder("[");
            LinkedListNode<T> currentNode = original.First;
            while (true)
            {
                nodes.Append($"{currentNode.Value} -> ");
                if (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                }
                else
                {
                    nodes.Append($"{nodes}]");
                    return nodes.ToString();
                }
            }       
        }

        public static void Cycle<T>(this LinkedList<T> original, T newItem)
        {
            original.AddLast(newItem);
            original.RemoveFirst();
        }
    }
}

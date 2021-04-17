using System;
using System.Collections.Generic;
using System.Text;
using Roller.Environment.Track;
using Roller.Extensions.Unity;
using UnityEngine;

namespace Roller.Extensions
{
    public static class LinkedListExtensions
    {
        public static string Stringify<T>(this LinkedList<T> original)
        {
            var nodes = new StringBuilder("[");
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

        public static void ForEachValue<T>(this LinkedList<T> original, Action<T> action)
        {
            LinkedListNode<T> currentNode = original.First;

            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.Next;
            }
        }

        public static void PositionEach<T>(this LinkedList<T> original,
            SpacingOptions opts) where T : Component
        {
            // Use first items initial position to start
            Vector3 nextPosition = original.First.Value.transform.position;

            original.ForEachValue(component =>
            {
                component.transform.parent.position = nextPosition;

                nextPosition = nextPosition.WithOffset(opts.NextGap, opts.NextHeight);
            });
        }

        public static void Cycle<T>(this LinkedList<T> original, T newItem)
        {
            original.AddLast(newItem);
            original.RemoveFirst();
        }
    }
}
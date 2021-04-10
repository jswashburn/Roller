using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Roller.Environment.Items.Pooling
{
    public abstract class Pool<T> : MonoBehaviour where T : IPoolable
    {
        [Range(0, 100)] public float spawnPercentage;
        protected Queue<T> Active;

        protected Queue<T> Inactive;

        public T Get()
        {
            var newItem = default(T);
            var replacedItem = default(T);

            if (Inactive.Any())
                newItem = Inactive.Dequeue();

            if (Active.Any())
                replacedItem = Active.Dequeue();

            newItem?.Activate();
            replacedItem?.Deactivate();

            Active.Enqueue(newItem);
            if (replacedItem != null)
                Inactive.Enqueue(replacedItem);

            return newItem;
        }
    }
}
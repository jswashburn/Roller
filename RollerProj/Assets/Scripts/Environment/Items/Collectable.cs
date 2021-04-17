using System;
using UnityEngine;

namespace Roller.Environment.Items
{
    [RequireComponent(typeof(Collider))]
    public abstract class Collectable : Item, ICollectable
    {
        public abstract string PickupSound { get; }
        public abstract int Value { get; }

        public void OnTriggerEnter(Collider other)
        {
            bool isCollector = other.gameObject.GetComponentInChildren<ICollector>() != null;

            if (isCollector)
                Collected?.Invoke(this);

            Deactivate();
        }

        public static event Action<Collectable> Collected;
    }
}
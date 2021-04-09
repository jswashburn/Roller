using System;
using UnityEngine;

namespace Roller.Environment.Items
{
    public enum Item
    {
        Coin = 5,
        Diamond = 100
    }

    public class Collectable : MonoBehaviour
    {
        [SerializeField] Item itemType;
        
        public static event Action<Item> Collected;

        void OnTriggerEnter(Collider other)
        {
            bool isCollector = other.gameObject.GetComponentInChildren<ICollector>() != null;

            if (isCollector)
                Collected?.Invoke(itemType);

            Destroy(transform.parent.gameObject);
        }
    }
}
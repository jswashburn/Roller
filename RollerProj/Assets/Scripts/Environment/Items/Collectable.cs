using System;
using UnityEngine;
using Roller.Core;

namespace Roller.Environment.Items
{
    public enum Item
    {
        Coin = 5,
        Diamond = 100
    }
    
    public class Collectable : MonoBehaviour
    {
        public Item itemType;

        public static event Action<Item> Collected;
        
        void OnTriggerEnter(Collider other)
        {
            bool isPlayer = other.gameObject.GetComponentInChildren<Player>() != null;
            
            if (isPlayer)
                Collected?.Invoke(itemType);
            
            Destroy(transform.root.gameObject);
        }
    }
}

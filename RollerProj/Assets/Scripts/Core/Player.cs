using System;
using Roller.Environment.Items;
using UnityEngine;

namespace Roller.Core
{
    public class Player : MonoBehaviour, ICollector
    {
        int _points = 0;
        
        void OnEnable()
        {
            Collectable.Collected += Collect;
        }

        void OnDisable()
        {
            Collectable.Collected -= Collect;
        }

        public void Collect(Item item)
        {
            Debug.Log($"Player Collect ({item}), val: {(int)item})");
            _points += (int) item;
            Debug.Log($"Player Collect Points: {_points}");
        }
    }
}

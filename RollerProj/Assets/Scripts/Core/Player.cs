using System;
using Roller.Environment.Items;
using UnityEngine;

namespace Roller.Core
{
    public class Player : MonoBehaviour
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

        void Collect(Item item)
        {
            _points += (int) item;
        }
    }
}

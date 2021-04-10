using Roller.Environment.Items;
using UnityEngine;

namespace Roller.Core
{
    public class Player : MonoBehaviour, ICollector
    {
        int _points;

        void OnEnable()
        {
            Collectable.Collected += Collect;
        }

        void OnDisable()
        {
            Collectable.Collected -= Collect;
        }

        public void Collect(ICollectable collectable)
        {
            _points += collectable.Value;
        }
    }
}
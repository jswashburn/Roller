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
            _points += (int) item;
            Debug.Log($"Player Collected {item}\nPoints: {_points}");
        }
    }
}

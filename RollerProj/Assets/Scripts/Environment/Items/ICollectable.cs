using UnityEngine;

namespace Roller.Environment.Items
{
    public interface ICollectable
    {
        int Value { get; }

        void OnTriggerEnter(Collider other);
    }
}
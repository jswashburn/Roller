using UnityEngine;

namespace Roller.Environment.Effectors
{
    public class SpeedBoost : MonoBehaviour
    {
        [SerializeField] Vector3 forceVector;
    
        void OnTriggerStay(Collider other)
        {
            other.attachedRigidbody.AddForce(forceVector);
        }
    }
}

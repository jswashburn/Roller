using Roller.Core.Audio;
using UnityEngine;

namespace Roller.Core
{
    public class CollisionSoundPlayer : MonoBehaviour
    {
        [SerializeField] string soundName;
        [SerializeField] AudioManager audioManager;
        [SerializeField] float maxImpulseMagnitude;

        void OnCollisionEnter(Collision other)
        {
            if (other.impulse.magnitude > maxImpulseMagnitude)
                audioManager.Play(soundName);
        }
    }
}

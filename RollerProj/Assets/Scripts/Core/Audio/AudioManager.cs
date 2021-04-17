using System;
using System.Linq;
using Roller.Environment.Items;
using Roller.Movement;
using UnityEngine;

namespace Roller.Core.Audio
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] Sound[] sounds;

        void OnEnable()
        {
            Collectable.Collected += collectable => Play(collectable.PickupSound);
        }

        void Awake()
        {
            foreach (Sound sound in sounds)
            {
                sound.source = gameObject.AddComponent<AudioSource>();
                sound.source.clip = sound.clip;
                sound.source.volume = sound.volume;
                sound.source.pitch = sound.pitch;
            }
        }

        public void Play(string soundName)
        {
            Sound foundSound = sounds.FirstOrDefault(sound => sound.name == soundName);
            
            foundSound?.source.Play();
        }
    }
}

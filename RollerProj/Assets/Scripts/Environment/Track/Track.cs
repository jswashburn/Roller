using UnityEngine;
using UnityEngine.Serialization;

namespace Roller.Environment.Track
{
    public class Track : MonoBehaviour
    {
        public Transform cycleTrigger;

        [SerializeField] Animator animator;
        [SerializeField] MeshRenderer mesh;
        [SerializeField] Collider collider;

        public bool Despawned => gameObject.activeSelf;

        public void DeActivate()
        {
            gameObject.SetActive(false);
        }

        public void Activate()
        {
            gameObject.SetActive(true);
        }

        public void AppearAt(Vector3 pos)
        {
            transform.position = pos;
            // _animator.SetTrigger("Appear");
        }

        public override string ToString()
        {
            return transform.name;
        }
    }
}

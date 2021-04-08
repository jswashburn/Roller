using UnityEngine;

namespace Roller.Environment.Track
{
    public class TrackPiece : MonoBehaviour
    {
        public Transform cycleTrigger;
        
        public bool IsActive => transform.parent.gameObject.activeSelf;

        public void DeActivate()
        {
            transform.parent.gameObject.SetActive(false);
        }

        public void Activate()
        {
            transform.parent.gameObject.SetActive(true);
        }

        public void AppearAt(Vector3 position)
        {
            transform.parent.position = position;
        }

        public override string ToString()
        {
            return transform.name;
        }
    }
}

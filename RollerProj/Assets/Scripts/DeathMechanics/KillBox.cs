using Roller.Extensions.Unity;
using Roller.Movement;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Roller.DeathMechanics
{
    public class KillBox : MonoBehaviour
    {
        [SerializeField] Transform following;
        [SerializeField] PlayerMovementController character;
        [SerializeField] float killBoxDepth;
        [SerializeField] UnityEvent onEntered;

        void OnEnable()
        {
            character.PlayerGrounded += FollowWithYOffset;
            character.PlayerNotGrounded += FollowWithoutYOffset;
        }

        void OnDisable()
        {
            character.PlayerGrounded -= FollowWithYOffset;
            character.PlayerNotGrounded -= FollowWithoutYOffset;
        }

        void OnTriggerEnter(Collider other)
        {
            onEntered?.Invoke();
        }

        public void ReloadScene(int sceneBuildIndex)
        {
            SceneManager.LoadScene(sceneBuildIndex);
        }

        // Will run when grounded
        void FollowWithYOffset()
        {
            transform.position = following.position.WithOffset(
                yOffset: killBoxDepth
            );
        }

        // Will run when not grounded
        void FollowWithoutYOffset()
        {
            transform.position = following.position.With(
                newY: transform.position.y
            );
        }
    }
}
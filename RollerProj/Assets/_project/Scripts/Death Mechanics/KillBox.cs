using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class KillBox : MonoBehaviour
{
    [SerializeField] Transform following;
    [SerializeField] PlayerMovementController character;
    [SerializeField] float killBoxDepth;
    [SerializeField] UnityEvent onEntered;

    void OnEnable()
    {
        character.OnGrounded += FollowWithYOffset;
        character.OnNotGrounded += FollowWithoutYOffset;
    }

    void OnDisable()
    {
        character.OnGrounded -= FollowWithYOffset;
        character.OnNotGrounded -= FollowWithoutYOffset;
    }

    public void ReloadScene(int sceneBuildIndex)
    {
        SceneManager.LoadScene(sceneBuildIndex);
    }

    void OnTriggerEnter(Collider other)
    {
        onEntered?.Invoke();
    }

    // Will run when grounded
    void FollowWithYOffset() =>
        transform.position = following.position.WithOffset(
            yOffset: killBoxDepth
            );

    // Will run when not grounded
    void FollowWithoutYOffset() =>
        transform.position = following.position.With(
            newX: following.position.x,
            newY: transform.position.y,
            newZ: following.position.z
        );
}

using UnityEngine;

public class KillBoxPositioner : MonoBehaviour
{
    [SerializeField] Transform following;
    [SerializeField] PlayerMovementController character;
    [Tooltip("When object to follow is not on ground, amount by which to offset Y position." +
        " This is how far the character will go before colliding." +
        " The offset amount is added, so you usually will want a negative number.")]
    [SerializeField] float yOffset;

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

    // Will run when grounded
    void FollowWithYOffset() =>
        transform.position = following.position.With(newY: following.position.y + yOffset);

    // Will run when not grounded
    void FollowWithoutYOffset() =>
        transform.position = following.position.With(
            newX: following.position.x,
            newY: transform.position.y,
            newZ: following.position.z
        );
}

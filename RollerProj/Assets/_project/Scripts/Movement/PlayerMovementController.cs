using UnityEngine;
using System;

public class PlayerMovementController : MonoBehaviour, ICharacterController<PlayerMoveOption>
{
    [SerializeField] float jumpForce;
    [SerializeField] float moveSpeed;
    [SerializeField] float maxSpeed;
    [SerializeField] int extraJumps;
    [SerializeField] bool airControl;
    [SerializeField] Collider groundCheckCollider;
    [SerializeField] Rigidbody character;

    int _jumpsAvailable;

    public event Action OnNotGrounded;
    public event Action OnGrounded;

    bool CanDoubleJump() => _jumpsAvailable > 0;

    public void Move(PlayerMoveOption moveOptions)
    {
        // Move
        bool grounded = transform.position.IsGrounded(groundCheckCollider);
        if (grounded)
        {
            OnGrounded?.Invoke();
            _jumpsAvailable = extraJumps;

            character.MoveTowards(moveOptions.MoveDirection, moveSpeed, maxSpeed);
        }
        else
        {
            OnNotGrounded?.Invoke();

            if (airControl)
                character.MoveTowards(moveOptions.MoveDirection, moveSpeed, maxSpeed);
        }

        // Jump
        if (moveOptions.JumpRequested && (grounded || CanDoubleJump()))
        {
            character.Jump(jumpForce);
            _jumpsAvailable--;
        }
    }
}

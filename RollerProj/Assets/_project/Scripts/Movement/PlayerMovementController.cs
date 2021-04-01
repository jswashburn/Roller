using UnityEngine;
using System;

public class PlayerMovementController : MonoBehaviour, ICharacterController
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

    bool canDoubleJump => _jumpsAvailable > 0;

    public void Move(IMoveOption moveOptions)
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
            {
                character.MoveTowards(moveOptions.MoveDirection, moveSpeed, maxSpeed);
            }
        }

        // Jump
        if (moveOptions.JumpRequested && (grounded || canDoubleJump))
        {
            character.Jump(jumpForce);
            _jumpsAvailable--;
        }
    }
}

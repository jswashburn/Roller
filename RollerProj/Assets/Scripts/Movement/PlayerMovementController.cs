using System;
using Roller.Extensions;
using UnityEngine;

namespace Roller.Movement
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovementController : MonoBehaviour, ICharacterController<PlayerMoveOption>
    {
        [SerializeField] float jumpForce;
        [SerializeField] float moveSpeed;
        [SerializeField] float maxSpeed;
        [SerializeField] int extraJumps;
        [SerializeField] bool airControl;
        [SerializeField] Collider groundCheckCollider;

        Rigidbody _character;
        int _jumpsAvailable;

        public event Action OnNotGrounded;
        public event Action OnGrounded;

        bool canDoubleJump => _jumpsAvailable > 0;
        bool grounded => transform.position.IsGrounded(groundCheckCollider);

        void Awake()
        {
            _character = GetComponent<Rigidbody>();
        }

        public void Control(PlayerMoveOption moveOptions)
        {
            Move(moveOptions);
            Jump(moveOptions);
        }

        void Move(PlayerMoveOption moveOptions)
        {
            if (grounded)
            {
                OnGrounded?.Invoke();
                _jumpsAvailable = extraJumps;

                _character.MoveTowards(moveOptions.MoveDirection * moveSpeed, maxSpeed);
            }
            else
            {
                OnNotGrounded?.Invoke();

                if (airControl)
                {
                    _character.MoveTowards(moveOptions.MoveDirection * moveSpeed, maxSpeed);
                }
            }
        }

        void Jump(PlayerMoveOption moveOptions)
        {
            if (moveOptions.JumpRequested && (grounded || canDoubleJump))
            {
                _character.Jump(jumpForce);
                _jumpsAvailable--;
            }
        }
    }
}

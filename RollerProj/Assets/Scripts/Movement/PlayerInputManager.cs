using UnityEngine;
using UnityEngine.InputSystem;

namespace Roller.Movement
{
    [RequireComponent(typeof(PlayerMovementController))]
    public class PlayerInputManager : MonoBehaviour
    {
        PlayerMovementController _playerMovementController;
        Controls _controls;
        PlayerMoveOption _moveOptions;

        void OnEnable()
        {
            _controls.Gameplay.Enable();
        }

        void OnDisable()
        {
            _controls.Gameplay.Disable();
        }

        void Awake()
        {
            _playerMovementController = GetComponent<PlayerMovementController>();
            _moveOptions = new PlayerMoveOption();
            _controls = new Controls();

            RegisterControlActions();
        }

        void FixedUpdate()
        {
            _playerMovementController.Control(_moveOptions);
            _moveOptions.JumpRequested = false;
        }

        void RegisterControlActions()
        {
            _controls.Gameplay.Jump.performed += OnJump;
            _controls.Gameplay.Move.performed += OnMovePerformed;
            _controls.Gameplay.Move.canceled += OnMoveCancelled;
        }

        void OnJump(InputAction.CallbackContext ctx)
        {
            _moveOptions.JumpRequested = true;
        }

        void OnMovePerformed(InputAction.CallbackContext ctx)
        {
            Vector2 input = ctx.ReadValue<Vector2>();
            _moveOptions.MoveDirection = new Vector3(input.x, 0f, input.y);
        }

        void OnMoveCancelled(InputAction.CallbackContext ctx)
        {
            _moveOptions.MoveDirection = Vector3.zero;
        }
    }
}
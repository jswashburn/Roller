using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(ICharacterController))]
public class PlayerInputManager : MonoBehaviour
{
    ICharacterController _characterController;
    Controls _controls; // Provides access to control actions from unity's new input system
    PlayerMoveOption _moveOptions; // Movement instructions for character controller

    void OnEnable() => _controls.Gameplay.Enable();

    void OnDisable() => _controls.Gameplay.Disable();

    void FixedUpdate()
    {
        _characterController.Move(_moveOptions);
        _moveOptions.JumpRequested = false;
    }

    void Awake()
    {
        _characterController = GetComponent<ICharacterController>();
        _moveOptions = new PlayerMoveOption();

        _controls = new Controls();
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
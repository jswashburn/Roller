using UnityEngine;

[RequireComponent(typeof(ICharacterController<PlayerMoveOption>))]
public class PlayerInputManager : MonoBehaviour
{
    ICharacterController<PlayerMoveOption> _characterController;
    Controls _controls; // Provides access to control actions from unity's new input system
    PlayerMoveOption _moveOptions; // Movement instructions for character controller

    void OnEnable() => _controls.Gameplay.Enable();

    void OnDisable() => _controls.Gameplay.Disable();

    void Awake()
    {
        _characterController = GetComponent<ICharacterController<PlayerMoveOption>>();
        _moveOptions = new PlayerMoveOption();
        _controls = new Controls();

        // Jump
        _controls.Gameplay.Jump.performed += ctx => _moveOptions.JumpRequested = true;

        // Move
        _controls.Gameplay.Move.performed += ctx =>
        {
            Vector2 input = ctx.ReadValue<Vector2>();
            _moveOptions.MoveDirection = new Vector3(input.x, 0f, input.y);
        };
        _controls.Gameplay.Move.canceled += ctx => _moveOptions.MoveDirection = Vector3.zero;

        // Brake
        _controls.Gameplay.Brake.performed += ctx => _moveOptions.SlowDownRequested = true;
        _controls.Gameplay.Brake.canceled += ctx => _moveOptions.SlowDownRequested = false;
    }

    void FixedUpdate()
    {
        _characterController.Move(_moveOptions);
        _moveOptions.JumpRequested = false;
    }
}
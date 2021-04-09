// GENERATED AUTOMATICALLY FROM 'Assets/_project/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using Object = UnityEngine.Object;

namespace Roller
{
    public class Controls : IInputActionCollection, IDisposable
    {
        // Gameplay
        readonly InputActionMap m_Gameplay;
        readonly InputAction m_Gameplay_Brake;
        readonly InputAction m_Gameplay_CameraRotation;
        readonly InputAction m_Gameplay_Debug;
        readonly InputAction m_Gameplay_Jump;
        readonly InputAction m_Gameplay_Move;
        readonly InputAction m_Gameplay_Sprint;
        IGameplayActions m_GameplayActionsCallbackInterface;

        public Controls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""346f876d-f04e-4597-9550-52348f2bd0a5"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""b5a46866-5be9-493a-b54f-c138c9f49cf2"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""d86b24ea-2fc8-40d4-8374-32f9015479cd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Brake"",
                    ""type"": ""Button"",
                    ""id"": ""ab0b7ae6-4efe-44e6-a71f-90c2433ba0fb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CameraRotation"",
                    ""type"": ""PassThrough"",
                    ""id"": ""8efc8ba6-a8a3-4269-abfc-5322f2ffbdc4"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""e413580f-9b79-4e6e-b02c-9513ed74b776"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Debug"",
                    ""type"": ""Button"",
                    ""id"": ""35c24b85-25e6-4de5-a202-3f797d0f222e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b5b1ab8b-0205-430a-a2da-d7c80b5fdcb8"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d935974a-e07e-4f1c-ab46-476bb3749683"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7c6d8a24-668c-4e40-a00a-33498a60133c"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Brake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dacf6d57-7eab-4719-bd4e-734b743da7b1"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraRotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""86508382-f62d-4f05-9fe2-d619c1d00abf"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c72936cb-edb7-4ccd-a221-528260cab7c8"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Debug"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Gameplay
            m_Gameplay = asset.FindActionMap("Gameplay", true);
            m_Gameplay_Move = m_Gameplay.FindAction("Move", true);
            m_Gameplay_Jump = m_Gameplay.FindAction("Jump", true);
            m_Gameplay_Brake = m_Gameplay.FindAction("Brake", true);
            m_Gameplay_CameraRotation = m_Gameplay.FindAction("CameraRotation", true);
            m_Gameplay_Sprint = m_Gameplay.FindAction("Sprint", true);
            m_Gameplay_Debug = m_Gameplay.FindAction("Debug", true);
        }

        public InputActionAsset asset { get; }
        public GameplayActions Gameplay => new GameplayActions(this);

        public void Dispose()
        {
            Object.Destroy(asset);
        }

        public InputBinding? bindingMask
        {
            get => asset.bindingMask;
            set => asset.bindingMask = value;
        }

        public ReadOnlyArray<InputDevice>? devices
        {
            get => asset.devices;
            set => asset.devices = value;
        }

        public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

        public bool Contains(InputAction action)
        {
            return asset.Contains(action);
        }

        public IEnumerator<InputAction> GetEnumerator()
        {
            return asset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enable()
        {
            asset.Enable();
        }

        public void Disable()
        {
            asset.Disable();
        }

        public struct GameplayActions
        {
            readonly Controls m_Wrapper;

            public GameplayActions(Controls wrapper)
            {
                m_Wrapper = wrapper;
            }

            public InputAction Move => m_Wrapper.m_Gameplay_Move;
            public InputAction Jump => m_Wrapper.m_Gameplay_Jump;
            public InputAction Brake => m_Wrapper.m_Gameplay_Brake;
            public InputAction CameraRotation => m_Wrapper.m_Gameplay_CameraRotation;
            public InputAction Sprint => m_Wrapper.m_Gameplay_Sprint;
            public InputAction Debug => m_Wrapper.m_Gameplay_Debug;

            public InputActionMap Get()
            {
                return m_Wrapper.m_Gameplay;
            }

            public void Enable()
            {
                Get().Enable();
            }

            public void Disable()
            {
                Get().Disable();
            }

            public bool enabled => Get().enabled;

            public static implicit operator InputActionMap(GameplayActions set)
            {
                return set.Get();
            }

            public void SetCallbacks(IGameplayActions instance)
            {
                if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
                {
                    Move.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                    Move.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                    Move.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                    Jump.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                    Jump.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                    Jump.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                    Brake.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBrake;
                    Brake.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBrake;
                    Brake.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBrake;
                    CameraRotation.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCameraRotation;
                    CameraRotation.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCameraRotation;
                    CameraRotation.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCameraRotation;
                    Sprint.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSprint;
                    Sprint.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSprint;
                    Sprint.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSprint;
                    Debug.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDebug;
                    Debug.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDebug;
                    Debug.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDebug;
                }

                m_Wrapper.m_GameplayActionsCallbackInterface = instance;
                if (instance != null)
                {
                    Move.started += instance.OnMove;
                    Move.performed += instance.OnMove;
                    Move.canceled += instance.OnMove;
                    Jump.started += instance.OnJump;
                    Jump.performed += instance.OnJump;
                    Jump.canceled += instance.OnJump;
                    Brake.started += instance.OnBrake;
                    Brake.performed += instance.OnBrake;
                    Brake.canceled += instance.OnBrake;
                    CameraRotation.started += instance.OnCameraRotation;
                    CameraRotation.performed += instance.OnCameraRotation;
                    CameraRotation.canceled += instance.OnCameraRotation;
                    Sprint.started += instance.OnSprint;
                    Sprint.performed += instance.OnSprint;
                    Sprint.canceled += instance.OnSprint;
                    Debug.started += instance.OnDebug;
                    Debug.performed += instance.OnDebug;
                    Debug.canceled += instance.OnDebug;
                }
            }
        }

        public interface IGameplayActions
        {
            void OnMove(InputAction.CallbackContext context);
            void OnJump(InputAction.CallbackContext context);
            void OnBrake(InputAction.CallbackContext context);
            void OnCameraRotation(InputAction.CallbackContext context);
            void OnSprint(InputAction.CallbackContext context);
            void OnDebug(InputAction.CallbackContext context);
        }
    }
}
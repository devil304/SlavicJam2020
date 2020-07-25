// GENERATED AUTOMATICALLY FROM 'Assets/Input/MainInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @MainInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @MainInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MainInput"",
    ""maps"": [
        {
            ""name"": ""Movement"",
            ""id"": ""5fafb7a9-8039-4c5c-912c-f3b339dd9828"",
            ""actions"": [
                {
                    ""name"": ""up/down"",
                    ""type"": ""Value"",
                    ""id"": ""37edfc02-d2d5-46fa-8765-511f62ce60e5"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""left/right"",
                    ""type"": ""Value"",
                    ""id"": ""73ffcf38-33ca-4fa4-8a75-a1f3854ffcc5"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""action1"",
                    ""type"": ""Button"",
                    ""id"": ""9b98f11b-29bc-4d0d-881a-bd42f20cadbc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""wasd"",
                    ""id"": ""094b392a-71e6-4749-932f-95434808476f"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""up/down"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""c663e7f9-b125-4f5c-9913-4afffb3d9d17"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""up/down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""df78238a-ea5b-474b-9b0d-0cd17f1b6912"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""up/down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""89da9c1c-846e-4330-941a-229265c081ca"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""up/down"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""dec86627-8c39-4871-bd74-5b026461c97c"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""up/down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""6d937291-5191-40e2-ad87-0f3da4377456"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""up/down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""c1fed468-b88e-4304-a7a9-4cdf2999a290"",
                    ""path"": ""<Gamepad>/leftStick/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""up/down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""wasd"",
                    ""id"": ""8adf8694-7712-4308-afeb-9d70026ec777"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""left/right"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""0ff4fefc-9f32-4122-8fbf-df3a682c7b8c"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""left/right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""a5c42a8f-398c-4201-b1e7-92c46b6f6448"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""left/right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""09c9983a-8cac-45c7-8244-02b1d50f9e4e"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""left/right"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""55c0d4bc-ac70-4365-951b-ca41745a73fd"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""left/right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""5c59fae2-ec56-4c38-88aa-c4a08b668295"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""left/right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""3642ce65-45c6-4bc9-b51a-382c8f9dc0d1"",
                    ""path"": ""<Gamepad>/leftStick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""left/right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""095b610d-3d8d-4523-975f-148ffcd623a6"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""action1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e7b1c85c-0597-4922-9bc4-dce3f01547f1"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""action1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""36483e1d-f753-49e7-9476-716d1853404a"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""action1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Movement
        m_Movement = asset.FindActionMap("Movement", throwIfNotFound: true);
        m_Movement_updown = m_Movement.FindAction("up/down", throwIfNotFound: true);
        m_Movement_leftright = m_Movement.FindAction("left/right", throwIfNotFound: true);
        m_Movement_action1 = m_Movement.FindAction("action1", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
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

    // Movement
    private readonly InputActionMap m_Movement;
    private IMovementActions m_MovementActionsCallbackInterface;
    private readonly InputAction m_Movement_updown;
    private readonly InputAction m_Movement_leftright;
    private readonly InputAction m_Movement_action1;
    public struct MovementActions
    {
        private @MainInput m_Wrapper;
        public MovementActions(@MainInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @updown => m_Wrapper.m_Movement_updown;
        public InputAction @leftright => m_Wrapper.m_Movement_leftright;
        public InputAction @action1 => m_Wrapper.m_Movement_action1;
        public InputActionMap Get() { return m_Wrapper.m_Movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
        public void SetCallbacks(IMovementActions instance)
        {
            if (m_Wrapper.m_MovementActionsCallbackInterface != null)
            {
                @updown.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnUpdown;
                @updown.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnUpdown;
                @updown.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnUpdown;
                @leftright.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnLeftright;
                @leftright.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnLeftright;
                @leftright.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnLeftright;
                @action1.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnAction1;
                @action1.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnAction1;
                @action1.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnAction1;
            }
            m_Wrapper.m_MovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @updown.started += instance.OnUpdown;
                @updown.performed += instance.OnUpdown;
                @updown.canceled += instance.OnUpdown;
                @leftright.started += instance.OnLeftright;
                @leftright.performed += instance.OnLeftright;
                @leftright.canceled += instance.OnLeftright;
                @action1.started += instance.OnAction1;
                @action1.performed += instance.OnAction1;
                @action1.canceled += instance.OnAction1;
            }
        }
    }
    public MovementActions @Movement => new MovementActions(this);
    public interface IMovementActions
    {
        void OnUpdown(InputAction.CallbackContext context);
        void OnLeftright(InputAction.CallbackContext context);
        void OnAction1(InputAction.CallbackContext context);
    }
}

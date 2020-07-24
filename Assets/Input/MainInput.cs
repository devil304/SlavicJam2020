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
            ""name"": ""nam"",
            ""id"": ""5fafb7a9-8039-4c5c-912c-f3b339dd9828"",
            ""actions"": [
                {
                    ""name"": ""na"",
                    ""type"": ""Button"",
                    ""id"": ""37edfc02-d2d5-46fa-8765-511f62ce60e5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""53f56e83-0487-4106-8afd-1f30e05fb049"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""na"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // nam
        m_nam = asset.FindActionMap("nam", throwIfNotFound: true);
        m_nam_na = m_nam.FindAction("na", throwIfNotFound: true);
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

    // nam
    private readonly InputActionMap m_nam;
    private INamActions m_NamActionsCallbackInterface;
    private readonly InputAction m_nam_na;
    public struct NamActions
    {
        private @MainInput m_Wrapper;
        public NamActions(@MainInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @na => m_Wrapper.m_nam_na;
        public InputActionMap Get() { return m_Wrapper.m_nam; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(NamActions set) { return set.Get(); }
        public void SetCallbacks(INamActions instance)
        {
            if (m_Wrapper.m_NamActionsCallbackInterface != null)
            {
                @na.started -= m_Wrapper.m_NamActionsCallbackInterface.OnNa;
                @na.performed -= m_Wrapper.m_NamActionsCallbackInterface.OnNa;
                @na.canceled -= m_Wrapper.m_NamActionsCallbackInterface.OnNa;
            }
            m_Wrapper.m_NamActionsCallbackInterface = instance;
            if (instance != null)
            {
                @na.started += instance.OnNa;
                @na.performed += instance.OnNa;
                @na.canceled += instance.OnNa;
            }
        }
    }
    public NamActions @nam => new NamActions(this);
    public interface INamActions
    {
        void OnNa(InputAction.CallbackContext context);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.11.2
//     from Assets/Scripts/playerInputSystem/playerInput.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""playerInput"",
    ""maps"": [
        {
            ""name"": ""onFoot"",
            ""id"": ""1f9c185a-c187-4b89-8fa4-b8cb174be857"",
            ""actions"": [
                {
                    ""name"": ""playerMovement"",
                    ""type"": ""Value"",
                    ""id"": ""419de59e-43a4-474c-8505-ccb74e737183"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""playerJump"",
                    ""type"": ""Button"",
                    ""id"": ""8a9197c2-b2d2-46f2-b9e6-72a76290d7d2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""playerLook"",
                    ""type"": ""Value"",
                    ""id"": ""ddf13fbf-389a-4866-9a9d-75fd2854b9c7"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""9700ebf0-c607-4e8a-850f-f03bfb7fecd6"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""playerMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""6035d290-1f96-4455-9505-2b59851062ab"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""playerMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""9b1a51c3-63c4-4f54-9b95-9a01a3a2e3f1"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""playerMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""a4c7fc87-f74a-4b51-9039-edb7c9760711"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""playerMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""19d85c78-9860-4316-a492-b9b3e804b21e"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""playerMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""865160f7-c681-4036-a72c-2e5a2116adcc"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""playerJump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""082c141b-4d04-44c0-af22-6143105fd2a0"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""playerLook"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // onFoot
        m_onFoot = asset.FindActionMap("onFoot", throwIfNotFound: true);
        m_onFoot_playerMovement = m_onFoot.FindAction("playerMovement", throwIfNotFound: true);
        m_onFoot_playerJump = m_onFoot.FindAction("playerJump", throwIfNotFound: true);
        m_onFoot_playerLook = m_onFoot.FindAction("playerLook", throwIfNotFound: true);
    }

    ~@PlayerInput()
    {
        UnityEngine.Debug.Assert(!m_onFoot.enabled, "This will cause a leak and performance issues, PlayerInput.onFoot.Disable() has not been called.");
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // onFoot
    private readonly InputActionMap m_onFoot;
    private List<IOnFootActions> m_OnFootActionsCallbackInterfaces = new List<IOnFootActions>();
    private readonly InputAction m_onFoot_playerMovement;
    private readonly InputAction m_onFoot_playerJump;
    private readonly InputAction m_onFoot_playerLook;
    public struct OnFootActions
    {
        private @PlayerInput m_Wrapper;
        public OnFootActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @playerMovement => m_Wrapper.m_onFoot_playerMovement;
        public InputAction @playerJump => m_Wrapper.m_onFoot_playerJump;
        public InputAction @playerLook => m_Wrapper.m_onFoot_playerLook;
        public InputActionMap Get() { return m_Wrapper.m_onFoot; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(OnFootActions set) { return set.Get(); }
        public void AddCallbacks(IOnFootActions instance)
        {
            if (instance == null || m_Wrapper.m_OnFootActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_OnFootActionsCallbackInterfaces.Add(instance);
            @playerMovement.started += instance.OnPlayerMovement;
            @playerMovement.performed += instance.OnPlayerMovement;
            @playerMovement.canceled += instance.OnPlayerMovement;
            @playerJump.started += instance.OnPlayerJump;
            @playerJump.performed += instance.OnPlayerJump;
            @playerJump.canceled += instance.OnPlayerJump;
            @playerLook.started += instance.OnPlayerLook;
            @playerLook.performed += instance.OnPlayerLook;
            @playerLook.canceled += instance.OnPlayerLook;
        }

        private void UnregisterCallbacks(IOnFootActions instance)
        {
            @playerMovement.started -= instance.OnPlayerMovement;
            @playerMovement.performed -= instance.OnPlayerMovement;
            @playerMovement.canceled -= instance.OnPlayerMovement;
            @playerJump.started -= instance.OnPlayerJump;
            @playerJump.performed -= instance.OnPlayerJump;
            @playerJump.canceled -= instance.OnPlayerJump;
            @playerLook.started -= instance.OnPlayerLook;
            @playerLook.performed -= instance.OnPlayerLook;
            @playerLook.canceled -= instance.OnPlayerLook;
        }

        public void RemoveCallbacks(IOnFootActions instance)
        {
            if (m_Wrapper.m_OnFootActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IOnFootActions instance)
        {
            foreach (var item in m_Wrapper.m_OnFootActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_OnFootActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public OnFootActions @onFoot => new OnFootActions(this);
    public interface IOnFootActions
    {
        void OnPlayerMovement(InputAction.CallbackContext context);
        void OnPlayerJump(InputAction.CallbackContext context);
        void OnPlayerLook(InputAction.CallbackContext context);
    }
}

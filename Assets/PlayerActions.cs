//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Input/Controls.inputactions
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

public partial class @PlayerActions : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Golf"",
            ""id"": ""f9077175-d278-4668-87ab-e0daa245e575"",
            ""actions"": [
                {
                    ""name"": ""Aim"",
                    ""type"": ""Value"",
                    ""id"": ""68e72f81-ee8a-42cf-a753-b9621f3803ce"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""c9cfc464-23ee-45f3-856a-0b87f7a973aa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LobMode"",
                    ""type"": ""Button"",
                    ""id"": ""5afdb256-84be-427d-948c-60c4525993b4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""2135156b-a6ee-4341-a2ae-eee19ef80311"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Negative"",
                    ""id"": ""62ceeef9-5b67-41a3-814a-a25da6a19f4d"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Positive"",
                    ""id"": ""9c574f59-65ff-41d0-a332-9d77ca27f009"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""2e6f6047-5ef0-40dd-81f1-a6c26b2e610f"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""c6d7767f-485b-4d26-a286-6fd9cb63ef00"",
                    ""path"": ""<Joystick>/stick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""60e6f652-57e8-4df9-b949-0149c6ef7b27"",
                    ""path"": ""<Joystick>/stick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""a91f6c15-0162-4952-a4f4-3d53ab9c0c26"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""301be7bd-c9ec-4676-ae39-c54c22513448"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""664a8d5a-85c5-4620-b1fb-e66f09cc7847"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LobMode"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ad2cee9d-f3a9-4d05-bfdf-4ec7dba8e502"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LobMode"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Golf
        m_Golf = asset.FindActionMap("Golf", throwIfNotFound: true);
        m_Golf_Aim = m_Golf.FindAction("Aim", throwIfNotFound: true);
        m_Golf_Shoot = m_Golf.FindAction("Shoot", throwIfNotFound: true);
        m_Golf_LobMode = m_Golf.FindAction("LobMode", throwIfNotFound: true);
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

    // Golf
    private readonly InputActionMap m_Golf;
    private IGolfActions m_GolfActionsCallbackInterface;
    private readonly InputAction m_Golf_Aim;
    private readonly InputAction m_Golf_Shoot;
    private readonly InputAction m_Golf_LobMode;
    public struct GolfActions
    {
        private @PlayerActions m_Wrapper;
        public GolfActions(@PlayerActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Aim => m_Wrapper.m_Golf_Aim;
        public InputAction @Shoot => m_Wrapper.m_Golf_Shoot;
        public InputAction @LobMode => m_Wrapper.m_Golf_LobMode;
        public InputActionMap Get() { return m_Wrapper.m_Golf; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GolfActions set) { return set.Get(); }
        public void SetCallbacks(IGolfActions instance)
        {
            if (m_Wrapper.m_GolfActionsCallbackInterface != null)
            {
                @Aim.started -= m_Wrapper.m_GolfActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_GolfActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_GolfActionsCallbackInterface.OnAim;
                @Shoot.started -= m_Wrapper.m_GolfActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_GolfActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_GolfActionsCallbackInterface.OnShoot;
                @LobMode.started -= m_Wrapper.m_GolfActionsCallbackInterface.OnLobMode;
                @LobMode.performed -= m_Wrapper.m_GolfActionsCallbackInterface.OnLobMode;
                @LobMode.canceled -= m_Wrapper.m_GolfActionsCallbackInterface.OnLobMode;
            }
            m_Wrapper.m_GolfActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @LobMode.started += instance.OnLobMode;
                @LobMode.performed += instance.OnLobMode;
                @LobMode.canceled += instance.OnLobMode;
            }
        }
    }
    public GolfActions @Golf => new GolfActions(this);
    public interface IGolfActions
    {
        void OnAim(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnLobMode(InputAction.CallbackContext context);
    }
}

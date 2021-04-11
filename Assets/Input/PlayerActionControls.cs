// GENERATED AUTOMATICALLY FROM 'Assets/Input/PlayerActionControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerActionControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerActionControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerActionControls"",
    ""maps"": [
        {
            ""name"": ""Action"",
            ""id"": ""323686ab-0f15-4448-abd2-6ec6182dfea4"",
            ""actions"": [
                {
                    ""name"": ""Whip"",
                    ""type"": ""Button"",
                    ""id"": ""7f70a29d-8bb5-4a86-9895-904752c34b08"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4da63400-b54a-432b-a0fe-b36b1bd901ee"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Whip"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Action
        m_Action = asset.FindActionMap("Action", throwIfNotFound: true);
        m_Action_Whip = m_Action.FindAction("Whip", throwIfNotFound: true);
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

    // Action
    private readonly InputActionMap m_Action;
    private IActionActions m_ActionActionsCallbackInterface;
    private readonly InputAction m_Action_Whip;
    public struct ActionActions
    {
        private @PlayerActionControls m_Wrapper;
        public ActionActions(@PlayerActionControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Whip => m_Wrapper.m_Action_Whip;
        public InputActionMap Get() { return m_Wrapper.m_Action; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ActionActions set) { return set.Get(); }
        public void SetCallbacks(IActionActions instance)
        {
            if (m_Wrapper.m_ActionActionsCallbackInterface != null)
            {
                @Whip.started -= m_Wrapper.m_ActionActionsCallbackInterface.OnWhip;
                @Whip.performed -= m_Wrapper.m_ActionActionsCallbackInterface.OnWhip;
                @Whip.canceled -= m_Wrapper.m_ActionActionsCallbackInterface.OnWhip;
            }
            m_Wrapper.m_ActionActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Whip.started += instance.OnWhip;
                @Whip.performed += instance.OnWhip;
                @Whip.canceled += instance.OnWhip;
            }
        }
    }
    public ActionActions @Action => new ActionActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    public interface IActionActions
    {
        void OnWhip(InputAction.CallbackContext context);
    }
}

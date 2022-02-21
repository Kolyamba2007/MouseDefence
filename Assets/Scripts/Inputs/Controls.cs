// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Inputs/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""UI"",
            ""id"": ""36829ed6-25d0-4940-9e6b-93c8e397eeb9"",
            ""actions"": [
                {
                    ""name"": ""PauseMenu"",
                    ""type"": ""Button"",
                    ""id"": ""a3b3762a-fcd0-40ce-a98e-2d3b8f969529"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CancelSelection"",
                    ""type"": ""Button"",
                    ""id"": ""61dade27-81bb-43e0-8b0a-d08975319e6f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LMB"",
                    ""type"": ""Button"",
                    ""id"": ""cac99830-37eb-485a-9e23-0b437c54de8f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7b746ac8-6b8f-4703-890f-5ae739dbd716"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PauseMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3d02c2da-6122-4a24-b643-a662c9da9e94"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CancelSelection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3fbd3efe-dcaa-4ea8-891d-260a9f0e5f2a"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CancelSelection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""03ca25ab-327f-4487-954b-ff00f2366a64"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LMB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_PauseMenu = m_UI.FindAction("PauseMenu", throwIfNotFound: true);
        m_UI_CancelSelection = m_UI.FindAction("CancelSelection", throwIfNotFound: true);
        m_UI_LMB = m_UI.FindAction("LMB", throwIfNotFound: true);
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

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_PauseMenu;
    private readonly InputAction m_UI_CancelSelection;
    private readonly InputAction m_UI_LMB;
    public struct UIActions
    {
        private @Controls m_Wrapper;
        public UIActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @PauseMenu => m_Wrapper.m_UI_PauseMenu;
        public InputAction @CancelSelection => m_Wrapper.m_UI_CancelSelection;
        public InputAction @LMB => m_Wrapper.m_UI_LMB;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @PauseMenu.started -= m_Wrapper.m_UIActionsCallbackInterface.OnPauseMenu;
                @PauseMenu.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnPauseMenu;
                @PauseMenu.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnPauseMenu;
                @CancelSelection.started -= m_Wrapper.m_UIActionsCallbackInterface.OnCancelSelection;
                @CancelSelection.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnCancelSelection;
                @CancelSelection.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnCancelSelection;
                @LMB.started -= m_Wrapper.m_UIActionsCallbackInterface.OnLMB;
                @LMB.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnLMB;
                @LMB.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnLMB;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PauseMenu.started += instance.OnPauseMenu;
                @PauseMenu.performed += instance.OnPauseMenu;
                @PauseMenu.canceled += instance.OnPauseMenu;
                @CancelSelection.started += instance.OnCancelSelection;
                @CancelSelection.performed += instance.OnCancelSelection;
                @CancelSelection.canceled += instance.OnCancelSelection;
                @LMB.started += instance.OnLMB;
                @LMB.performed += instance.OnLMB;
                @LMB.canceled += instance.OnLMB;
            }
        }
    }
    public UIActions @UI => new UIActions(this);
    public interface IUIActions
    {
        void OnPauseMenu(InputAction.CallbackContext context);
        void OnCancelSelection(InputAction.CallbackContext context);
        void OnLMB(InputAction.CallbackContext context);
    }
}

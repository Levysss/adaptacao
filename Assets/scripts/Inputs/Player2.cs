//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/scripts/Player2.inputactions
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

public partial class @Player2: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Player2()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player2"",
    ""maps"": [
        {
            ""name"": ""Jogador"",
            ""id"": ""6daf1707-f863-4ce9-9660-558fdcc58017"",
            ""actions"": [
                {
                    ""name"": ""Movimento"",
                    ""type"": ""Value"",
                    ""id"": ""3dc840e2-6b26-46f8-9981-cc8155ba6af5"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Atirar"",
                    ""type"": ""Button"",
                    ""id"": ""0fbf0e81-392a-4935-8a60-b5d509f51eac"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Setas"",
                    ""id"": ""edc3be25-8ec2-49f8-8f1b-a38743d44ceb"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movimento"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""7d447548-ac85-4ff7-b215-e09fcb3b3240"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movimento"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""234a59af-f856-4093-bce5-361a8918f433"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movimento"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""5698b000-6445-4cee-a17a-651d7739c50f"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movimento"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""27729452-ec54-44f1-88b2-a0dc3454836a"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movimento"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""053cff97-5cbe-4941-ae9c-faf5c95fa767"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Atirar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Jogador
        m_Jogador = asset.FindActionMap("Jogador", throwIfNotFound: true);
        m_Jogador_Movimento = m_Jogador.FindAction("Movimento", throwIfNotFound: true);
        m_Jogador_Atirar = m_Jogador.FindAction("Atirar", throwIfNotFound: true);
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

    // Jogador
    private readonly InputActionMap m_Jogador;
    private List<IJogadorActions> m_JogadorActionsCallbackInterfaces = new List<IJogadorActions>();
    private readonly InputAction m_Jogador_Movimento;
    private readonly InputAction m_Jogador_Atirar;
    public struct JogadorActions
    {
        private @Player2 m_Wrapper;
        public JogadorActions(@Player2 wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movimento => m_Wrapper.m_Jogador_Movimento;
        public InputAction @Atirar => m_Wrapper.m_Jogador_Atirar;
        public InputActionMap Get() { return m_Wrapper.m_Jogador; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(JogadorActions set) { return set.Get(); }
        public void AddCallbacks(IJogadorActions instance)
        {
            if (instance == null || m_Wrapper.m_JogadorActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_JogadorActionsCallbackInterfaces.Add(instance);
            @Movimento.started += instance.OnMovimento;
            @Movimento.performed += instance.OnMovimento;
            @Movimento.canceled += instance.OnMovimento;
            @Atirar.started += instance.OnAtirar;
            @Atirar.performed += instance.OnAtirar;
            @Atirar.canceled += instance.OnAtirar;
        }

        private void UnregisterCallbacks(IJogadorActions instance)
        {
            @Movimento.started -= instance.OnMovimento;
            @Movimento.performed -= instance.OnMovimento;
            @Movimento.canceled -= instance.OnMovimento;
            @Atirar.started -= instance.OnAtirar;
            @Atirar.performed -= instance.OnAtirar;
            @Atirar.canceled -= instance.OnAtirar;
        }

        public void RemoveCallbacks(IJogadorActions instance)
        {
            if (m_Wrapper.m_JogadorActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IJogadorActions instance)
        {
            foreach (var item in m_Wrapper.m_JogadorActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_JogadorActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public JogadorActions @Jogador => new JogadorActions(this);
    public interface IJogadorActions
    {
        void OnMovimento(InputAction.CallbackContext context);
        void OnAtirar(InputAction.CallbackContext context);
    }
}
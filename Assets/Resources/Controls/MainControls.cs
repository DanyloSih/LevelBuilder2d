//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.1
//     from Assets/Resources/Controls/MainControls.inputactions
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

public partial class @MainControls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @MainControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MainControls"",
    ""maps"": [
        {
            ""name"": ""Camera"",
            ""id"": ""4ad0a96c-5223-472d-b449-bbf7a51b5556"",
            ""actions"": [
                {
                    ""name"": ""Moving"",
                    ""type"": ""PassThrough"",
                    ""id"": ""d04c2cbf-a469-4af3-9700-026abc46e978"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Zoom"",
                    ""type"": ""PassThrough"",
                    ""id"": ""1b3e97f5-f815-4e0d-9eed-81b98e13babd"",
                    ""expectedControlType"": """",
                    ""processors"": ""Clamp(min=-1,max=1),Invert"",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f5b09262-cc30-4b29-9dd1-c94e097dba2a"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""MouseScreenGrabing"",
                    ""id"": ""edbaa9bc-cfe7-4327-b44f-7fcf24980f1f"",
                    ""path"": ""OneModifier(overrideModifiersNeedToBePressedFirst=true)"",
                    ""interactions"": """",
                    ""processors"": ""InvertVector2"",
                    ""groups"": """",
                    ""action"": ""Moving"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""48042187-9362-4e3e-b4f6-5e68d44b185d"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moving"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""binding"",
                    ""id"": ""c2cc17e0-d921-4efc-ba99-97a082a3d0e8"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moving"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""TouchScreenGrabing"",
                    ""id"": ""7a038a9e-9575-499e-b6f4-c6de94fa5d8b"",
                    ""path"": ""OneModifier(overrideModifiersNeedToBePressedFirst=true)"",
                    ""interactions"": """",
                    ""processors"": ""InvertVector2"",
                    ""groups"": """",
                    ""action"": ""Moving"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""f52779cc-d0b2-4eb2-a7d1-0aaaeb5c583f"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moving"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""binding"",
                    ""id"": ""5cfd4af2-4cd2-477c-bd98-b84f737ce9cd"",
                    ""path"": ""<Touchscreen>/primaryTouch/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moving"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""FigureSpawner"",
            ""id"": ""f5248f3e-70b0-496e-9d09-b0bc7da6686f"",
            ""actions"": [
                {
                    ""name"": ""Spawn"",
                    ""type"": ""Button"",
                    ""id"": ""90ea75e5-79cb-4bd0-8cd6-034ae76ae4a1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SpawnPointerPosition"",
                    ""type"": ""Value"",
                    ""id"": ""983e675b-1e70-4ef8-b82f-370b6a155f1b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3f41ea23-9f6d-447a-a741-4a153e89c4cf"",
                    ""path"": ""<Mouse>/press"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Spawn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""968f14b3-c492-4711-b98b-02b9969ab6ae"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Spawn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ecbb5ab2-ec69-4f40-99de-042161e96895"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SpawnPointerPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""07895145-ad97-4c42-9638-4dd1cd3f2723"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SpawnPointerPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""FigureSelector"",
            ""id"": ""cce6da6f-cf10-404d-9ee9-1947546a3a76"",
            ""actions"": [
                {
                    ""name"": ""StartSelection"",
                    ""type"": ""Button"",
                    ""id"": ""391f3080-d4ce-449b-b857-fa1bc9f50217"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""StopSelection"",
                    ""type"": ""Button"",
                    ""id"": ""ebb15a53-5929-4959-8bcb-a03a0cccef5d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SelectionPointerMove"",
                    ""type"": ""Value"",
                    ""id"": ""22d1d40a-a8ca-441f-8739-66d262086019"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1b7447df-f9d8-4d85-9a71-a25e7170649e"",
                    ""path"": ""<Mouse>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StopSelection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""98cc84df-b7d8-48c3-81cc-ed274c9289c1"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StopSelection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a074cae8-445c-4f09-ae36-6b0b2cfd39fe"",
                    ""path"": ""<Mouse>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StartSelection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""50ba8c45-ecc0-45b3-b983-bac29ccfa44f"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StartSelection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8472a615-7d57-4a52-8149-70bd13d8286d"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectionPointerMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""da115e61-c127-40ee-9d56-93a2febfdaf5"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectionPointerMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Camera
        m_Camera = asset.FindActionMap("Camera", throwIfNotFound: true);
        m_Camera_Moving = m_Camera.FindAction("Moving", throwIfNotFound: true);
        m_Camera_Zoom = m_Camera.FindAction("Zoom", throwIfNotFound: true);
        // FigureSpawner
        m_FigureSpawner = asset.FindActionMap("FigureSpawner", throwIfNotFound: true);
        m_FigureSpawner_Spawn = m_FigureSpawner.FindAction("Spawn", throwIfNotFound: true);
        m_FigureSpawner_SpawnPointerPosition = m_FigureSpawner.FindAction("SpawnPointerPosition", throwIfNotFound: true);
        // FigureSelector
        m_FigureSelector = asset.FindActionMap("FigureSelector", throwIfNotFound: true);
        m_FigureSelector_StartSelection = m_FigureSelector.FindAction("StartSelection", throwIfNotFound: true);
        m_FigureSelector_StopSelection = m_FigureSelector.FindAction("StopSelection", throwIfNotFound: true);
        m_FigureSelector_SelectionPointerMove = m_FigureSelector.FindAction("SelectionPointerMove", throwIfNotFound: true);
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

    // Camera
    private readonly InputActionMap m_Camera;
    private ICameraActions m_CameraActionsCallbackInterface;
    private readonly InputAction m_Camera_Moving;
    private readonly InputAction m_Camera_Zoom;
    public struct CameraActions
    {
        private @MainControls m_Wrapper;
        public CameraActions(@MainControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Moving => m_Wrapper.m_Camera_Moving;
        public InputAction @Zoom => m_Wrapper.m_Camera_Zoom;
        public InputActionMap Get() { return m_Wrapper.m_Camera; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CameraActions set) { return set.Get(); }
        public void SetCallbacks(ICameraActions instance)
        {
            if (m_Wrapper.m_CameraActionsCallbackInterface != null)
            {
                @Moving.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnMoving;
                @Moving.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnMoving;
                @Moving.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnMoving;
                @Zoom.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnZoom;
                @Zoom.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnZoom;
                @Zoom.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnZoom;
            }
            m_Wrapper.m_CameraActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Moving.started += instance.OnMoving;
                @Moving.performed += instance.OnMoving;
                @Moving.canceled += instance.OnMoving;
                @Zoom.started += instance.OnZoom;
                @Zoom.performed += instance.OnZoom;
                @Zoom.canceled += instance.OnZoom;
            }
        }
    }
    public CameraActions @Camera => new CameraActions(this);

    // FigureSpawner
    private readonly InputActionMap m_FigureSpawner;
    private IFigureSpawnerActions m_FigureSpawnerActionsCallbackInterface;
    private readonly InputAction m_FigureSpawner_Spawn;
    private readonly InputAction m_FigureSpawner_SpawnPointerPosition;
    public struct FigureSpawnerActions
    {
        private @MainControls m_Wrapper;
        public FigureSpawnerActions(@MainControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Spawn => m_Wrapper.m_FigureSpawner_Spawn;
        public InputAction @SpawnPointerPosition => m_Wrapper.m_FigureSpawner_SpawnPointerPosition;
        public InputActionMap Get() { return m_Wrapper.m_FigureSpawner; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(FigureSpawnerActions set) { return set.Get(); }
        public void SetCallbacks(IFigureSpawnerActions instance)
        {
            if (m_Wrapper.m_FigureSpawnerActionsCallbackInterface != null)
            {
                @Spawn.started -= m_Wrapper.m_FigureSpawnerActionsCallbackInterface.OnSpawn;
                @Spawn.performed -= m_Wrapper.m_FigureSpawnerActionsCallbackInterface.OnSpawn;
                @Spawn.canceled -= m_Wrapper.m_FigureSpawnerActionsCallbackInterface.OnSpawn;
                @SpawnPointerPosition.started -= m_Wrapper.m_FigureSpawnerActionsCallbackInterface.OnSpawnPointerPosition;
                @SpawnPointerPosition.performed -= m_Wrapper.m_FigureSpawnerActionsCallbackInterface.OnSpawnPointerPosition;
                @SpawnPointerPosition.canceled -= m_Wrapper.m_FigureSpawnerActionsCallbackInterface.OnSpawnPointerPosition;
            }
            m_Wrapper.m_FigureSpawnerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Spawn.started += instance.OnSpawn;
                @Spawn.performed += instance.OnSpawn;
                @Spawn.canceled += instance.OnSpawn;
                @SpawnPointerPosition.started += instance.OnSpawnPointerPosition;
                @SpawnPointerPosition.performed += instance.OnSpawnPointerPosition;
                @SpawnPointerPosition.canceled += instance.OnSpawnPointerPosition;
            }
        }
    }
    public FigureSpawnerActions @FigureSpawner => new FigureSpawnerActions(this);

    // FigureSelector
    private readonly InputActionMap m_FigureSelector;
    private IFigureSelectorActions m_FigureSelectorActionsCallbackInterface;
    private readonly InputAction m_FigureSelector_StartSelection;
    private readonly InputAction m_FigureSelector_StopSelection;
    private readonly InputAction m_FigureSelector_SelectionPointerMove;
    public struct FigureSelectorActions
    {
        private @MainControls m_Wrapper;
        public FigureSelectorActions(@MainControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @StartSelection => m_Wrapper.m_FigureSelector_StartSelection;
        public InputAction @StopSelection => m_Wrapper.m_FigureSelector_StopSelection;
        public InputAction @SelectionPointerMove => m_Wrapper.m_FigureSelector_SelectionPointerMove;
        public InputActionMap Get() { return m_Wrapper.m_FigureSelector; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(FigureSelectorActions set) { return set.Get(); }
        public void SetCallbacks(IFigureSelectorActions instance)
        {
            if (m_Wrapper.m_FigureSelectorActionsCallbackInterface != null)
            {
                @StartSelection.started -= m_Wrapper.m_FigureSelectorActionsCallbackInterface.OnStartSelection;
                @StartSelection.performed -= m_Wrapper.m_FigureSelectorActionsCallbackInterface.OnStartSelection;
                @StartSelection.canceled -= m_Wrapper.m_FigureSelectorActionsCallbackInterface.OnStartSelection;
                @StopSelection.started -= m_Wrapper.m_FigureSelectorActionsCallbackInterface.OnStopSelection;
                @StopSelection.performed -= m_Wrapper.m_FigureSelectorActionsCallbackInterface.OnStopSelection;
                @StopSelection.canceled -= m_Wrapper.m_FigureSelectorActionsCallbackInterface.OnStopSelection;
                @SelectionPointerMove.started -= m_Wrapper.m_FigureSelectorActionsCallbackInterface.OnSelectionPointerMove;
                @SelectionPointerMove.performed -= m_Wrapper.m_FigureSelectorActionsCallbackInterface.OnSelectionPointerMove;
                @SelectionPointerMove.canceled -= m_Wrapper.m_FigureSelectorActionsCallbackInterface.OnSelectionPointerMove;
            }
            m_Wrapper.m_FigureSelectorActionsCallbackInterface = instance;
            if (instance != null)
            {
                @StartSelection.started += instance.OnStartSelection;
                @StartSelection.performed += instance.OnStartSelection;
                @StartSelection.canceled += instance.OnStartSelection;
                @StopSelection.started += instance.OnStopSelection;
                @StopSelection.performed += instance.OnStopSelection;
                @StopSelection.canceled += instance.OnStopSelection;
                @SelectionPointerMove.started += instance.OnSelectionPointerMove;
                @SelectionPointerMove.performed += instance.OnSelectionPointerMove;
                @SelectionPointerMove.canceled += instance.OnSelectionPointerMove;
            }
        }
    }
    public FigureSelectorActions @FigureSelector => new FigureSelectorActions(this);
    public interface ICameraActions
    {
        void OnMoving(InputAction.CallbackContext context);
        void OnZoom(InputAction.CallbackContext context);
    }
    public interface IFigureSpawnerActions
    {
        void OnSpawn(InputAction.CallbackContext context);
        void OnSpawnPointerPosition(InputAction.CallbackContext context);
    }
    public interface IFigureSelectorActions
    {
        void OnStartSelection(InputAction.CallbackContext context);
        void OnStopSelection(InputAction.CallbackContext context);
        void OnSelectionPointerMove(InputAction.CallbackContext context);
    }
}

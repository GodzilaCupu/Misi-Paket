using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using GodzillaCupu.Manager;
using UnityEngine.UI;

namespace GodzillaCupu.Player
{
    public class InputHandler : MonoBehaviour
    {
        public PlatformManager _platform;
        public PlayerInputHandler _inputs;
        public VariableJoystick _joystick;

        [HideInInspector] public UnityEvent OnEscPressed;
        [HideInInspector] public UnityEvent OnSpacePressed;

        private Vector2 _move;
        public Vector2 MoveDirection
        {
            get => _move;
        }

        private bool canJump;
        public bool CanJump
        {
            get => canJump;
        }

        public static InputHandler instance;

        public void Awake()
        {
            if (instance == null)
                instance = this;
            else
                Destroy(instance);

            if (_inputs == null)
                _inputs = new PlayerInputHandler();

            if (_platform == null)
                _platform = PlatformManager.instace;

            if (_joystick == null)
                Debug.LogError("[JOYSTICK INPUT] joystick is empty");
        }

        public void OnEnable()
        {
            if(Application.platform != RuntimePlatform.Android) EnableKeyboardControl();
            else
            GetMovementFromJoystick_UI();
        }

        public void OnDisable()
        {
            if (Application.platform != RuntimePlatform.Android) DisableKeyboardControl();
        }

        private void EnableKeyboardControl()
        {
            _inputs.Enable();

            _inputs.Player.Pause.performed += (ctx) => OnEscPressed?.Invoke();

            _inputs.Player.Movement.performed += (ctx) => _move = ctx.ReadValue<Vector2>();
            _inputs.Player.Movement.canceled += (ctx) => _move = Vector2.zero;

            _inputs.Player.Jump.performed += (ctx) => OnSpacePressed?.Invoke();

            //grab (G)

            //throw (T)

            //drop (B)
        }

        private void DisableKeyboardControl()
        {
            _inputs.Disable();

            _inputs.Player.Pause.performed -= (ctx) => OnEscPressed?.Invoke();

            _inputs.Player.Movement.performed -= (ctx) => _move = ctx.ReadValue<Vector2>();
            _inputs.Player.Movement.canceled -= (ctx) => _move = Vector2.zero;

            _inputs.Player.Jump.performed -= (ctx) => OnSpacePressed?.Invoke();

            //grab (G)

            //throw (T)

            //drop (B)
        }

        public void GetMovementFromJoystick_UI()
        {
            float _vertical = _joystick.Vertical;
            float _horizontal = _joystick.Horizontal;
            Vector2 tempDir = new Vector2(_horizontal,_vertical);
            _move = tempDir;
        }
    }
}

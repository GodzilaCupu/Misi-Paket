using System;
using UnityEngine;

namespace Mangkus.Player.Input
{
    public class PlayerInputController : MonoBehaviour
    {
        [SerializeField]private InputType inputType;

        private KeyboardController keyboardController;
        private JoystickController joystickController;
        private IMovementInput provider;
        public IMovementInput GetProvider => provider;
        private void Awake()
        {
            InitilizedInputType();
        }

        private void InitilizedInputType()
        {
            switch (inputType)
            {
                case InputType.keyboard:
                    keyboardController = this.gameObject.AddComponent<KeyboardController>();
                    provider = keyboardController as IMovementInput;
                    Debug.Log("Keyboard input selected");
                    break;

                case InputType.joystick:
                    joystickController = this.gameObject.AddComponent<JoystickController>();
                    provider = joystickController as IMovementInput;
                    Debug.Log("Joystick input selected");
                    break;
            }
        }
    }
}

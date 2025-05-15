using UnityEngine;
using Mangkus.Player.Input;

namespace Mangkus.Player.Movement
{
    [RequireComponent(typeof(PlayerMovementView))]
    public class PlayerMovementController : MonoBehaviour
    {
        private PlayerMovementModel model;
        private PlayerMovementView view;
        private IMovementInput input;

        [SerializeField] private InputType inputType; // Must implement IMovementInput

        private void Awake()
        {
            model = new PlayerMovementModel();
            view = GetComponent<PlayerMovementView>();
            input = GetInputProvider();

            if (input == null)
            {
                Debug.LogError("Input Provider must implement IMovementInput");
            }
        }

        private void Update()
        {
            Vector3 dir = input.GetMoveDirection();
            view.Move(dir, model.MoveSpeed);
            view.Rotate(dir, model.RotationSpeed);
        }

        private IMovementInput GetInputProvider()
        {
            switch (inputType)
            {
                case InputType.keyboard:
                    Debug.Log("Keyboard input selected");
                    var keyboardProvider = this.gameObject.AddComponent<KeyboardModel>();
                    return keyboardProvider as IMovementInput;

                case InputType.joystick:
                    var joystickProvider = this.gameObject.AddComponent<JoystickModel>();
                    return joystickProvider as IMovementInput;

                default:
                    Debug.LogError("Invalid input type selected");
                    return null;
            }
        }
    }


}

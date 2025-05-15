using UnityEngine;
using Mangkus.Input;

namespace Mangkus.Input
{
    public class JoystickInput : MonoBehaviour, IMovementInput
    {
        [SerializeField] private Joystick joystick;

        public Vector3 GetMoveDirection()
        {
            Vector2 input = joystick.InputDirection;
            return new Vector3(input.x, 0, input.y).normalized;
        }
    }
}
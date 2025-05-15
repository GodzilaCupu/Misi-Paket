using UnityEngine;

namespace Mangkus.Player.Input
{
    public class JoystickModel : MonoBehaviour, IMovementInput
    {
        [SerializeField] private Joystick joystick;

        public Vector3 GetMoveDirection()
        {
            Vector2 input = joystick.Direction;
            return new Vector3(input.x, 0, input.y).normalized;
        }
    }
}
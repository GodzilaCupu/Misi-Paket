using UnityEditor.Rendering.LookDev;
using UnityEngine;

namespace Mangkus.Player.Input
{
    public class JoystickController : MonoBehaviour, IMovementInput
    {
        private InputJoystickView view;

        [SerializeField] private GameObject joystickPrefab;
        [SerializeField] private Transform transformParent;

        private void Start()
        {
            if (view == null && joystickPrefab != null && transformParent != null)
            {
                view = this.gameObject.AddComponent<InputJoystickView>();
                view.InitilizedJoystick(joystickPrefab, transformParent);
            }
        }

        public Vector3 GetMoveDirection()
        {
            Vector2 input = view.GetJoystickProvider.Direction;
            return new Vector3(input.x, 0, input.y).normalized;
        }
    }
}
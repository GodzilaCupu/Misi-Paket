using UnityEngine;
using Mangkus.Input;

namespace Mangkus.Player.Movement
{
    [RequireComponent(typeof(PlayerMovementView))]
    public class PlayerMovementController : MonoBehaviour
    {
        private PlayerMovementModel model;
        private PlayerMovementView view;
        private IMovementInput input;

        [SerializeField] private MonoBehaviour inputProvider; // Must implement IMovementInput

        private void Awake()
        {
            model = new PlayerMovementModel();
            view = GetComponent<PlayerMovementView>();
            input = inputProvider as IMovementInput;

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
    }
}
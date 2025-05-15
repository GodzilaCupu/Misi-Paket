using UnityEngine;
using Mangkus.Player.Input;
using UnityEngine.InputSystem;

namespace Mangkus.Player.Movement
{
    [RequireComponent(typeof(PlayerMovementView))]
    public class PlayerMovementController : MonoBehaviour
    {
        private PlayerMovementModel model;
        private PlayerMovementView view;
        private IMovementInput input;
        [SerializeField] private MovementData movementData; // ScriptableObject for movement data

        private void Awake()
        {
            model = movementData.MovementModel;
            view = GetComponent<PlayerMovementView>();
            input  = GetComponent<PlayerInputController>().GetProvider;
        }

        private void Update()
        {
            Vector3 dir = input.GetMoveDirection();
            view.OnMove(dir, model.GetMoveSpeed());
            view.OnRotate(dir, model.GetRotationSpeed());
        }
    }
}

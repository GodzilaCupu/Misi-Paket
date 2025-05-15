using System.Runtime.CompilerServices;
using UnityEngine;

namespace Mangkus.Player.Input
{
    public class KeyboardController : MonoBehaviour, IMovementInput
    {
        private InputSystem_Actions inputActions;
        public Vector2 moveInput{get; private set;}
        private void Awake()
        {
            inputActions = new InputSystem_Actions();
        }

        private void OnEnable()
        {
            inputActions.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
            inputActions.Player.Move.canceled += ctx => moveInput = Vector2.zero;
            inputActions.Enable();
        }
        private void OnDisable()
        {
            inputActions.Player.Move.performed -= ctx => moveInput = ctx.ReadValue<Vector2>();
            inputActions.Player.Move.canceled -= ctx => moveInput = Vector2.zero;
            inputActions.Disable();
        }   
        
        public Vector3 GetMoveDirection()
        {
            float h = moveInput.x;
            float v = moveInput.y;
            return new Vector3(h, 0f, v).normalized;
        }
    }
}
using System;
using UnityEngine;

namespace Mangkus.Player.Movement
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovementView : MonoBehaviour
    {
        private CharacterController characterController;

        private void Awake()
        {
            characterController = GetComponent<CharacterController>();
        }

        public void OnMove(Vector3 direction, float speed)
        {
            Vector3 velocity = direction * speed;
            characterController.Move(velocity * Time.deltaTime);
        }

        public void OnRotate(Vector3 direction, float rotationSpeed)
        {
            if (direction != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(direction);

                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }
}


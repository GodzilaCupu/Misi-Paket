using System;
using UnityEngine;
namespace Mangkus.Player.Movement
{
    [Serializable]
    public class PlayerMovementModel 
    {
        [SerializeField] private float MoveSpeed = 5f;
        [SerializeField] private float RotationSpeed = 720f;
        [SerializeField] private float JumpHeight = 2f;
        [SerializeField] private float Gravity = -9.81f;

        public float SetMoveSpeed(float speed) => MoveSpeed = speed;
        public float SetRotationSpeed(float speed) => RotationSpeed = speed;
        public float SetJumpHeight(float height) => JumpHeight = height;
        public float SetGravity(float gravity) => Gravity = gravity;


        public float GetMoveSpeed() => MoveSpeed;
        public float GetRotationSpeed() => RotationSpeed;
        public float GetJumpHeight() => JumpHeight;
        public float GetGravity() => Gravity;
    }
}

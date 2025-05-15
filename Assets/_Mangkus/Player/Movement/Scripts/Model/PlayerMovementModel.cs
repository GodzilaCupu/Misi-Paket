using System;
using UnityEngine;
namespace Mangkus.Player.Movement
{
    [Serializable]
    public class PlayerMovementModel 
    {
        public float MoveSpeed { get; private set; } = 5f;
        public float RotationSpeed { get; private set; } = 720f;
    }
}

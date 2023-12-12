using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GodzillaCupu.Player
{
    public class PlayerManager : MonoBehaviour
    {
        private InputHandler input;

        [SerializeField] private GameObject playerObj;
        [SerializeField] private CharacterController playerController;
        
        private Vector2 direction;
        [SerializeField] private float moveSpeed;
        
        [SerializeField] private float smoothingTurnSpeed = 1f;
        [SerializeField] private float currentVelocityTurinnig;
        
        [SerializeField] private LayerMask ground;
        [SerializeField] private float groundDinstance = 0.1f;
        [SerializeField] private float jumptHeight = 2f;
        [SerializeField] private float gravityStregth = -9.81f;

        [SerializeField] private Transform groundCheckPos;
        [SerializeField] private bool isGrounded;
        private float jumping;

        void Awake()
        {
            if(input == null) input = InputHandler.instance;
        }

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        //Movement
        private void Move()
        {
            Vector3 direction = new Vector3(input.MoveDirection.x, 0f, input.MoveDirection.y);

            
        }
    }

}
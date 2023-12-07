using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GodzillaCupu.Player
{
    public class InputHandler : MonoBehaviour
    {
        public PlayerInputHandler _inputs;
        [HideInInspector] public UnityEvent OnEscPressed;

        public static InputHandler instance;
        public void Awake()
        {
            if(instance == null) instance = this;
            else Destroy(instance);

            if(_inputs == null) _inputs = new PlayerInputHandler();
        }

        public void OnEnable()
        {
            _inputs.Enable();
            _inputs.Player.Pause.performed += (ctx) => OnEscPressed?.Invoke();
        }

        public void Start()
        {

        }
        
        public void OnDisable()
        {
            _inputs.Disable();
            _inputs.Player.Pause.performed -= (ctx) => OnEscPressed?.Invoke();
        }
    }
}

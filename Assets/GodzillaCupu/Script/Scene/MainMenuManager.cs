using System.Collections;
using System.Collections.Generic;
using GodzillaCupu.Player;
using UnityEngine;

namespace GodzillaCupu.Manager
{
    public class MainMenuManager : MonoBehaviour
    {
        private InputHandler input;
        private void Start()
        {
            if(input == null) input = InputHandler.instance;
        }

        public void QuitApp()
        {
         Debug.LogError($"[APLICATIION] Exit");
         Application.Quit();  
        }

        public void OpenSetting()
        {
            Debug.Log($"[PAUSE PANEL] Panel is oppen");
            input.OnEscPressed?.Invoke();
        }
    }
}

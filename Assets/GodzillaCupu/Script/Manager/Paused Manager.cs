using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using GodzillaCupu.Player;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GodzillaCupu.Manager
{
    public class PausedManager : MonoBehaviour
    {
        [SerializeField] private GameObject pausePanelObj;
        [SerializeField] private GameObject buttonMainMenu;
        private bool isOpened {get => pausePanelObj.activeInHierarchy; set => pausePanelObj.SetActive(value); }
        public bool IsOpen {get=>isOpened; set => isOpened = value;}
        private InputHandler input;
        public static PausedManager instance;
        
        void Awake()
        {
            if(instance == null) instance = this;
            else Destroy(this);

            if (input == null) input = InputHandler.instance;
            if (pausePanelObj == null) Debug.LogError($"[PAUSE PANEL] Panel is Empty");
            if (buttonMainMenu == null) Debug.LogError($"[BUTTON MAIN MENU] button is Empty");
        }

        void Start()
        {
            input.OnEscPressed.AddListener(OpenPanel);
        }

        private void OpenPanel()
        {
            isOpened = pausePanelObj.activeInHierarchy ? false : true;
            bool isMainMenu = SceneManager.GetActiveScene().name == "MainMenu" ? true : false;
            buttonMainMenu.SetActive(isMainMenu?true:false);

            StopMechanic();
        }

        private void StopMechanic()
        {
            Debug.Log($"[PAUSE PANEL] Stop Mechanic in here");
            //Disable ALL Input to Player
            //Disable ALL Timer 
            //Disable ALL movement
        }




    }
}

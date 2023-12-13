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
        [SerializeField]
        private GameObject pausePanelObj;

        [SerializeField]
        private ButtonConfiguration buttonMainMenu;
        [SerializeField]
        private SliderConfiguration sliderMusic;
        [SerializeField]
        private SliderConfiguration sliderBGM;
        [SerializeField]
        private DropdownConfiguration dropdownJoystickType;
        private bool isOpened
        {
            get => pausePanelObj.activeInHierarchy;
            set => pausePanelObj.SetActive(value);
        }
        public bool IsOpen
        {
            get => isOpened;
            set => isOpened = value;
        }
        private InputHandler input;
        private PlatformManager platform;
        public static PausedManager instance { get; private set; }

        void Awake()
        {
            if (instance != null && instance != this)
                Destroy(instance);
            else
                instance = this;

            if (pausePanelObj == null)
                Debug.LogError($"[PAUSE PANEL] Panel is Empty");
            if (buttonMainMenu == null)
                Debug.LogError($"[BUTTON MAIN MENU] button is Empty");
        }

        void OnEnable() { }

        void Start()
        {
            if (input == null)
                input = InputHandler.instance;

            if(platform == null)
                platform = PlatformManager.instance; 

            input.OnEscPressed.AddListener(OpenPanel);
            SetSettingsOptionBaseOnPlatform();
        }

        private void SetSettingsOptionBaseOnPlatform()
        {
            PlayerPlatform _currentPlatform = platform.CurrentPlatform;
            dropdownJoystickType.gameObject.SetActive(_currentPlatform == PlayerPlatform.Desktop ? false : true);
        }

        private void OpenPanel()
        {
            isOpened = pausePanelObj.activeInHierarchy ? false : true;
            bool isMainMenu = SceneManager.GetActiveScene().name == "Main Menu" ? true : false;
            buttonMainMenu.gameObject.SetActive(isMainMenu ? false : true);
            Debug.Log($"{isMainMenu} current scene");


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

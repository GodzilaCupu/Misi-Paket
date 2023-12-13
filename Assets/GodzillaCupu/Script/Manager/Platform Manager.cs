using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace GodzillaCupu.Manager
{
    public class PlatformManager : MonoBehaviour
    {
        private PlayerPlatform _currentPlatform;
        public PlayerPlatform CurrentPlatform{get => _currentPlatform;}
        public RuntimePlatform testPlatform;
        public List<PlatformUI> _ui;
        public static PlatformManager instance {get; private set;}
        void Awake()
        {
            if (instance != null && instance != this)
                Destroy(instance);
            else
                instance = this;

            // _currentPlatform = CheckPlayerPlatform(Application.platform); 
            _currentPlatform = CheckPlayerPlatform(testPlatform);
        }

        void Start()
        {
            InitUI(_currentPlatform);
        }

        private PlayerPlatform CheckPlayerPlatform(RuntimePlatform platfom)
        {
            if (platfom == RuntimePlatform.Android)
                return PlayerPlatform.Mobile;
            else
                return PlayerPlatform.Desktop;
        }

        private void InitUI(PlayerPlatform platform)
        {
            PlatformUI selectedUI = _ui.Find(x => x.platform == platform);
            selectedUI.obj.SetActive(true);

            foreach (PlatformUI item in _ui)
            {
                if(item.platform != platform)
                    selectedUI.obj.SetActive(false);
            }
        }

        [Serializable]
        public class PlatformUI
        {
            public PlayerPlatform platform;
            public GameObject obj;
        }
    }
    
    [Serializable]
    public enum PlayerPlatform
    {
        Mobile,
        Desktop
    }
}

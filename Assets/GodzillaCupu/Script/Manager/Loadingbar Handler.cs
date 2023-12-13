using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using Unity.VisualScripting;

namespace GodzillaCupu.Manager
{
    public class LoadingbarHandler : MonoBehaviour
    {
        public LoadingBar loadingBar;
        [SerializeField] private float progressLoading;
        [SerializeField] private SceneLoader sceneLoader;

        public string loadingStatus = "Done";

        public static LoadingbarHandler instance{get; private set;}
        private void Awake()
        {
            if (instance != null && instance != this)
                Destroy(instance);
            else
                instance = this;

            if (sceneLoader == null)
                sceneLoader = SceneLoader.instance;
        }

        private void Start()
        {
            // loadingBar.CheckComponent();
            // loadingPanel.CheckComponent();
        }

        private void OpenLoadingPanel()
        {
            // Gameobject di open
            // get progress
            // sceneLoader.OnLoadSceneProgress.AddListener(GetLoadingProgress);

            // close game object
        }

        private void GetLoadingProgress(float progress)
        {
            Debug.Log("Progress  :" + progress );
        }

        [Serializable]
        public class LoadingBar
        {
            public GameObject barProgres;
            public TextMeshProUGUI loadingText;
            public TextMeshProUGUI percentageText;

            public void CheckComponent()
            {
                if (barProgres == null) Debug.LogError($"[LOADING BAR] bar is Empty, Check Again");

                if (loadingText == null) Debug.LogError($"[LOADING BAR TEXT] loaidng text is Empty, Check Again");

                if (percentageText == null) Debug.LogError($"[LOADING BAR TEXT] laoding percentange text is Empty, Check Again");
            }
        }

        [Serializable]
        public class LoadingPanel
        {
            public bool isActive = false;
            [Space(10), TextArea(1, 5)] public List<string> tips;
            public List<Image> backgroundImages;
            public GameObject loadingPanel;
            public GameObject loadingBackground;
            public TextMeshProUGUI loadingText;
            public TextMeshProUGUI loadingTipsText;
            public void CheckComponent()
            {
                if (loadingPanel == null) Debug.LogError($"[LOADING PANEL] Panel is Empty, Check Again");

                if (loadingBackground == null) Debug.LogError($"[LOADING PANEL BACKGROUND] Background is Empty, Check Again");

                if (loadingText == null) Debug.LogError($"[LOADING PANEL TEXT] Text is Empty, Check Again");

                if (loadingTipsText == null) Debug.LogError($"LOADING PANEL TIPS TEXT] Tips text is Empty, Check Again");
            }
        }


    }
}

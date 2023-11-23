using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Build.Pipeline;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GodzillaCupu.Manager
{
    [Serializable]
    public class LoadingPanel
    {
        [Serializable]
        public class LoadingBar
        {
            public GameObject barProgres;
            public TextMeshProUGUI loadingText;
            public TextMeshProUGUI presentageText;
        }
        public GameObject loadingPanel;
        public List<Image> backgroundImages;
        public TextMeshProUGUI loadingText;
        public TextMeshProUGUI loadingTipsText;
        public LoadingBar loadingBar;
        public bool isActive = false;
    }

    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private LoadingPanel loadingPanel;
        public string currentScene{get; private set;}



        public static SceneLoader instance;
        void Awake()
        {
            if(instance == null) instance = this;
            else Destroy(this);

            if(loadingPanel == null)
                loadingPanel = new LoadingPanel();
            
        }

        // This Metod Not Complate Yet
        public void LoadSceneAddresable(string id)
        {
            Addressables.LoadSceneAsync(id,LoadSceneMode.Additive);
        }

        public string GetCurrentScene()
        {
            string _currentScene =  SceneManager.GetActiveScene().name;
            return currentScene = _currentScene;
        }
    }
}

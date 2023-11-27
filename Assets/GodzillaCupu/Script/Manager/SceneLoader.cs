using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GodzillaCupu.Manager
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private Scene currentScene;
        public string currentSceneName{get; private set; }
        public float loadingProgresScene { get; private set; }

        public UnityEvent<float> OnLoadSceneProgress;

        public static SceneLoader instance;
        void Awake()
        {
            if(instance == null) instance = this;
            else Destroy(this);
        }

        public string GetCurrentScene()
        {
            currentScene = SceneManager.GetActiveScene();
            currentSceneName = currentScene.name;
            return currentSceneName;
        }

        public void LoaderScene(string id)
        {
            if(currentScene != null)
                UnloaderScene(currentSceneName);

            AsyncOperation _sceneAsyc = SceneManager.LoadSceneAsync(id,LoadSceneMode.Additive);
            StartCoroutine(GetLoadProgress(_sceneAsyc));
            _sceneAsyc.completed += (asyc) => GetCurrentScene();
        }

        IEnumerator GetLoadProgress(AsyncOperation asyncOperation)
        {
            while (!asyncOperation.isDone)
            {
                loadingProgresScene = Mathf.Clamp01(asyncOperation.progress / 0.9f); // 0.9 is the completion value
                
                OnLoadSceneProgress?.Invoke(loadingProgresScene*100);

                // You can use the progress value for updating a loading bar or displaying progress in some way
                Debug.Log("Loading progress: " + loadingProgresScene * 100 + "%");

                yield return null;
            }
        }

        public void UnloaderScene(string id) => SceneManager.UnloadSceneAsync(id);
    }
}
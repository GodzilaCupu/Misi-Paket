using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;


public class SceneLoader : MonoBehaviour
{
    [SerializeField] private Image _loadingBar;
    [SerializeField] private string _currentMainScene;
    [SerializeField] private GameObject _panelLoading;
    [SerializeField] private TextMeshProUGUI _progresText;

    public static SceneLoader Instance {get;private set;}

    void Awake()
    {
        if(Instance == null) 
            Instance = this;
        else 
            Destroy(this);
    }

    public void LoaderScene(string targetScene)
    {
        UnloadScene();
        StartCoroutine(Loader(targetScene));
    }

    public string GetActiveSceneName() => SceneManager.GetActiveScene().name;

    private void UnloadScene()
    {
        if(SceneManager.sceneCount < 2) return;
        SceneManager.UnloadSceneAsync(GetActiveSceneName());
    }

    IEnumerator Loader(string nameScene)
    {
        AsyncOperation loadingProgres = SceneManager.LoadSceneAsync(nameScene,LoadSceneMode.Additive);
        
        _panelLoading.SetActive(true);

        while (!loadingProgres.isDone)
        {
            float loadingProgresValue = Mathf.Clamp01(loadingProgres.progress/0.9f);
            _loadingBar.fillAmount = loadingProgresValue;
            _progresText.text = "Progres " + loadingProgresValue.ToString();
            yield return null;
        }
        if(loadingProgres.isDone) {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(nameScene));
            _currentMainScene = GetActiveSceneName();
            _panelLoading.SetActive(false);
        }
    }
}

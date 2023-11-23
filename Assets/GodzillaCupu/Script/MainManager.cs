using System; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    [Header("Scene Management")]
    // Testing
    [SerializeField] private enum_SceneName SceneName;

    public static MainManager Instance {get;private set;}

    void Awake()
    {
        if(Instance == null) 
            Instance = this;
        else 
            Destroy(this);
    }

    IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        OpenScene(CheckName(SceneName));
    }

    public void OpenScene(string targetScene) => SceneLoader.Instance.LoaderScene(targetScene);

    private string CheckName(enum_SceneName name){
        string tempName;
        switch (name)
        {
            case enum_SceneName.Home:
                tempName = ConstantValue.SCENE_HOME;
                break;

            case enum_SceneName.Level1:
                tempName = ConstantValue.SCENE_HOME;
                break;

            case enum_SceneName.Level2:
                tempName = ConstantValue.SCENE_HOME;
                break;

            case enum_SceneName.Level3:
                tempName = ConstantValue.SCENE_HOME;
                break;

            default:
                tempName = ConstantValue.SCENE_HOME;
                break;
        }
        return tempName;
    }


    public void QuitApp() {
        Application.Quit();
        print("Works");
    }
}

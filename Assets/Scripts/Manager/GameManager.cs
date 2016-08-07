using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : SingletonUnity<GameManager>
{
    private string[] scenes;
    private string loadingScene = "LoadingScene";

    public string currentScene;
    public string DirScene;

    void Start()
    {
        scenes = Constant.Scenes;
    }

    /// <summary>
    /// Loads the main scene.
    /// </summary>
    public void loadMainScene()
    {
        DirScene = scenes[(int) SceneType.MainScene];
        SceneManager.LoadScene (loadingScene);
    }

    public void loadOtherScene()
    {
        DirScene = scenes [(int)SceneType.OtherScene];
        SceneManager.LoadScene (loadingScene);
    }



}

public enum SceneType
{
    LoginScene,
    MainScene,
    OtherScene,
}


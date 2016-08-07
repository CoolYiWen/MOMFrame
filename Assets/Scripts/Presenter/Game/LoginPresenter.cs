using UnityEngine;
using System.Collections;

public class LoginPresenter : SingletonUnity<LoginPresenter>
{
    private string currentScene = "LoginScene";

    public GameObject UI_Parent;
    public GameObject DontDestroyed;

    void Start ()
    {
        DontDestroyOnLoad (DontDestroyed);

        GameManager.Instance.currentScene = currentScene;
        UIManager.Instance.Show (UI_Parent, UIType.Login_Panel);

        addEventListener ();
            
    }

    private void addEventListener()
    {
        UIEventDispatcher eventDispatcher = GameObject.Find (GameManager.Instance.currentScene).GetComponent<UIEventDispatcher>();
        eventDispatcher.MouseOver += login;
    }

    private void login(GameObject obj)
    {
        GameManager.Instance.loadMainScene ();
    }

}


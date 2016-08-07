using UnityEngine;
using System.Collections;

public class Login_Panel : MonoBehaviour {
    private string currentScene = "LoginScene";
    private UIEventDispatcher eventDispatcher;
	
    void Awake()
    {
        eventDispatcher = GameObject.Find(currentScene).GetComponent<UIEventDispatcher>();
    }

    public void loadMainScene()
    {
        eventDispatcher.OnMouseOver ();

    }



}

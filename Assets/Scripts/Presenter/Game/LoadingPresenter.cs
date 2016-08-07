using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadingPresenter : MonoBehaviour {

    public UILabel Progress;

    private AsyncOperation asyn;

    void Start()
    {
        StartCoroutine (loadScene ());
    }

    void Update()
    {
        if(asyn != null)
        {
            Progress.text = asyn.progress * 100 + "%";
        }
    }

    IEnumerator loadScene()
    {
        yield return new WaitForEndOfFrame ();
        asyn = SceneManager.LoadSceneAsync (GameManager.Instance.DirScene);
        yield return asyn;
    }

}

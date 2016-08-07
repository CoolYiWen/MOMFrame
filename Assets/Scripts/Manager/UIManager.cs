using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIManager : SingletonUnity<UIManager> {

    private List<GameObject> showList = new List<GameObject>();

    /// <summary>
    /// Show the only UI_Panel from the type.
    /// </summary>
    public void Show(GameObject parent, UIType type)
    {
        CloseAll ();
        AddShow (parent, type);
    }

    /// <summary>
    /// AddShow the UI_Panel from the type.
    /// </summary>
    public void AddShow(GameObject parent, UIType type)
    {
        GameObject obj = PoolManager.Instance.GetUIFromPool (type);

        if(obj == null)
        {
            Debug.Log (type.ToString ());
            GameObject o = UILoader.Instance.LoadUIPanel (parent, type.ToString());
            o.SetActive (true);
            showList.Add (o);
            PoolManager.instance.AddUIPool (o);
        }
        else
        {
            obj.SetActive (true);
            showList.Add (obj);
        }
    }

    /// <summary>
    /// Closes all UI_Panel.
    /// </summary>
    public void CloseAll()
    {
        if(showList.Count != 0)
        {
            for(int i = 0; i < showList.Count; i++)
            {
                showList [i].SetActive (false);
            }

            showList.Clear ();
        }
    }

    /// <summary>
    /// Closes the current UI_Panel.
    /// </summary>
    public void CloseCurrent()
    {
        if (showList.Count != 0)
        {
            int index = showList.Count - 1;
            showList [index].SetActive (false);
            showList.RemoveAt (index);
        }
    }

}

public enum UIType
{
    None,
    Login_Panel,
}
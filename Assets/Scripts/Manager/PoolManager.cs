using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PoolManager : SingletonUnity<PoolManager>
{
    private List<GameObject> UI_Pool = new List<GameObject>();

    /// <summary>
    /// Adds the UI GameObject into the UIPool.
    /// </summary>
    /// <param name="obj">Object.</param>
    public void AddUIPool(GameObject obj)
    {
        UI_Pool.Add (obj);

        if(UI_Pool.Count > 5)
        {
            UI_Pool.RemoveAt (0);
        }
    }

    public GameObject GetUIFromPool(UIType type)
    {
        foreach(GameObject obj in UI_Pool)
        {
            if(obj.name == type.ToString())
            {
                return obj;
            }
        }

        return null;
    }
}


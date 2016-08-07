using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LoaderBase<T> : Singleton<T> where T : new() {

    protected string loaderName;

    public virtual Object Load(string name) {

        Object obj = Resources.Load (loaderName + name);

        if (obj == null) {

            Debug.LogError ("Resource can't load. Resource name : " + loaderName + name);

            return default(Object);

        }

        return obj;

    }

    public virtual GameObject LoadObject(string name) {

        GameObject obj = GameObject.Instantiate(Load(name)) as GameObject;

        if(obj == null) {

            Debug.LogError("Lose Res, name is :" + name);

        }

        return obj;

    }

    public virtual K Load<K>(string name) where K : MonoBehaviour {

        GameObject obj = GameObject.Instantiate(Load(name)) as GameObject;

        if (obj == null) {

            Debug.LogError("Instantiate create false. Instantiate Name: " + name);

            return default(K);

        }

        obj.name = name;

        K k = obj.GetComponent<K> ();

        if (k == null) {

            Debug.LogError("GetComponent is error. component name:" + typeof(K).ToString());

            return default(K);

        }

        return k;

    }

    public void ClearAllAsset() {

        Resources.UnloadUnusedAssets ();

    }

}

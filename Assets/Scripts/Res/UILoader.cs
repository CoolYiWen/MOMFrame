using UnityEngine;
using System.Collections;

public class UILoader : LoaderBase<UILoader> {

    public UILoader()
    {
        loaderName = "Prefabs/UI/";
    }
	
    public GameObject LoadUIPanel(GameObject parent, string name)
    {
        
        GameObject obj = NGUITools.AddChild (parent, Load(name) as GameObject);
        Debug.Log (obj.name);
        if(obj == null) 
        {
            Debug.LogError("Lose Res, name is :" + name);
        }

        return obj;
    }

}

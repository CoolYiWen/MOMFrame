using UnityEngine;
using System.Collections;

public class EquipmentApi {

    private static string url = "115.28.51.71/equipment/";
    private static string baseParam = "base/search?";

    public string result = "";

    public IEnumerator GetBaseEQ(int id)
    {
        WWW www = new WWW (url + baseParam + "id=" +id);
        yield return www;

        if (www.error != null) 
        {
            result = www.error;
            yield return null;
        } 
        else
        {
            result = www.text;
            Debug.Log (result);
        }
    }



}

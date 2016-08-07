using UnityEngine;
using System.Collections;


public class PlayerPresenter : MonoBehaviour {

	// Use this for initialization
	void Start () {
        EquipmentApi api = new EquipmentApi ();
        StartCoroutine (api.GetBaseEQ (1));
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void starNewScene()
    {
        GameManager.Instance.loadOtherScene ();
    }
}

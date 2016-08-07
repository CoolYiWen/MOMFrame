using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {

    public GameObject ob;
    private Vector3 v = new Vector3 ();
    private float speed = 0.0375f;

	// Use this for initialization
	void Start () {
        StartCoroutine (Routine ());
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position += v;
	}

    IEnumerator Routine()
    {
        yield return new WaitForSeconds (3f);
        v.z = speed;
        yield return new WaitForSeconds (3f);
        v.z = 0;
        v.x = -speed;
    }
}

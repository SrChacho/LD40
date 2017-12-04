using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour {

    public float time = 1;
    
    // Use this for initialization
	void Start () {
        Invoke("DestroyObject", time);
	}

    void DestroyObject()
    {
        Destroy(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteOnLimit : MonoBehaviour {

    public float limit = -10;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (transform.position.x < limit)
        {
            Destroy(gameObject);
        }

    }
}

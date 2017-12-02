using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour {

    public float speed = 1;
    public float limit;
    public float newX;
    
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {

        transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);

        if(transform.position.x < limit)
        {
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);
        }

    }
}

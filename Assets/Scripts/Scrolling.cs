using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour {

    public float speed = 1;
    public float limit;
    public float newX;
    public bool teleportBack = false;
    public bool randomVariance = false;
    public float minRandom;
    public float maxRandom;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {

        transform.position = new Vector3(transform.position.x - speed * GameManager.instance.gameSpeed, transform.position.y, transform.position.z);

        if(transform.position.x < limit && teleportBack)
        {
            if (!randomVariance)
            {
                transform.position = new Vector3(newX, transform.position.y, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(Random.Range(newX - minRandom, newX + maxRandom), transform.position.y, transform.position.z);
            }
        }

    }
}

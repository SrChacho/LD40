using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour {

    public GameObject prefab;
    public float speed = 1;
    //public float limit;
    public float newX;
    public float minTime = 0.3f;
    public float maxTime = 4f;

    // Use this for initialization
    void Start () {
        Spawn();
	}
	
	// Update is called once per frame
	void Update () {

    }

    void Spawn()
    {
        Instantiate(prefab, new Vector3(Random.Range(newX - 5, newX + 5), transform.position.y, transform.position.z), transform.rotation);
        Invoke("Spawn", Random.Range(minTime, maxTime));
    }

    /*
    private void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);

        if (transform.position.x < limit)
        {
            Instantiate(prefab, new Vector3(Random.Range(newX - 5, newX + 5), transform.position.y, transform.position.z), transform.rotation);
            Destroy(gameObject);
        }
    }*/

}

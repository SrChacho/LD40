using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour {

    public GameObject prefab;
    //public float speed = 1;
    //public float limit;
    public float firstInvokeTime = 0;
    public float newX;
    public float minTime = 0.3f;
    public float maxTime = 4f;
    public bool randomVariance = false;
    public float minPosRandom = 5;
    public float maxPosRandom = 5;

    // Use this for initialization
    void Start () {
        Invoke("Spawn", firstInvokeTime);
	}
	
	// Update is called once per frame
	void Update () {

    }

    void Spawn()
    {
        if(GameManager.instance.gameSpeed > 0)
        {
            if (!randomVariance)
            {
                Instantiate(prefab, new Vector3(newX, transform.position.y, transform.position.z), transform.rotation);
            }
            else
            {
                Instantiate(prefab, new Vector3(Random.Range(newX - minPosRandom, newX + maxPosRandom), transform.position.y, transform.position.z), transform.rotation);
            }
            Invoke("Spawn", Random.Range(minTime, maxTime));
        }
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

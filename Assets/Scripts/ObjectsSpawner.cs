using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsSpawner : MonoBehaviour {

	public List<GameObject> objects = new List<GameObject>();
	public Vector2[] positions; 
    public float firstInvokeTime = 0;
    public float newX;
    public float minTime = 0.3f;
    public float maxTime = 4f;
    public bool randomVariance = false;
    public float minPosRandom = 5;
    public float maxPosRandom = 5;

    // Use this for initialization
    void Start () {
        InvokeRepeating("Spawn", firstInvokeTime, Random.Range(minTime, maxTime));
	}
	
	// Update is called once per frame
	void Update () {
		if(GameManager.instance.gameSpeed == 0){
			CancelInvoke();
		}
    }

    void Spawn()
    {
		Instantiate(objects[Random.Range(0, objects.Count)], positions[Random.Range(0, positions.Length)], this.transform.rotation);
	}
}

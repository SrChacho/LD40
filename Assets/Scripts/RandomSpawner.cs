using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour {

    public List<GameObject> enemies = new List<GameObject>();

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
        float chance = Random.Range(0f, 1f);
		if(chance < 0.4f){
			Instantiate(enemies[0], new Vector2(20, -1), this.transform.rotation);
		}else{
			Instantiate(enemies[Random.Range(1, enemies.Count)], new Vector2(20, -2.63f), this.transform.rotation);
		}
    }
}

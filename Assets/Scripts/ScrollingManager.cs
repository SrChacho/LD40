using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingManager : MonoBehaviour {
	public float speed = 0.2f;
    public float limit = -20f;
    public float newX = 20f;
	float y = -0.2f;
	public List<GameObject> houses = new List<GameObject>();

	void Start(){
		//Instantiate two first houses
		Instantiate( houses[Random.Range(0, houses.Count)], new Vector2(0,y), new Quaternion(0,0,0,0));
		Instantiate( houses[Random.Range(0, houses.Count)], new Vector2(newX,y), new Quaternion(0,0,0,0));
		InvokeRepeating("SpawnHouse", 2f, 2f);
	}

	void Update()
	{
		if(GameManager.instance.gameSpeed == 0){
			CancelInvoke();
		}
	}

	public void SpawnHouse(){
		Instantiate(houses[Random.Range(0, houses.Count)], new Vector2(newX, y), new Quaternion(0,0,0,0));
	}
}

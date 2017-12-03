using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public List<GameObject> objects = new List<GameObject>();
	public List<GameObject> enemies = new List<GameObject>();
	public Vector2[] pos;
	public float minTime = 0.3f;
    public float maxTime = 4f;
	public bool[] instances;
	float firstInvokeTime = 3;

	// Use this for initialization
    void Start () {
        InvokeRepeating("Spawn", firstInvokeTime, Random.Range(minTime, maxTime));
	}

	void Update(){
		if(GameManager.instance.gameSpeed == 0){
			CancelInvoke();
		}
	}

	void Spawn(){
		float chance = Random.Range(0f, 1f);

		//Posibilidad de instanciar un coche en la oleada
		if(chance <= 0.7f){
			chance = Random.Range(0f, 1f);

			if(chance < 0.5f){
				//Instancio coche
				Instantiate(enemies[0], pos[0], transform.rotation);
				instances[0] = true;
			}else{
				//Instancio apisonadora
				Instantiate(enemies[1], new Vector2(pos[1].x ,-1.29f), transform.rotation);
				instances[1] = true;
			}
		}

		chance = Random.Range(0f, 1f);

		//Posibilidad de instanciar un objeto en la oleada
		if(chance <= 0.6f){
			Vector2 aux;
			//Determino la posicion de instancia
			if(instances[0] == true){
				aux = pos[Random.Range(1,3)];
			}else if(instances[1] == true){
				int where = Random.Range(0,2);
				if(where == 0){
					aux = pos[0];
				}else{
					aux = pos[2];
				}
			}else{
				aux = pos[Random.Range(0,3)];
			}

			//Instancio el objeto en la posicion donde NO haya un coche
			Instantiate(objects[Random.Range(0, objects.Count)], aux, this.transform.rotation);
		}

		//instances refill
		for(int z = 0; z < instances.Length; z++){
			instances[z] = false;
		}
	}
}

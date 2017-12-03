using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public GameObject explosionPrefab;
    
    // Use this for initialization
	void Start () {
		
	}

    private void Awake()
    {
        //Comprobar si esta muy cerca de otro enemigo
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject item in enemies)
        {
            if(!item.Equals(gameObject))
            {
                if (transform.position.x > item.transform.position.x - 12 && transform.position.x < item.transform.position.x + 12)
                {
                    print("Spawned too close");
                    Destroy(gameObject);
                }
            }
        }
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" )
        {
<<<<<<< HEAD
            if(this.gameObject.name == "road-roller(Clone)"){
                //Si me choco con la apisonadora y estoy tumbado la esquivo
                if(Player.instance.holdingCrouch == false){
                    GameManager.instance.GameOver();
                }
            }else{
                //Colisión con el resto de enemigos
                GameManager.instance.GameOver();
            }
            
=======
            GameObject explosion = Instantiate(explosionPrefab);
            explosion.transform.position = collision.transform.position;
            if (!Player.instance.inmune)
            {
                GameManager.instance.GameOver();
            }
        }

        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
>>>>>>> bf855e113f4f81efdcd741741cea956cfce52211
        }
    }

}

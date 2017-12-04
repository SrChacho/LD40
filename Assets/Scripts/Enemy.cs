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
            if (Player.instance.inmune)
            {
                GameObject explosion = Instantiate(explosionPrefab);
                explosion.transform.position = collision.transform.position;
                explosion.transform.GetChild(0).localScale = new Vector3(2.5f, 2.5f, 1);
                Destroy(gameObject);
            }
            else if (!Player.instance.inmune)
            {
                GameObject explosion = Instantiate(explosionPrefab);
                explosion.transform.position = collision.transform.position;
                GameManager.instance.GameOver();
            }
        }

        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }

}

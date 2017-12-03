﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour {

    public float speed = 0.2f;
    public float limit = -10;
    public float givenScore = 1;
    public AudioClip pickupSound;
    public float audioVolume = 1;

    private void Awake()
    {
        //Comprobar si esta muy cerca de otro enemigo
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject item in enemies)
        {
            if (!item.Equals(gameObject))
            {
                if (transform.position.x > item.transform.position.x - 4 && transform.position.x < item.transform.position.x + 4)
                {
                    print("Spawned too close");
                    Destroy(gameObject);
                }
            }
        }
    }

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        if (transform.position.x < limit)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            GameManager.instance.ChangeScore(givenScore);
            collision.transform.parent.GetComponent<AudioSource>().PlayOneShot(pickupSound, audioVolume);
            GameManager.instance.gameSpeed += 0.025f;
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x - speed * GameManager.instance.gameSpeed, transform.position.y, transform.position.z);
    }

}

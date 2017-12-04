using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour {
    //Tipos de objetos
    public enum ItemType
    {
        coin,
        inmune
    };

    public float speed = 0.2f;
    public float limit = -10;
    public float givenScore = 1;
    public AudioClip pickupSound;
    public float audioVolume = 1;
    public ItemType itemType;

    private void Awake()
    {
        //Comprobar si esta muy cerca de otro enemigo
        GameObject[] collectibles = GameObject.FindGameObjectsWithTag("Collectible");
        foreach (GameObject item in collectibles)
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            //Comportamiento al recoger el objeto segun si te hace inmune o no
            if(itemType == ItemType.coin)
            {
                GameManager.instance.ChangeScore(givenScore);
                GameManager.instance.gameSpeed += 0.001f;
            }
            else if(itemType == ItemType.inmune)
            {
                Player.instance.MakeInmune(5.85f);
            }
            collision.transform.parent.GetComponent<AudioSource>().PlayOneShot(pickupSound, audioVolume);
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (transform.position.x < limit)
        {
            Destroy(gameObject);
        }

        transform.position = new Vector3(transform.position.x - speed * GameManager.instance.gameSpeed, transform.position.y, transform.position.z);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour {

    public float speed = 0.2f;
    public float limit = -10;
    public float givenScore = 1;
    public AudioClip pickupSound;
    public float audioVolume = 1;

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
            collision.GetComponent<AudioSource>().PlayOneShot(pickupSound, audioVolume);
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x - speed * GameManager.instance.gameSpeed, transform.position.y, transform.position.z);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour {

    public float speed = 1;
    public float limit;
    public float newX;

    ScrollingManager sm;

    void Start(){
        sm = GameObject.Find("GameManager").GetComponent<ScrollingManager>();
    }
    void FixedUpdate()
    {
        //constantly moving
        transform.position = new Vector3(transform.position.x - speed * GameManager.instance.gameSpeed, transform.position.y, transform.position.z);

<<<<<<< HEAD
        if(transform.position.x <= limit){
            DestroyImmediate(this.gameObject);
=======
        if(transform.position.x < limit)
        {
            if (teleportBack)
            {
                if (!randomVariance)
                {
                    transform.position = new Vector3(newX, transform.position.y, transform.position.z);
                }
                else
                {
                    transform.position = new Vector3(Random.Range(newX - minRandom, newX + maxRandom), transform.position.y, transform.position.z);
                }
            }
            else
            {
                Destroy(gameObject);
            }
>>>>>>> bf855e113f4f81efdcd741741cea956cfce52211
        }


    }
}

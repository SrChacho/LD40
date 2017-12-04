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
    void Update()
    {
        //El elemento se mueve constantemente en eje x y si supera un limite se reseta a la posicion original
        transform.position = new Vector3(transform.position.x - speed * GameManager.instance.gameSpeed, transform.position.y, transform.position.z);

        if(transform.position.x <= limit){
            DestroyImmediate(this.gameObject);
        }
    }
}

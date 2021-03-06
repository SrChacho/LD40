﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleScrolling : MonoBehaviour {

public float speed = 1;
public float limit = -20;
public float newX = 20;

 private void Update()
    {
        //El elemento se mueve constantemente en eje x y si supera un limite se reseta a la posicion original
        transform.position = new Vector3(transform.position.x - speed * GameManager.instance.gameSpeed, transform.position.y, transform.position.z);

        if(transform.position.x < limit){
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);
        }
    }
}

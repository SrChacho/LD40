using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" )
        {
            if(this.gameObject.name == "road-roller(Clone)"){
                //Si me choco con la apisonadora y estoy tumbado la esquivo
                if(Player.instance.holdingCrouch == false){
                    GameManager.instance.GameOver();
                }
            }else{
                //Colisión con el resto de enemigos
                GameManager.instance.GameOver();
            }
            
        }
    }

}

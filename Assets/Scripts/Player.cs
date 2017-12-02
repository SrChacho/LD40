using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public static Player instance;
    public float jumpForce = 1;

    private Rigidbody2D rb2d;
    private bool holdingJump = false;
    [SerializeField]
    private float jumpTimer;

    private void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start () {

        rb2d = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {

        // SALTO

        if (Input.GetButtonDown("Jump") && Grounded())
        {
            holdingJump = true;
            rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpTimer = 0.25f;
        }

        if (Input.GetButton("Jump") && holdingJump)
        {
            
            if(jumpTimer >= 0)
            {
                jumpTimer -= Time.deltaTime;
                rb2d.AddForce(Vector2.up * (jumpForce * 0.03f), ForceMode2D.Impulse);
            }
        }
        if (Input.GetButtonUp("Jump"))
        {
            holdingJump = false;
        }


    }

    // FUNCION PARA COMPROBAR GROUNDED
    private bool Grounded()
    {
        if(Physics2D.Raycast(transform.position, Vector2.down, 1.5f))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}

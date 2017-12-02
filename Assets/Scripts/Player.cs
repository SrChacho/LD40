using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public static Player instance;
    public float jumpForce = 1;

    private Rigidbody2D rb2d;

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

        if (Input.GetButtonDown("Jump") && Grounded())
        {
            print("Jump");
            rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

	}

    private bool Grounded()
    {
        if(Physics2D.Raycast(transform.position, Vector2.down, 1.5f))
        {
            print("Choca");
            return true;
        }
        else
        {
            print("No choca");
            return false;
        }
    }
}

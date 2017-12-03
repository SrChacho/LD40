using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public static Player instance;
    public float jumpForce = 1;
    public ParticleSystem sparksParticles;

    private Rigidbody2D rb2d;
    private Animator animator;
    private bool holdingJump = false;
    public bool holdingCrouch = false;
    [SerializeField]
    private float jumpTimer;

    private void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start () {

        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        // LANZA UN RAYCAST PARA COMPROBAR SI ESTA GROUNDED
        InvokeRepeating("Grounded", 0, 0.05f);

	}
	
	// Update is called once per frame
	void Update () {

        // SALTO
        if (Input.GetButtonDown("Jump") && Grounded() && !holdingCrouch)
        {

            holdingJump = true;
            rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpTimer = 0.25f;
            animator.SetTrigger("Jump");
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

        if (Input.GetButtonDown("Crouch") )
        {
            rb2d.gravityScale = 9;
            if (Grounded())
            {
                holdingCrouch = true;
                //rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                //crouchTimer = 0.25f;
                animator.SetBool("Crouching", true);
                sparksParticles.Play();

            }
        }

        if (Input.GetButtonUp("Crouch"))
        {
            holdingCrouch = false;
            animator.SetBool("Crouching", false);
            sparksParticles.Stop();
            rb2d.gravityScale = 4;

        }

    }

    // FUNCION PARA COMPROBAR GROUNDED
    private bool Grounded()
    {
        if(Physics2D.Raycast(transform.position, Vector2.down, 1.5f))
        {
            animator.SetBool("Grounded", true);
            return true;
        }
        else
        {
            animator.SetBool("Grounded", false);
            return false;
        }
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    Rigidbody rb;
    SpriteRenderer sr;
    Animator anim;

    public float upForce = 100;
    public float speed = 1500;
    public float runSpeed = 2500;

    public bool isGrounded = false;

    bool isLeftShift;
    float moveHorizontal;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sr = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        isLeftShift = Input.GetKey(KeyCode.LeftShift);
        //Input.GetAxis("Vertical");
        moveHorizontal = Input.GetAxis("Horizontal");

        if (moveHorizontal > 0)
        {
            sr.flipX = false;
        }
        else if(moveHorizontal < 0)
        {
            sr.flipX = true;
        }

        if (moveHorizontal == 0)
        {
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isRunning", true);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * upForce);
            isGrounded = false;
        }

    }

    private void FixedUpdate()
    {
        if (isLeftShift)
        {
            rb.velocity = new Vector3(moveHorizontal * runSpeed * Time.deltaTime, rb.velocity.y,0);
        }
        else 
        {
            rb.velocity = new Vector3(moveHorizontal * speed * Time.deltaTime, rb.velocity.y,0);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }
}
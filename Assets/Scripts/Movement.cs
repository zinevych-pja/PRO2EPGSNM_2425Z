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
    float moveVertical;
    
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
        moveVertical = Input.GetAxis("Vertical");

        if (moveHorizontal > 0)
        {
            sr.flipX = false;
        }
        else if(moveHorizontal < 0)
        {
            sr.flipX = true;
        }

        if (moveHorizontal == 0 && moveVertical == 0)
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
            anim.SetBool("isGrounded",false);
            anim.SetTrigger("jump");
        }

    }

    private void FixedUpdate()
    {
        if (isLeftShift)
        {
            float normalizedSpeed = runSpeed * Time.deltaTime;
            rb.velocity = new Vector3(moveHorizontal * normalizedSpeed, rb.velocity.y,moveVertical * normalizedSpeed);
        }
        else 
        {
            float normalizedSpeed = speed * Time.deltaTime;
            rb.velocity = new Vector3(moveHorizontal * normalizedSpeed, rb.velocity.y,moveVertical * normalizedSpeed);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
        anim.SetBool("isGrounded",true);
    }

    public void Save()
    {
        SaveData.instance.playerX = transform.position.x;
        SaveData.instance.playerZ = transform.position.z;
        SaveData.instance.playerY = transform.position.y;
    }

    public void Load()
    {
        transform.position = new Vector3(SaveData.instance.playerX, SaveData.instance.playerY, SaveData.instance.playerZ);
    }
}

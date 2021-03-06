﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPointMovement : MonoBehaviour
{
    public AudioSource gunShot;
    public GameObject player;
    public Rigidbody2D rb1;
    Vector2 movement1;
    Vector3 movement02;
    public int shootPointPos = 20;

    void Start()
    {
        gunShot = this.GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {

        //Need to do movement this way to split up the distinction between the arrow keys and WASD

        movement1.x = 0;
        movement1.y = 0;

        if (Input.GetKey("up"))
        {
            movement1.y = 1;
        }
        else if (Input.GetKey("down"))
        {
            movement1.y = -1;
        }

        if (Input.GetKey("left"))
        {
            movement1.x = -1;
        }
        else if (Input.GetKey("right"))
        {
            movement1.x = 1;
        }
    }

    void FixedUpdate()
    {
        movement02.z = 0;

        if (movement1.x != 0 || movement1.y != 0)
        {
            movement02.x = 0;
            movement02.y = 0;
            transform.rotation = Quaternion.identity;
        }

        //Where to place fire point
        if (movement1.x == 1)
        {
            movement02.x = shootPointPos;
        }
        else if (movement1.x == -1)
        {
            movement02.x = -shootPointPos;
        }

        if (movement1.y == 1)
        {
            movement02.y = shootPointPos;
        }
        else if (movement1.y == -1)
        {
            movement02.y = -shootPointPos;
        }

        

        //Find which way to rotate
        if(movement1.x == 1) //Moving right
        {
            if(movement1.y == 1)//Up-Right
            {
                transform.Rotate(0f, 0f, 45f);
            }
            else if(movement1.y == -1) //Down-Right
            {
                transform.Rotate(0f, 0f, 315f);
            }
        }
        else if(movement1.x == -1) //Moving left
        {
            if(movement1.y == 1) //Up-Left
            {
                transform.Rotate(0f, 0f, 135f);
            }
            else if(movement1.y == -1) //Down-Left
            {
                transform.Rotate(0f, 0f, 225f);
            }
            else //Just Left
            {
                transform.Rotate(0f, 0f, 180f);
            }
        }
        else if(movement1.y == 1)//Just Up
        {
            transform.Rotate(0f, 0f, 90);
        }
        else if(movement1.y == -1)//Just Down
        {
            transform.Rotate(0f, 0f, 270f);
        }

        rb1.MovePosition(player.transform.position + movement02 * Time.fixedDeltaTime);
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPointMovement : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D rb;
    Vector2 movement;
    Vector3 movement2;
    public int attackPointPos = 100;
    // Update is called once per frame
    void Update()
    {
        movement.x = 0;
        movement.y = 0;

        if (Input.GetKey("w"))
        {
            movement.y = 1;
        }
        else if (Input.GetKey("s"))
        {
            movement.y = -1;
        }

        if (Input.GetKey("a"))
        {
            movement.x = -1;
        }
        else if (Input.GetKey("d"))
        {
            movement.x = 1;
        }


    }

    void FixedUpdate()
    {
        movement2.z = 0;
        
        if(movement.x !=0 || movement.y !=0)
        {
            movement2.x = 0;
            movement2.y = 0;
        }
        

        if(movement.x == 1)
        {
            movement2.x = attackPointPos;
        }
        else if(movement.x == -1)
        {
            movement2.x = -attackPointPos;
        }

        if (movement.y == 1)
        {
            movement2.y = attackPointPos;
        }
        else if(movement.y == -1)
        {
            movement2.y = -attackPointPos;
        }

        rb.MovePosition(player.transform.position + movement2 * Time.fixedDeltaTime);
    }
}
